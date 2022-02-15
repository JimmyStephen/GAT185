using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RollerGameManager : Singleton<RollerGameManager>
{
	enum State
	{
		TITLE,
		PLAYER_START,
		GAME,
		PLAYER_DEAD,
		GAME_OVER,
		PLAYER_WIN
	}

	[SerializeField] GameObject playerPrefab;
	[SerializeField] Transform playerSpawn;
	[SerializeField] GameObject mainCamera;

	[SerializeField] GameObject titleScreen;
	[SerializeField] GameObject gameLostScreen;
	[SerializeField] GameObject gameWonScreen;
	[SerializeField] TMP_Text scoreUI;
	[SerializeField] TMP_Text livesUI;
	[SerializeField] TMP_Text timeUI;
	[SerializeField] Slider healthBarUI;
	public float playerHealth { set { healthBarUI.value = value; } }

	public delegate void GameEvent();

	public event GameEvent startGameEvent;
	public event GameEvent stopGameEvent;

	int score = 0;
	int lives = 0;
	State state = State.TITLE;
	float stateTimer;
	float gameTimer = 0;

	public int Score
	{
		get { return score; }
		set
		{
			score = value;
			scoreUI.text = "SCORE: " + score.ToString("D2");
		}
	}
	public int Lives
	{
		get { return lives; }
		set
		{
			lives = value;
			livesUI.text = "LIVES: " + lives.ToString("D2");
		}
	}
	public float GameTime
	{
		get { return gameTimer; }
		set
		{
			gameTimer = value;
			timeUI.text = "<mspace=mspace=36>" + gameTimer.ToString("0.0") + "</mspace>";
		}
	}


	private void Update()
    {
		stateTimer -= Time.deltaTime;

        switch (state)
        {
            case State.TITLE:
                break;
            case State.PLAYER_START:
				DestroyAllEnemies();
				Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
				mainCamera.SetActive(false);
				startGameEvent?.Invoke();
				state = State.GAME;
				GameTime = 60;
				break;
            case State.GAME:
				GameTime -= Time.deltaTime;
				if(GameTime <= 0)
                {
					OnGameEnd(false);
                }
				if(Score >= 25)
                {
					OnGameEnd(true);
                }
                break;
            case State.PLAYER_DEAD:
				mainCamera.SetActive(true);
				if (stateTimer <= 0)
                {
					state = State.PLAYER_START;
                }
                break;
            case State.GAME_OVER:
				if (stateTimer <= 0)
				{
					state = State.TITLE;
					gameLostScreen.SetActive(false);
					//SceneManager.LoadScene("RollerBall");
					titleScreen.SetActive(true);
				}
				break;
			case State.PLAYER_WIN:
				if (stateTimer <= 0)
				{
					state = State.TITLE;
					gameWonScreen.SetActive(false);
					//SceneManager.LoadScene("RollerBall");
					titleScreen.SetActive(true);
				}
				break;
            default:
                break;
        }
    }

	public void OnGameEnd(bool playerWin)
    {
		GameTime = 0;
		mainCamera.SetActive(true);
		if (playerWin)
        {
			gameWonScreen.SetActive(true);
			Destroy(FindObjectOfType<RollerPlayer>().transform.root.gameObject);
			state = State.PLAYER_WIN;
        }
        else
        {
			gameLostScreen.SetActive(true);
			state = State.GAME_OVER;
			var playerTemp = FindObjectOfType<RollerPlayer>();
			if (playerTemp)
			{
				Destroy(playerTemp.transform.root.gameObject);
			}
		}
		stateTimer = 5;
	}

    public void OnStartGame()
	{
		state = State.PLAYER_START;
		Score = 0;
		Lives = 1;
		gameTimer = 0;

		titleScreen.SetActive(false);
	}

	public void OnStartTitle()
	{
		state = State.TITLE;
		titleScreen.SetActive(true);
		stopGameEvent?.Invoke();
	}

	public void OnPlayerDead()
    {
		Lives -= 1;
		if (lives <= 0)
		{
			mainCamera.SetActive(true);
			state = State.GAME_OVER;
			stateTimer = 5;
			GameTime = 0;
			gameLostScreen.SetActive(true);
        }
		stopGameEvent?.Invoke();
	}

	private void DestroyAllEnemies()
	{
		// destroy all enemies
/*		var spaceEnemies = FindObjectsOfType<SpaceEnemy>();
		foreach (var spaceEnemy in spaceEnemies)
		{
			Destroy(spaceEnemy.gameObject);
		}*/
	}
}
