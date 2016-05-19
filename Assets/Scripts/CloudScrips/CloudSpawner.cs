using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] clouds;

	private float distanceBetweenClouds = 3f;
	private float minX, maxX;
	private float lastCloudPositionY;
	private float controlX;

	[SerializeField]
	private GameObject[] collectables;

	private GameObject player;

	//calls upon start of game
	void Awake(){
		controlX = 0;
		SetMinAndMaxX();
		CreateClouds();
		player = GameObject.Find ("Player");

		for (int i = 0; i < collectables.Length; i++){
			collectables[i].SetActive(false);
		}
	}

	// Use this for initialization
	void Start () {
		PositionPlayer();
	}

	void SetMinAndMaxX(){
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0));

		maxX = bounds.x - 0.5f;
		minX = -bounds.x + 0.5f;

	}

	//will shuffle the clouds
	void Shuffle(GameObject[] arrayToShuffle){

		for (int i = 0; i < arrayToShuffle.Length; i++){
			GameObject temp = arrayToShuffle[i];
			int random = Random.Range (i, arrayToShuffle.Length);
			arrayToShuffle[i] = arrayToShuffle[random];
			arrayToShuffle[random] = temp;
		}
	}

	void CreateClouds () {

		Shuffle (clouds);

		float positionY = 0f;

		for(int i = 0; i < clouds.Length; i++){
			Vector3 temp = clouds[i].transform.position;

			temp.y = positionY;

			if(controlX == 0){
				temp.x = Random.Range(0.0f, maxX);
				controlX = 1;
			}else if (controlX == 1){
				temp.x = Random.Range(0.0f, maxX);
				controlX = 2;
			}else if (controlX == 2){
				temp.x = Random.Range(1.0f, maxX);
				controlX = 3;
			}else if (controlX == 3){
				temp.x = Random.Range(-1.0f, minX);
				controlX = 0;
			}

			lastCloudPositionY = positionY;

			clouds[i].transform.position = temp;

			positionY -= distanceBetweenClouds;
		}

	}

	//setting the players position
	void PositionPlayer(){
		GameObject [] darkClouds = GameObject.FindGameObjectsWithTag ("Deadly");
		GameObject [] cloudsInGame = GameObject.FindGameObjectsWithTag ("Cloud");

		for (int i = 0; i < darkClouds.Length; i++){
			if(darkClouds[i].transform.position.y == 0f){
				Vector3 temp = darkClouds[i].transform.position;

				darkClouds[i].transform.position = new Vector3 (cloudsInGame[0].transform.position.x,
																cloudsInGame[0].transform.position.y,
																cloudsInGame[0].transform.position.z);

				cloudsInGame[0].transform.position = temp;
			}


		}

		Vector3 t = cloudsInGame[0].transform.position;

		for (int i = 1; i < cloudsInGame.Length; i++){
			if (t.y < cloudsInGame[i].transform.position.y){
				t = cloudsInGame[i].transform.position;
			}
		}

		t.y += 0.8f;

		player.transform.position = t;
	}

	void OnTriggerEnter2D (Collider2D target){
		if (target.tag == "Cloud" || target.tag == "Deadly"){
			if (target.transform.position.y == lastCloudPositionY){
				Shuffle(clouds);
				Shuffle(collectables);

				Vector3 temp = target.transform.position;

				for (int i = 0; i < clouds.Length; i++){

					if(!clouds[i].activeInHierarchy){

						if(controlX == 0){
								temp.x = Random.Range(0.0f, maxX);
								controlX = 1;
							}else if (controlX == 1){
								temp.x = Random.Range(0.0f, maxX);
								controlX = 2;
							}else if (controlX == 2){
								temp.x = Random.Range(1.0f, maxX);
								controlX = 3;
							}else if (controlX == 3){
								temp.x = Random.Range(-1.0f, minX);
								controlX = 0;
							}

						temp.y -= distanceBetweenClouds;

						lastCloudPositionY = temp.y;

						clouds[i].transform.position = temp;
						clouds[i].SetActive(true);

						int random = Random.Range(0, collectables.Length);

						if(clouds[i].tag != "Deadly"){
							if(!collectables[random].activeInHierarchy){
								Vector3 temp2 = clouds[i].transform.position;
								temp2.y += 0.7f;

								if(collectables[random].tag == "Life"){
										if(PlayerScore.lifeCount < 2){
											collectables[random].transform.position = temp2;
											collectables[random].SetActive(true);
										}
									} else {
										collectables[random].transform.position = temp2;
										collectables[random].SetActive(true);
									}	
								}	
							}
						
						}
					}
			
			}
		}
	}

}
