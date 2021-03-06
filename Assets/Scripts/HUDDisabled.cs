﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Draws the disabled HUD icon.
/// </summary>
public class HUDDisabled : MonoBehaviour
{
	Image image;
	PlayerMovement player;

	private void Start()
	{
		image = GetComponent<Image>();
		player = FindObjectOfType<PlayerMovement>();
	}

	private void Update()
	{
		if(player.GetEnabled())
		{
			image.enabled = false;
		}
		else
		{
			image.enabled = true;
		}
	}
}
