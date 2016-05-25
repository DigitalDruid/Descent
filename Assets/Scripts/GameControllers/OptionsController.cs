using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OptionsController : MonoBehaviour {

	[SerializeField]
	public GameObject easySign, mediumSign, hardSign;
    
	void Start() {
		SetDifficulty(GamePreferences.DifficultyState);
	}

	void SetDifficulty (string difficulty) {
		switch (difficulty){
			case GamePreferences.EasyDifficulty:
				mediumSign.SetActive(false);
				hardSign.SetActive(false);
				break;
			case GamePreferences.MediumDifficulty:
				easySign.SetActive(false);
				hardSign.SetActive(false);
				break;
			case GamePreferences.HardDifficulty:
				easySign.SetActive(false);
				mediumSign.SetActive(false);
				break;
		}
	}

	public void EasyDifficulty() {
        GamePreferences.DifficultyState = GamePreferences.EasyDifficulty;
		easySign.SetActive(true);
		mediumSign.SetActive(false);
		hardSign.SetActive(false);
	}

	public void MediumDifficulty() {
        GamePreferences.DifficultyState = GamePreferences.MediumDifficulty;
		easySign.SetActive(false);
		mediumSign.SetActive(true);
		hardSign.SetActive(false);
	}

	public void HardDifficulty() {
        GamePreferences.DifficultyState = GamePreferences.HardDifficulty;
		easySign.SetActive(false);
		mediumSign.SetActive(false);
		hardSign.SetActive(true);
	}
	
	public void GoBackToMainMenu() {
        //SceneManager.LoadScene("MainMenu");
        SceneFader.instance.LoadLevel("MainMenu");
	}
}
