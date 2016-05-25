using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

	[SerializeField]
	public Text scoreText, coinText;

	// Use this for initialization
	void Start() {
        SetScore(GamePreferences.HighScoreState, GamePreferences.CoinScoreState);
        // scoreText.text = GamePreferences.HighScoreState.ToString();
        // coinText.text = GamePreferences.CoinScoreState.ToString();
	}

	void SetScore (int score, int coinScore) {
		scoreText.text = score.ToString();
		coinText.text = coinScore.ToString();
	}
    
    public void GoBackToMainMenu() { /*SceneManager.LoadScene("MainMenu");*/ GameManager.instance.loadLevel("MainMenu"); }
}
