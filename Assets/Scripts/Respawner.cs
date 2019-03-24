using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// If the player falls off the map, reset their position to the starting point.
/// </summary>
public class Respawner : MonoBehaviour
{
	public Vector3 desitnation;

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			ScoreManager.AddScore(Mathf.CeilToInt(Mathf.Abs(ScoreManager.Score) * -0.1f) - 15);
			StartCoroutine(ResetPosition(other));
		}
	}

	IEnumerator ResetPosition(Collider other)
	{
		PlayerMovement player = other.GetComponent<PlayerMovement>();
		Rigidbody rigidbody = player.GetComponent<Rigidbody>();

		player.SetEnabled(false);

		for(int i = 0; i < 60; i++)
		{
			player.transform.position = Vector3.Lerp(player.transform.position, desitnation, 0.125f);
			rigidbody.velocity = new Vector3(0, 0, 0);
			yield return null;
		}

		player.SetEnabled(true);
	}
}
