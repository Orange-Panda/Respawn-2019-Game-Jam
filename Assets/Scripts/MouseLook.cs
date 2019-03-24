using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pan the camera for first person perspective.
/// </summary>
public class MouseLook : MonoBehaviour
{
	private readonly float lookSensitivity = 2f, lookSmoothDampening = 0.025f;
	private Vector2 rotation, current, rotationVelocity;

	private void OnApplicationFocus(bool focus)
	{
		Cursor.lockState = focus ? CursorLockMode.Locked : CursorLockMode.None;
		Cursor.visible = !focus;
	}

	public Vector2 CurrentRotation
	{
		get
		{
			return new Vector2(current.x, current.y);
		}
	}

	private void LateUpdate()
	{
		rotation.x += Input.GetAxis("Mouse Y") * lookSensitivity;
		rotation.y += Input.GetAxis("Mouse X") * lookSensitivity;

		current.x = Mathf.SmoothDamp(current.x, rotation.x, ref rotationVelocity.x, lookSmoothDampening);
		current.y = Mathf.SmoothDamp(current.y, rotation.y, ref rotationVelocity.y, lookSmoothDampening);

		rotation.x = Mathf.Clamp(rotation.x, -80, 80);

		transform.rotation = Quaternion.Euler(-current.x, current.y, transform.rotation.z);
	}
}
