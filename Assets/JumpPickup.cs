using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPickup : MonoBehaviour
{
	private Light childLight;
	private Color targetColor, color;
	private Material material;
	public GameObject pickupEffect;

	// Start is called before the first frame update
    void Start()
    {
		childLight = GetComponentInChildren<Light>();
		StartCoroutine(RandomizeColor());
		material = GetComponent<Renderer>().material;
    }

	IEnumerator RandomizeColor()
	{
		while(gameObject.activeSelf)
		{
			targetColor = Random.ColorHSV(0, 1, 1, 1, 1, 1);
			yield return new WaitForSeconds(0.25f);
		}
	}

	private void Update()
	{
		color = Color.Lerp(color, targetColor, 0.1f);
		childLight.color = color;
		material.color = color;
	}

	private void OnTriggerEnter(Collider other)
	{
		PlayerMovement player;
		if (player = other.GetComponent<PlayerMovement>())
		{
			player.AddJump();
			Instantiate(pickupEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
