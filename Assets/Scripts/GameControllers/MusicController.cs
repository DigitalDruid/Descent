using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public static MusicController instance;

    [SerializeField]
	public AudioSource audioSource;

    [SerializeField]
    public AudioClip[] BGM;


    private AudioClip asClip { get { return audioSource.clip; } set { audioSource.clip = value; } }
    /*
    public bool isPlaying {
        get {
            return (GamePreferences.MusicState==1);
        }
        set {
            isPlaying = value;
        }
    }
    */
	// Use this for initialization
	void Awake () {
		MakeSingleton();
        if(!audioSource) audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void MakeSingleton () {
		if (instance != null){
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void PlayMusic (bool play) {
		if (play) {
			if(!audioSource.isPlaying){
                audioSource.Play();
            }
		} else {
            if (audioSource.isPlaying){	audioSource.Stop();	}
		}
    }
    
    public void SetBGMClip() {

        bool musicWasPlaying = audioSource.isPlaying;

        PlayMusic(false);

        switch (GameManager.curScene) {
            case "Credits":
            case "GameOver":
                audioSource.clip = BGM[1]; break;
            case "GamePlay":
            case "GamePlay2":
            case "GamePlay3":
                audioSource.clip = BGM[0]; break;
            case "InbetweenScene":
            case "InbetweenScene2":
            case "EndScene":
                audioSource.clip = BGM[1]; break;
            case "MainMenu":
            case "OptionsMenu":
            case "HighScore":
            case "OpeningCredits":
            case "Shop":
            default:
                audioSource.clip = BGM[2]; break;
        }

        PlayMusic(musicWasPlaying);
    }
}
