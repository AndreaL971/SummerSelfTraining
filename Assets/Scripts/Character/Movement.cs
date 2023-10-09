using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private Animator animator;
	Rigidbody rb;
	[SerializeField]
	float speed = 15;
	[SerializeField]
	float jumpForce = 4.5f;

	bool isOnGround = true;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		float movement = Input.GetAxis("Horizontal");

		Vector3 move = new Vector3(movement, 0, 0) * speed * Time.deltaTime;

		rb.MovePosition(transform.position + move);

		if (movement != 0)
		{
			Vector3 moveDirection = new Vector3(movement, 0, 0).normalized;
			transform.LookAt(transform.position + moveDirection);
			animator.SetBool("isMoving", true);
		}
		else
		{
			animator.SetBool("isMoving", false);
		}

		if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
		{
			animator.SetBool("isJumping", true);
			isOnGround = false;
			rb.AddForce(new Vector3(movement, jumpForce, 0), ForceMode.Impulse);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Ground")
		{
			isOnGround = true;
			animator.SetBool("isJumping", false);
		}
			
	}
} 