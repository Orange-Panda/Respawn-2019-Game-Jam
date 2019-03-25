using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		PlayerMovement player;
		if (player = collision.gameObject.GetComponent<PlayerMovement>())
		{
			player.GiveMaxJumps();
		}
	}
}
