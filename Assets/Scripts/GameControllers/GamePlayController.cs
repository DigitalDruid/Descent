using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	[SerializeField]
	private Text scoreText, coinScoreText, lifeText, gameOverScoreText, gameOverCoinText;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel;

	[SerializeField]
	private GameObject readyButton;


	// Use this for initialization
	void Awake () {
		MakeInstance();
	}

	void Start(){
		Time.timeScale = 0f;
	}
	
	void MakeInstance(){
		if (instance == null){
			instance = this;
		}
	}

	public void GameOverShowPanel(int finalScore, int finalCoinScore){
		gameOverPanel.SetActive(true);
		gameOverScoreText.text = finalScore.ToString();
		gameOverCoinText.text = finalCoinScore.ToString();
		StartCoroutine (GameOverLoadMainMenu());
	}

	IEnumerator GameOverLoadMainMenu(){
		yield return new WaitForSeconds (3f);
		SceneFader.instance.LoadLevel("MainMenu");
	}

	public void PlayerDiedRestartTheGame(){
		StartCoroutine (PlayerDiedRestart());
	}

	IEnumerator PlayerDiedRestart(){
		yield return new WaitForSeconds (1f);
		SceneFader.instance.LoadLevel("GamePlay");
	}

	public void SetScore(int score){
		scoreText.text = "x" + score;
	}

	public void SetCoinScore(int coinScore){
		coinScoreText.text = "x" + coinScore;
	}

	public void SetLifeScore(int lifeScore){
		lifeText.text = "x" + lifeScore;
	}

	public void PauseTheGame(){
		Time.timeScale = 0f;
		pausePanel.SetActive(true);
	}

	public void ResumeGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive(false);
	}

	public void QuitGame(){
		Time.timeScale = 1f;
//		Application.LoadLevel("MainMenu");
		SceneFader.instance.LoadLevel("MainMenu");
	}

	public void ReadyToStartGame(){
		Time.timeScale = 1f;
		readyButton.SetActive(false);
	}
}
