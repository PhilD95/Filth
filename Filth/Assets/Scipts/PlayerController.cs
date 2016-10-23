using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

	public float speed = 1.0f;

	Rigidbody2D rb;
	Animator animator;

	SprayController sprayController;

	void Start ()
	{
		GameObject gameController = GameObject.FindWithTag("GameController");
		sprayController = gameController.GetComponent<SprayController>();

		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void FixedUpdate ()
	{
		// Compute movement
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		rb.velocity = speed * movement;

		// Determine animation
		string animation_type = "Idle";
		if (moveHorizontal > 0) {
			animation_type = "Right";
		} else if (moveHorizontal < 0) {
			animation_type = "Left";
		} else if (moveVertical > 0) {
			animation_type = "Back";
		} else if (moveVertical < 0) {
			animation_type = "Front";
		}

		if (sprayController.isFired() == true) {
			animation_type = "front_spray";
		}

		animator.Play(animation_type);
	}
}