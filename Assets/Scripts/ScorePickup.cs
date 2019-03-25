using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : MonoBehaviour
{
	public GameObject pickupEffect;

	private void OnTriggerEnter(Collider other)
	{
		PlayerMovement player;
		if (player = other.GetComponent<PlayerMovement>())
		{
			Instantiate(pickupEffect, transform.position, transform.rotation);
			ScoreManager.AddScore(125);
			Destroy(gameObject);
		}
	}
}
