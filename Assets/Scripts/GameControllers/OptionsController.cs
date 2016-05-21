using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OptionsController : MonoBehaviour {

	[SerializeField]
	public GameObject easySign, mediumSign, hardSign;

	// Use this for initialization
	void Start () {
		SetTheDifficulty();
	}

	void SetInitialDifficulty(string difficulty){
		switch (difficulty){
			case "easy":
				mediumSign.SetActive(false);
				hardSign.SetActive(false);
				break;

			case "medium":
				easySign.SetActive(false);
				hardSign.SetActive(false);
				break;

			case "hard":
				easySign.SetActive(false);
				mediumSign.SetActive(false);
				break;
		}
	}

	void SetTheDifficulty(){
		if(GamePreferences.EasyDifficultyState == 1){
			SetInitialDifficulty("easy");
		}

		if(GamePreferences.MediumDifficultyState == 1){
			SetInitialDifficulty("medium");
		}

		if(GamePreferences.HardDifficultyState == 1){
			SetInitialDifficulty("hard");
		}
	}

	public void EasyDifficlty(){
        GamePreferences.EasyDifficultyState = 1;
        GamePreferences.MediumDifficultyState = 0;
        GamePreferences.HardDifficultyState = 0;

		easySign.SetActive(true);
		mediumSign.SetActive(false);
		hardSign.SetActive(false);
	}

	public void MediumDifficlty(){
        GamePreferences.EasyDifficultyState = 0;
        GamePreferences.MediumDifficultyState = 1;
        GamePreferences.HardDifficultyState = 0;

		easySign.SetActive(false);
		mediumSign.SetActive(true);
		hardSign.SetActive(false);
	}

	public void HardDifficlty(){
        GamePreferences.EasyDifficultyState = 0;
        GamePreferences.MediumDifficultyState = 0;
        GamePreferences.HardDifficultyState = 1;

		easySign.SetActive(false);
		mediumSign.SetActive(false);
		hardSign.SetActive(true);
	}
	
	public void GoBackToMainMenu(){
        //Application.LoadLevel("MainMenu");
        SceneManager.LoadScene("MainMenu");
	}
}
