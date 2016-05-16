using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	[SerializeField]
	private Text scoreText, coinScoreText, lifeText, gameOverScoreText, gameOverCoinText;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel, endStageGroup;

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
		SceneFader.instance.LoadLevel(GameManager.curScene);
	}

    public void SetScore(int scr) {     scoreText.text = "x" + scr; }
    public void SetCoinScore(int scr){  coinScoreText.text = "x" + scr; }
    public void SetLifeScore(int scr){  lifeText.text = "x" + scr; }

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
		SceneFader.instance.LoadLevel("MainMenu");
	}

	public void ReadyToStartGame(){
		Time.timeScale = 1f;
		readyButton.SetActive(false);
	}
}
