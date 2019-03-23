using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			StartCoroutine(ResetPosition(other));
		}
	}

	IEnumerator ResetPosition(Collider other)
	{
		PlayerMovement player = other.GetComponent<PlayerMovement>();
		GameObject respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
		Rigidbody rigidbody = player.GetComponent<Rigidbody>();

		player.SetEnabled(false);

		for(int i = 0; i < 40; i++)
		{
			player.transform.position = Vector3.Lerp(player.transform.position, respawnPoint.transform.position, 0.1f);
			rigidbody.velocity = new Vector3(0, 0, 0);
			yield return null;
		}

		player.SetEnabled(true);
	}
}
