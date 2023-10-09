using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject projectilePrefab;
	public Transform projectileStartingPoint;
	[SerializeField]
	private float projectileSpeed = 10f;
	private Animator animator;
	Rigidbody rb;
	public int hp = 100;
	public GameObject menuScreen;
	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!menuScreen.activeSelf)
			{
				menuScreen.SetActive(true);
				Time.timeScale = 0;
				Cursor.lockState = CursorLockMode.Confined;
				Cursor.visible = true;
			}
			else
			{
				menuScreen.SetActive(false);
				Time.timeScale = 1;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
		}
		if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Standing Idle"))
		{
			animator.SetBool("isShooting", false);
		}
		if (!menuScreen.activeSelf)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				Shoot();
				animator.SetBool("isShooting", true);
			}
		}
	}

	public void TakeDamage(int amount)
	{
		hp -= amount;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Enemy")
		{
			TakeDamage(10);
			rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
		}
	}

	public void Shoot()
	{
		GameObject projectile = Instantiate(projectilePrefab, projectileStartingPoint.position, Quaternion.Euler(0, 0, 90));
		rb = projectile.GetComponent<Rigidbody>();
		rb.AddForce(projectileStartingPoint.forward * projectileSpeed, ForceMode.Impulse);
	}
}
