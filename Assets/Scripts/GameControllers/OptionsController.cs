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
		if(GamePreferences.GetEasyDificulltyState() == 1){
			SetInitialDifficulty("easy");
		}

		if(GamePreferences.GetMediumDificulltyState() == 1){
			SetInitialDifficulty("medium");
		}

		if(GamePreferences.GetHardDificulltyState() == 1){
			SetInitialDifficulty("hard");
		}
	}

	public void EasyDifficlty(){
		GamePreferences.SetEasyDifficultyState (1);
		GamePreferences.SetMediumDifficultyState (0);
		GamePreferences.SetHardDifficultyState (0);

		easySign.SetActive(true);
		mediumSign.SetActive(false);
		hardSign.SetActive(false);
	}

	public void MediumDifficlty(){
		GamePreferences.SetEasyDifficultyState (0);
		GamePreferences.SetMediumDifficultyState (1);
		GamePreferences.SetHardDifficultyState (0);

		easySign.SetActive(false);
		mediumSign.SetActive(true);
		hardSign.SetActive(false);
	}

	public void HardDifficlty(){
		GamePreferences.SetEasyDifficultyState (0);
		GamePreferences.SetMediumDifficultyState (0);
		GamePreferences.SetHardDifficultyState (1);

		easySign.SetActive(false);
		mediumSign.SetActive(false);
		hardSign.SetActive(true);
	}
	
	public void GoBackToMainMenu(){
        //Application.LoadLevel("MainMenu");
        SceneManager.LoadScene("MainMenu");
	}
}
