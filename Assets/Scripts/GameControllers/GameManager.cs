using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[HideInInspector]
	public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

	[HideInInspector]
	public int score, coinScore, lifeScore;

	// Use this for initialization
	void Awake () {
		MakeSingleton();
	}

	void Start(){
		IntializeVariables();
	}

	void OnLevelWasLoaded(){
		if (Application.loadedLevelName == "GamePlay"){
			if (gameRestartedAfterPlayerDied){
				GamePlayController.instance.SetScore(score);
				GamePlayController.instance.SetCoinScore(coinScore);
				GamePlayController.instance.SetLifeScore(lifeScore);

				PlayerScore.scoreCount = score;
				PlayerScore.coinCount = coinScore;
				PlayerScore.lifeCount = lifeScore;
			} else if (gameStartedFromMainMenu) {
				PlayerScore.coinCount = 0;
				PlayerScore.scoreCount = 0;
				PlayerScore.lifeCount = 2;

				GamePlayController.instance.SetScore(0);
				GamePlayController.instance.SetCoinScore(0);
				GamePlayController.instance.SetLifeScore(2);

			}
		}
	}

	void IntializeVariables(){

		if(!PlayerPrefs.HasKey("Game Initialized")){
			GamePreferences.SetEasyDifficultyState(0);
			GamePreferences.SetEasyDifficultyCoinScoreState(0);
			GamePreferences.SetEasyDifficultyHighScoreState(0);

			GamePreferences.SetMediumDifficultyState(1);
			GamePreferences.SetMediumDifficultyCoinScoreState(0);
			GamePreferences.SetMediumDifficultyHighScoreState(0);

			GamePreferences.SetHardDifficultyState(0);
			GamePreferences.SetHardDifficultyCoinScoreState(0);
			GamePreferences.SetHardDifficultyHighScoreState(0);

			GamePreferences.SetMusicState(0);

			PlayerPrefs.SetInt("Game Initialized", 123);
		}

	}

	void MakeSingleton(){
		if (instance != null){
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void CheckGameStatus (int score, int coinScore, int lifeScore){
		if (lifeScore < 0){

			if(GamePreferences.GetEasyDificulltyState() == 1){
				int highScore = GamePreferences.GetEasyDificulltyHighScoreState();
				int coinHighScore = GamePreferences.GetEasyDificulltyCoinScoreState();

				if (highScore < score) {
					GamePreferences.SetEasyDifficultyHighScoreState(score);

				}

				if (coinHighScore < coinScore){
					GamePreferences.SetEasyDifficultyCoinScoreState(coinScore);
				}
			}

			if(GamePreferences.GetMediumDificulltyState() == 1){
				int highScore = GamePreferences.GetMediumDificulltyHighScoreState();
				int coinHighScore = GamePreferences.GetMediumDificulltyCoinScoreState();

				if (highScore < score) {
					GamePreferences.SetMediumDifficultyHighScoreState(score);

				}

				if (coinHighScore < coinScore){
					GamePreferences.SetMediumDifficultyCoinScoreState(coinScore);
				}
			}


			if(GamePreferences.GetHardDificulltyState() == 1){
				int highScore = GamePreferences.GetHardDificulltyHighScoreState();
				int coinHighScore = GamePreferences.GetHardDifficultyCoinScoreState();

				if (highScore < score) {
					GamePreferences.SetHardDifficultyHighScoreState(score);

				}

				if (coinHighScore < coinScore){
					GamePreferences.SetHardDifficultyCoinScoreState(coinScore);
				}
			}


			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDied = false;

			GamePlayController.instance.GameOverShowPanel(score, coinScore);

		} else {

			this.score = score;
			this.coinScore = coinScore;
			this.lifeScore = lifeScore;

			gameRestartedAfterPlayerDied = true;
			gameStartedFromMainMenu = false;

			GamePlayController.instance.PlayerDiedRestartTheGame();

		}
	}
}
