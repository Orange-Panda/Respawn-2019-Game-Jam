using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToFinale : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<PlayerMovement>())
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Finale");
		}
	}
}
