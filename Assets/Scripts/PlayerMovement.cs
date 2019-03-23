using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private UnitProperties properties = null;
	private MouseLook mouseLook;
	private Rigidbody rb;

	private bool IsGrounded
	{
		get
		{
			return true;
		}
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		mouseLook = GetComponentInChildren<MouseLook>();
	}

	private void Update()
	{
		CheckForJump();
		CheckForMovement();
	}

	private void FixedUpdate()
	{
		if(Input.GetButton("Crouch"))
		{
			rb.AddForce(0, -properties.fallStrength, 0);
		}
	}

	private void CheckForJump()
	{
		if(Input.GetButtonDown("Jump") && IsGrounded)
		{
			rb.AddForce(0, properties.jumpStrength, 0);
		}
	}

	private void CheckForMovement()
	{
		transform.rotation = Quaternion.Euler(0, mouseLook.CurrentRotation.y, 0);
		Vector3 movement = (Input.GetAxis("Horizontal") * transform.right * properties.speed) + (Input.GetAxis("Vertical") * transform.forward * properties.speed);
		rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
	}
}
