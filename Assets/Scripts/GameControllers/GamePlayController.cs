﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	[SerializeField]
	public Text scoreText, coinScoreText, /*lifeText,*/ gameOverScoreText, gameOverCoinText;

	[SerializeField]
	public GameObject pausePanel, gameOverPanel, endStageGroup, readyButton;

    public bool isReady { get { return readyButton.activeInHierarchy; } }
	// Use this for initialization
	void Awake () {
		MakeInstance();
	}

	void Start(){
		Time.timeScale = 0f;
	}
	
	void MakeInstance(){
		if (instance == null) { instance = this; }
	}

	public void GameOverShowPanel(int finalScore, int finalCoinScore){
		gameOverPanel.SetActive(true);
		gameOverScoreText.text = finalScore.ToString();
		gameOverCoinText.text = finalCoinScore.ToString();
		StartCoroutine (GameOverLoadMainMenu());
	}

	IEnumerator GameOverLoadMainMenu(){
		yield return new WaitForSeconds (3f);
		SceneFader.instance.LoadLevel(LevelController.instance.MainMenu);
	}

	public void PlayerDiedRestartTheGame(){
		StartCoroutine (PlayerDiedRestart());
	}

	IEnumerator PlayerDiedRestart(){
		yield return new WaitForSeconds (1f);
		SceneFader.instance.LoadLevel(GameManager.curScene);
	}

    public void SetScore(int scr) {     scoreText.text = "x" + scr; }
    public void SetCoinScore(int scr) {  coinScoreText.text = "x" + scr; }
    //public void SetLifeScore(int scr) {  lifeText.text = (scr>0)? "x" + scr : "x0"; }

	public void PauseTheGame() {
		Time.timeScale = 0f;
		pausePanel.SetActive(true);
	}

	public void ResumeGame() {
		Time.timeScale = 1f;
		pausePanel.SetActive(false);
	}

	public void QuitGame() {
		Time.timeScale = 1f;
		SceneFader.instance.LoadLevel(LevelController.instance.MainMenu);
    }

	public void ReadyToStartGame() {
		Time.timeScale = 1f;
		readyButton.SetActive(false);
	}

    void Update() {
        if (PlayerScore.Score >= 0){
            endStageGroup.SetActive(true);
            var pos = endStageGroup.transform.position;
            pos.Set(pos.x, pos.y - 10, pos.z);
            //endStageGroup.transform.position = pos;
        }
    }
}
