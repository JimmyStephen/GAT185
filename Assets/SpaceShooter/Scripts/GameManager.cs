using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
	enum State
	{
		TITLE,
		GAME
	}

	[SerializeField] GameObject playerPrefab;
	[SerializeField] Transform playerSpawn;
	[SerializeField] GameObject titleScreen;
	[SerializeField] TMP_Text scoreUI;
	[SerializeField] TMP_Text healthUI;

	public delegate void GameEvent();

	public event GameEvent startGameEvent;
	public event GameEvent stopGameEvent;

	int score = 0;
	float healthUIF = 100;
	State state = State.TITLE;

	public int Score
	{
		get { return score; }
		set
		{
			score = value;
			scoreUI.text = score.ToString();
		}
	}

	public float Health
	{
		get { return healthUIF; }
		set
		{
			healthUIF = value;
			healthUI.text = healthUIF.ToString();
		}
	}


	public int Lives { get; set; }



	public void OnStartGame()
	{
		state = State.GAME;
		titleScreen.SetActive(false);
		score = 0;
		scoreUI.text = score.ToString();
		healthUIF = 100;
		healthUI.text = healthUIF.ToString();
		Instantiate(playerPrefab, playerSpawn);

		startGameEvent?.Invoke();
	}

	public void OnStartTitle()
	{
		state = State.TITLE;
		titleScreen.SetActive(true);
		stopGameEvent();
	}

}
