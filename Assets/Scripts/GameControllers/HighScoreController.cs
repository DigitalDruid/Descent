using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

	[SerializeField]
	public Text scoreText, coinText;

	// Use this for initialization
	void Start () {
		SetTheScoreBasedOnDifficulty();
	}

	void SetScore(int score, int coinScore){
		scoreText.text = score.ToString();
		coinText.text = coinScore.ToString();
	}

	void SetTheScoreBasedOnDifficulty(){
		if(GamePreferences.EasyDifficultyState == 1){
			SetScore(GamePreferences.EasyDifficultyHighScoreState, GamePreferences.EasyDifficultyCoinScoreState);
		}

		if(GamePreferences.MediumDifficultyState == 1){
			SetScore(GamePreferences.MediumDifficultyHighScoreState, GamePreferences.MediumDifficultyCoinScoreState);
		}

		if(GamePreferences.HardDifficultyState == 1){
			SetScore(GamePreferences.HardDifficultyHighScoreState, GamePreferences.HardDifficultyCoinScoreState);
		}
	}
	
	public void GoBackToMainMenu(){
        //Application.LoadLevel("MainMenu");
        SceneManager.LoadScene("MainMenu");
	}
}
