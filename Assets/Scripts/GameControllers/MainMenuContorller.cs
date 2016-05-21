using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenuContorller : MonoBehaviour {

	[SerializeField]
	private Button musicBtn;

	[SerializeField]
	private Sprite[] musicIcons;

	// Use this for initialization
	void Start () {
		CheckToPlayMusic();
	}

	void CheckToPlayMusic(){
		if (GamePreferences.MusicState == 1){
			MusicController.instance.PlayMusic(true);
			musicBtn.image.sprite = musicIcons [1];
		} else{
			MusicController.instance.PlayMusic(false);
			musicBtn.image.sprite = musicIcons [0];
		}
	}
	
	public void StartGame(){
		GameManager.instance.gameStartedFromMainMenu = true;
       // GameManager.instance.SyncScores(0, 0, 2);
		SceneFader.instance.LoadLevel("GamePlay");
	}

	public void HighScore(){
        SceneManager.LoadScene("HighScore");
	}

	public void Options(){
        SceneManager.LoadScene("OptionsMenu");
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void MusicButton(){
		if (GamePreferences.MusicState == 0) {
            GamePreferences.MusicState = 1;
			MusicController.instance.PlayMusic(true);
			musicBtn.image.sprite = musicIcons[1];
		} else if (GamePreferences.MusicState == 1){
            GamePreferences.MusicState = 0;
			MusicController.instance.PlayMusic(false);
			musicBtn.image.sprite = musicIcons[0];
		}
	}
}
