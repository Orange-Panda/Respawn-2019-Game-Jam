using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BilboardText : MonoBehaviour
{
	TextMeshPro textMesh;

	PlayerMovement player;

	List<string> textEntries = new List<string>()
	{
		"My king! You made it back from your travels!\nBut in your haste, you forgot your wings...\nYou must gather your feathers to get back to the castle before dusk!",
		"I see you have found the first component of your wings.\nTry giving it a shot by pressing the jump button while in the air!",
		"Great the second component!\nKeep this up and you will be back home in no time.",
		"You might need a few more components before going to the castle.",
		"Your wings are coming together nicely.\nI do believe you are missing the final component.",
		"Your wings are looking lovely my king.\nI believe you are ready to approach the castle."
	};

	private string fallbackText = "Your wings are looking, different...";


	// Start is called before the first frame update
    void Start()
    {
		textMesh = GetComponent<TextMeshPro>();
		player = FindObjectOfType<PlayerMovement>();
	}

    // Update is called once per frame
    void Update()
    {
		textMesh.SetText(player.GetMaxJumps() < textEntries.Count ? textEntries[player.GetMaxJumps()] : fallbackText);
	}
}
