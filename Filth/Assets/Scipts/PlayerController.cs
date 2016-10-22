using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour {

	[SerializeField] float speed = 1.0f;
    [SerializeField] GameObject gamecore;
    SprayController spray_controller;

	Rigidbody2D rb;
	Animator animator;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
        spray_controller = gamecore.GetComponent<SprayController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

    void FixedUpdate()
    {
        // Compute movement.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        string animation_type = "Idle";

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rb.velocity = speed * movement;

        // Animate
        /*	if (moveHorizontal > 0) {
                animator.Play ("Right");
            } else if (moveHorizontal < 0) {
                animator.Play ("Left");
            } else if (moveVertical > 0) {
                animator.Play ("Back");
            } else if (moveVertical < 0) {
                animator.Play ("Front");
            } else {
                animator.Play ("Idle");
            }
            */

        if (moveHorizontal > 0)
        {
            animation_type = "Right";
        }
        else if (moveHorizontal < 0)
        {
            animation_type = "Left";
        }
        else if (moveVertical > 0)
        {
            animation_type = "Back";
        }
        else if (moveVertical < 0)
        {
            animation_type = "Front";
        }

        if (spray_controller.isFired() == true)
        {
			animation_type = "front_spray";
        }

        animator.Play(animation_type);
    }
}