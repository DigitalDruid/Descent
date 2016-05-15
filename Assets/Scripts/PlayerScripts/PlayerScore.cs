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

    public static int Score { get{return scoreCount;} set{scoreCount = value;} }
    public static int Lives { get{return lifeCount;}  set{lifeCount  = value;} }
    public static int Coins { get{return coinCount;}  set{coinCount  = value;} }

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
                //Score++;
			}
			previousPosition = transform.position;

			GamePlayController.instance.SetScore(scoreCount);
		}
	}

	void OnTriggerEnter2D (Collider2D target){

		if(target.tag == "Coin"){
            coinCount++;
            scoreCount += 200;
            //Coins++;
            //Score += 200;

			GamePlayController.instance.SetScore(scoreCount);
			GamePlayController.instance.SetCoinScore(coinCount);

			AudioSource.PlayClipAtPoint(coinClip, transform.position);
			target.gameObject.SetActive(false);
		}

		if (target.tag == "Life"){
            lifeCount++;
            scoreCount += 300;
            //Lives++;
            //Score += 300;

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
            //Lives--;

			GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);

		}

        /*/
        /// (Added by Martin B.)
        /// Player completes the stage by hitting EndStageTrigger object.
        /*/
        if (target.tag == "EndStage"){
            // Current Scene determines the next Scene to load.
            switch (SceneManager.GetActiveScene().name){
                case "GamePlay":  SceneFader.instance.LoadLevel("GamePlay2"); break;
                case "GamePlay2": SceneFader.instance.LoadLevel("GamePlay3"); break;
                case "GamePlay3": SceneFader.instance.LoadLevel("MainMenu");  break;
            }
        }
	}
}
