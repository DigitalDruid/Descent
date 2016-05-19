using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	[SerializeField]
	public AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;

    private Vector3 previousPosition;
	private bool countScore;

	private static int scoreCount;
	private static int lifeCount;
	private static int coinCount;

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

        GamePlayController.instance.SetScore(Score);
        GamePlayController.instance.SetCoinScore(Coins);
        GamePlayController.instance.SetLifeScore(Lives);
    }

	void CountScore(){
		if(countScore){
			if(transform.position.y < previousPosition.y){
                Score++;
			}
			previousPosition = transform.position;
		}
	}

	void OnTriggerEnter2D (Collider2D target){

		if(target.tag == "Coin"){
            Coins++;
            Score += 200;

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
			target.gameObject.SetActive(false);
		}

		if (target.tag == "Life"){
            Lives++;
            Score += 300;

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
			target.gameObject.SetActive(false);
		}

        if (target.tag == "Bounds" || (target.tag=="Deadly" && DebugController.instance.debugOn==false) ){
            cameraScript.moveCamera = false;
            countScore = false;

            transform.position = new Vector3(500, 500, 0);
            Lives--;

            GameManager.instance.CheckGameStatus(Score, Coins, Lives);
        }
        /* 
         * Testing EndScene.cs
         */
        // Player completes the stage by hitting EndStageTrigger object.
        if (target.tag == "EndStage"){
            GameManager.instance.gotoNextScene();
        }
	}
}
