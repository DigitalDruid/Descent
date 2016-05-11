using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	[SerializeField]
	private AudioClip coinClip, lifeClip;

	private CameraScript cameraScript;

	private Vector3 previousPosition;
	private bool countScore;

	public static int scoreCount;
	public static int lifeCount;
	public static int coinCount;

	void Awake(){
		cameraScript = Camera.main.GetComponent<CameraScript>();
	}

	// Use this for initialization
	void Start () {
		previousPosition = transform.position;
		countScore = true;
	}
	
	// Update is called once per frame
	void Update () {
		CountScore();
	}

	void CountScore(){
		if(countScore){
			if(transform.position.y < previousPosition.y){
				scoreCount++;
			}
			previousPosition = transform.position;

			GamePlayController.instance.SetScore(scoreCount);
		}
	}

	void OnTriggerEnter2D (Collider2D target){

		if(target.tag == "Coin"){
			coinCount++;
			scoreCount += 200;

			GamePlayController.instance.SetScore(scoreCount);
			GamePlayController.instance.SetCoinScore(coinCount);

			AudioSource.PlayClipAtPoint(coinClip, transform.position);
			target.gameObject.SetActive(false);
		}

		if (target.tag == "Life"){
			lifeCount++;
			scoreCount += 300;

			GamePlayController.instance.SetScore(scoreCount);
			GamePlayController.instance.SetLifeScore(lifeCount);

			AudioSource.PlayClipAtPoint(lifeClip, transform.position);
			target.gameObject.SetActive(false);
		}

		if (target.tag == "Bounds" || target.tag == "Deadly"){
			cameraScript.moveCamera = false;
			countScore = false;

			transform.position = new Vector3 (500, 500, 0);
			lifeCount--;

			GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);

		}
        
        if (target.tag == "EndStage")
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "GamePlay":  SceneFader.instance.LoadLevel("GamePlay2"); break;
                case "GamePlay2": SceneFader.instance.LoadLevel("GamePlay3"); break;
                case "GamePlay3": SceneFader.instance.LoadLevel("MainMenu");  break;
            }
            /*       
            string tmp = SceneManager.GetActiveScene().name;
            if (tmp == "GamePlay") { SceneFader.instance.LoadLevel("GamePlay2"); } else
            if (tmp == "GamePlay2") { SceneFader.instance.LoadLevel("GamePlay3"); } else
            if (tmp == "GamePlay3") { SceneFader.instance.LoadLevel("MainMenu"); }
            */
        }
        
//		if (target.tag == "Deadly"){
//			cameraScript.moveCamera = false;
//			countScore = false;
//
//			transform.position = new Vector3 (500, 500, 0);
//			lifeCount--;
//
//			GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount
	}
}
