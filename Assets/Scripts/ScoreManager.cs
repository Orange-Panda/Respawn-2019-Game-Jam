using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	TextMeshProUGUI textMesh;
	public static int Score
	{
		get;
		private set;
	}
	private int displayScore;


	// Start is called before the first frame update
    void Start()
    {
		textMesh = GetComponent<TextMeshProUGUI>();
    }

	private void FixedUpdate()
	{
		if(displayScore != Score)
		{
			displayScore = (displayScore > Score) ? Mathf.FloorToInt(Mathf.Lerp(displayScore, Score, 0.1f)) : Mathf.CeilToInt(Mathf.Lerp(displayScore, Score, 0.025f));
			textMesh.color = (displayScore > Score) ? Color.red: Color.green;
		}
		else
		{
			textMesh.color = Color.white;
		}
		textMesh.SetText(displayScore == 0 ? " " : displayScore.ToString());
	}

	public static void AddScore(int value)
	{
		Score += value;
	}
}
