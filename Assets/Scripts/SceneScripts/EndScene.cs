using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndScene : MonoBehaviour {

    private GameObject player;
    private GameObject stageEnd;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        stageEnd = GameObject.FindGameObjectWithTag("EndStage");
        //stageEnd = GameObject.Find("EndStageTrigger");
        stageEnd.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D target) {
        /*if(target.tag == "EndStage"){
            string tmp = SceneManager.GetActiveScene().name;
            if (tmp == "GamePlay") { SceneFader.instance.LoadLevel("GamePlay2"); } else
            if (tmp =="GamePlay2") { SceneFader.instance.LoadLevel("GamePlay3"); } else
            if (tmp =="GamePlay3") { SceneFader.instance.LoadLevel("MainMenu");  }
        }*/
    }
}
