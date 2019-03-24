using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages player movement input and execution.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private UnitProperties properties = null;
	private MouseLook mouseLook;
	private Rigidbody rb;
	private AudioSource audioSource;
	private float colliderDistance;
	private float currentSpeed;
	private int jumpsLeft;
	private bool controlEnabled = true;
	private Collider[] colliders;
	private int maxJumps;
	private bool isGrounded;

	internal void AddJump()
	{
		maxJumps++;
	}

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

	public int GetJumps()
	{
		return jumpsLeft;
	}

	public int GetMaxJumps()
	{
		return maxJumps;
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		mouseLook = GetComponentInChildren<MouseLook>();
		colliderDistance = GetComponent<Collider>().bounds.extents.y;
		colliders = GetComponentsInChildren<Collider>();
		StartCoroutine(RegainJumps());
		audioSource = GetComponent<AudioSource>();
		currentSpeed = properties.walkSpeed;
		maxJumps = properties.jumps;
	}

	private void Update()
	{
		if(controlEnabled)
		{
			CheckForJump();
			CheckForMovement();
		}
	}

	private void FixedUpdate()
	{
		currentSpeed = Mathf.Lerp(currentSpeed, isGrounded ? properties.walkSpeed : properties.airSpeed, 0.1f);
		isGrounded = Physics.Raycast(transform.position, -Vector3.up, colliderDistance + 0.1f); ;
	}

	IEnumerator RegainJumps()
	{
		while(true)
		{
			if (isGrounded && jumpsLeft < maxJumps && controlEnabled)
			{
				jumpsLeft++;
				audioSource.PlayOneShot(properties.jumpRecoverySound);
				yield return new WaitForSeconds(properties.jumpRecoveryTime);
			}
			else
			{
				yield return null;
			}
		}
	}

	private void CheckForJump()
	{
		if(Input.GetButtonDown("Jump"))
		{
			if(jumpsLeft > 0 && !isGrounded)
			{
				audioSource.PlayOneShot(properties.airJumpSound);
				jumpsLeft--;
				StartCoroutine(Jump());
			}
			else if(isGrounded)
			{
				StartCoroutine(Jump());
			}
			else
			{
				audioSource.PlayOneShot(properties.noJumpsSound);
			}
		}
	}

	private void CheckForMovement()
	{
		transform.rotation = Quaternion.Euler(0, mouseLook.CurrentRotation.y, 0);
		Vector3 horizontal = Input.GetAxis("Horizontal") * transform.right * currentSpeed;
		Vector3 vertical = Input.GetAxis("Vertical") * transform.forward * currentSpeed;
		Vector3 movement = horizontal + vertical;
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
