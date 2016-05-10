using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

	[SerializeField]
	private Text scoreText, coinText;

	// Use this for initialization
	void Start () {
		SetTheScoreBasedOnDifficulty();
	}

	void SetScore(int score, int coinScore){
		scoreText.text = score.ToString();
		coinText.text = coinScore.ToString();
	}

	void SetTheScoreBasedOnDifficulty(){
		if(GamePreferences.GetEasyDificulltyState () == 1){
			SetScore(GamePreferences.GetEasyDificulltyHighScoreState(), GamePreferences.GetEasyDificulltyCoinScoreState());
		}

		if(GamePreferences.GetMediumDificulltyState () == 1){
			SetScore(GamePreferences.GetMediumDificulltyHighScoreState(), GamePreferences.GetMediumDificulltyCoinScoreState());
		}

		if(GamePreferences.GetHardDificulltyState () == 1){
			SetScore(GamePreferences.GetHardDificulltyHighScoreState(), GamePreferences.GetHardDifficultyCoinScoreState());
		}
	}
	
	public void GoBackToMainMenu(){
		Application.LoadLevel("MainMenu");
	}
}
