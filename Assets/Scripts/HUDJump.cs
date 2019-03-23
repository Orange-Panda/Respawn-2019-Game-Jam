using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDJump : MonoBehaviour
{
	PlayerMovement player;
	TextMeshProUGUI textMesh;

	private void Start()
	{
		player = FindObjectOfType<PlayerMovement>();
		textMesh = GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
    {
		textMesh.SetText(new string('O', player.GetJumps()));
	}
}
