using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds;
    [SerializeField]
    private GameObject[] collectibles;

    private GameObject player;

    private float distanceBetweenClouds = 3f;
    private float minX, maxX;
    private float lastCloudPositionY;
    private float controlX;
    

    //calls upon start of game
    void Awake() {
        controlX = 0;
        SetMinAndMaxX();
        CreateClouds();
        player = GameObject.Find("Player");

        for (int i = 0; i < collectibles.Length; i++) {
            collectibles[i].SetActive(false);
        }
    }

    // Use this for initialization
    void Start() {
        PositionPlayer();
    }

    void SetMinAndMaxX() {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    //will shuffle the clouds
    void Shuffle (GameObject[] arrayToShuffle) {
        for (int i = 0; i < arrayToShuffle.Length; i++) {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
    }

    void CreateClouds() {
        Shuffle(clouds);

        float positionY = 0f;

        for (int i = 0; i < clouds.Length; i++) {

            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;

            switch ((int)controlX) {
                case 0: temp.x = Random.Range(0.0f, maxX); controlX = 1; break;
                case 1: temp.x = Random.Range(0.0f, maxX); controlX = 2; break;
                case 2: temp.x = Random.Range(1.0f, maxX); controlX = 3; break;
                case 3: temp.x = Random.Range(-1.0f, minX); controlX = 0; break;
            }

            lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
            positionY -= distanceBetweenClouds;
        }
    }

    //setting the players position
    void PositionPlayer() {

        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for (int i = 0; i < darkClouds.Length; i++) {

            if (darkClouds[i].transform.position.y == 0f) {

                Vector3 temp = darkClouds[i].transform.position;

                darkClouds[i].transform.position = new Vector3(cloudsInGame[0].transform.position.x,
                                                               cloudsInGame[0].transform.position.y,
                                                               cloudsInGame[0].transform.position.z);
                cloudsInGame[0].transform.position = temp;
            }
        }

        Vector3 t = cloudsInGame[0].transform.position;

        for (int i = 1; i < cloudsInGame.Length; i++) {
            if (t.y < cloudsInGame[i].transform.position.y) {
                t = cloudsInGame[i].transform.position;
            }
        }

        t.y += 0.8f;
        player.transform.position = t;
    }

    void OnTriggerEnter2D (Collider2D target) {
        if (target.tag == "Cloud" || target.tag == "Deadly") {
            if (target.transform.position.y == lastCloudPositionY) {

                Shuffle(clouds);
                Shuffle(collectibles);

                Vector3 temp = target.transform.position;

                for (int i = 0; i < clouds.Length; i++) {

                    if (!clouds[i].activeInHierarchy) {

                        switch ((int)controlX) {
                            case 0: temp.x = Random.Range(0.0f, maxX); controlX = 1; break;
                            case 1: temp.x = Random.Range(0.0f, maxX); controlX = 2; break;
                            case 2: temp.x = Random.Range(1.0f, maxX); controlX = 3; break;
                            case 3: temp.x = Random.Range(-1.0f, minX); controlX = 0; break;
                        }

                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;

                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0, collectibles.Length);

                        if (clouds[i].tag != "Deadly") {
                            if (!collectibles[random].activeInHierarchy) {
                                Vector3 temp2 = clouds[i].transform.position;
                                temp2.y += 0.7f;

                                if (collectibles[random].tag == "Life") {
                                    if (PlayerScore.Lives < 2) {
                                        collectibles[random].transform.position = temp2;
                                        collectibles[random].SetActive(true);
                                    }
                                } else {
                                    collectibles[random].transform.position = temp2;
                                    collectibles[random].SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
