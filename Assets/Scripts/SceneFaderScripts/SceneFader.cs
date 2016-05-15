using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour {

	public static SceneFader instance;

	[SerializeField]
	private GameObject fadePanel;

	[SerializeField]
	private Animator fadeAnim;

	// Use this for initialization
	void Awake () {
		MakeSingleton();
	}

	void MakeSingleton () {
		if (instance != null){
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void LoadLevel(string level){
		StartCoroutine (FadeInOut (level));
	}

	IEnumerator FadeInOut(string level){
		fadePanel.SetActive(true);
		fadeAnim.Play("FadeIn");

		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds(1f));

        // Application.LoadLevel(level);
        SceneManager.LoadScene(level);
		fadeAnim.Play("FadeOut");

		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds(.7f));

		fadePanel.SetActive(false);
	}
}
