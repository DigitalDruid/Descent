using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public static MusicController instance;

	private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
		MakeSingleton();
		audioSource = GetComponent<AudioSource> ();
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

	public void PlayMusic(bool play){
		if (play) {
			if(!audioSource.isPlaying){
				audioSource.Play();
			}
		} else {
			if (audioSource.isPlaying){
				audioSource.Stop();
			}
		}
	}
}
