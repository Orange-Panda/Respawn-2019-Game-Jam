using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDJump : MonoBehaviour
{
	PlayerMovement player;
	Image image;

	public Sprite basicWings;
	public List<Sprite> wings;

	private Color originalColor;
	public Color emptyColor = Color.black;

	private Vector3 originalScale;
	private Vector3 targetScale
	{
		get
		{
			return originalScale * (1 + (0.075f * player.GetJumps()));
		}
	}

	private void Start()
	{
		player = FindObjectOfType<PlayerMovement>();
		image = GetComponent<Image>();
		image.sprite = basicWings;
		originalColor = image.color;
		originalScale = image.rectTransform.localScale;
	}

	// Update is called once per frame
	void Update()
    {
		int jumps = player.GetJumps();
		if (jumps < wings.Count)
		{
			image.sprite = wings[jumps];
		}
		else
		{
			image.sprite = basicWings;
		}

		image.rectTransform.localScale = Vector3.Lerp(image.rectTransform.localScale, targetScale, 0.1f);

		image.color = jumps == 0 ? emptyColor : originalColor;
	}
}
