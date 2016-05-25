using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    [SerializeField]
    public string MainMenu="MainMenu", HighScore="HighScore", Options="Options";
    [SerializeField]
    public string[] Levels = new string[3]; /* { "Level1", "Level2", "Level3" };*/
    public string[] Segues = new string[2]; /* { "Segue1", "Segue2" };*/
    [SerializeField]
    public string GameOver="GameOver", Credits="Credits";
    
    public static LevelController instance;
    void Awake() { if (instance == null) { instance = this; } }
}
