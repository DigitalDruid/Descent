using UnityEngine;
using System.Collections;

public class DebugController : MonoBehaviour
{
    public static DebugController instance;

    [SerializeField]
    public bool debugEnabled = false;
    public bool debugOn { get { return debugEnabled; } set { } }

    void Start() { }
    void Awake() { MakeSingleton(); }
    void MakeSingleton(){ if (instance != null) { Destroy(gameObject); } else { instance = this; DontDestroyOnLoad(gameObject); } }
    void Update() {
        if (Input.inputString == "~" && debugEnabled == false) { debugEnabled = true; }
        if (debugEnabled) {
            if (Input.anyKeyDown) {
                switch (Input.inputString) {
                    case "-": PlayerScore.Lives--;  break;
                    case "+": PlayerScore.Lives+=5; break;
                    /*
                    case " ":
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0));
                        break;
                    */
                }
            }
        }
    }

}
