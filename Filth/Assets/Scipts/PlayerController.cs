using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	[SerializeField] float speed = 1.0f;

	Rigidbody2D rb;
	Animator animator;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void FixedUpdate ()
	{
		// Compute movement.
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		rb.velocity = speed * movement;

		// Animate
		if (moveHorizontal > 0) {
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
	}
}
