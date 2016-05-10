using UnityEngine;
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
		if (GamePreferences.GetMusicState () ==1){
			MusicController.instance.PlayMusic(true);
			musicBtn.image.sprite = musicIcons [1];
		} else{
			MusicController.instance.PlayMusic(false);
			musicBtn.image.sprite = musicIcons [0];
		}
	}
	
	public void StartGame(){
		GameManager.instance.gameStartedFromMainMenu = true;
//		Application.LoadLevel("GamePlay");
		SceneFader.instance.LoadLevel("GamePlay");
	}

	public void HighScore(){
		Application.LoadLevel("HighScore");
	}

	public void Options(){
		Application.LoadLevel("OptionsMenu");
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void MusicButton(){
		if (GamePreferences.GetMusicState () == 0) {
			GamePreferences.SetMusicState(1);
			MusicController.instance.PlayMusic(true);
			musicBtn.image.sprite = musicIcons[1];
		} else if (GamePreferences.GetMusicState() == 1){
			GamePreferences.SetMusicState(0);
			MusicController.instance.PlayMusic(false);
			musicBtn.image.sprite = musicIcons[0];
		}
	}
}
