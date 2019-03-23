using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private UnitProperties properties = null;
	private MouseLook mouseLook;
	private Rigidbody rb;
	private float colliderDistance;
	private int jumpsLeft;
	private bool controlEnabled = true;
	private Collider[] colliders;

	public void SetEnabled(bool value)
	{
		foreach(Collider collider in colliders)
		{
			collider.enabled = value;
		}
		controlEnabled = value;
	}

	public bool GetEnabled()
	{
		return controlEnabled;
	}

	private bool IsGrounded
	{
		get
		{
			return Physics.Raycast(transform.position, -Vector3.up, colliderDistance + 0.1f);
		}
	}

	public int GetJumps()
	{
		return jumpsLeft;
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		mouseLook = GetComponentInChildren<MouseLook>();
		colliderDistance = GetComponent<Collider>().bounds.extents.y;
		colliders = GetComponentsInChildren<Collider>();
		StartCoroutine(RegainJumps());
	}

	private void Update()
	{
		if(controlEnabled)
		{
			CheckForJump();
			CheckForMovement();
		}
	}

	IEnumerator RegainJumps()
	{
		while(true)
		{
			if (IsGrounded && jumpsLeft < properties.jumps && controlEnabled)
			{
				jumpsLeft++;
				yield return new WaitForSeconds(0.25f);
			}
			else
			{
				yield return null;
			}
		}
	}

	private void CheckForJump()
	{
		if(Input.GetButtonDown("Jump") && jumpsLeft > 0)
		{
			if (!IsGrounded)
			{
				jumpsLeft--;
			}
			StartCoroutine(Jump());
		}
	}

	private void CheckForMovement()
	{
		transform.rotation = Quaternion.Euler(0, mouseLook.CurrentRotation.y, 0);
		Vector3 movement = (Input.GetAxis("Horizontal") * transform.right * properties.speed) + (Input.GetAxis("Vertical") * transform.forward * properties.speed);
		rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
	}

	private IEnumerator Jump()
	{
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / 10, rb.velocity.z);

		int jumpsDone = 0;
		while (jumpsDone < 7 && Input.GetButton("Jump") && controlEnabled)
		{
			jumpsDone++;
			rb.AddForce(0, properties.jumpStrength / (jumpsDone), 0);
			yield return new WaitForFixedUpdate();
		}

		if(!Input.GetButton("Jump") && controlEnabled)
		{
			rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / 4, rb.velocity.z);
		}

		yield break;
	}
}
