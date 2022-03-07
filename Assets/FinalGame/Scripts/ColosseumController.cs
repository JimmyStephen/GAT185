using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColosseumController : Singleton<GameManager>
{
	[SerializeField] GameObject playerPrefab;
	[SerializeField] Transform playerSpawn;

	[SerializeField] GameObject titleScreen;
	[SerializeField] GameObject gameoverScreen;
	[SerializeField] TMP_Text scoreUI;
	[SerializeField] TMP_Text healthUI;

	int score = 0;
	int health = 100;

	public int Score
	{
		get { return score; }
		set
		{
			score = value;
			scoreUI.text = "SCORE: " + score.ToString();
		}
	}

	public int Health
	{
		get { return health; }
		set
		{
			health = value;
			healthUI.text = "HEALTH: " + health.ToString();
		}
	}
}
