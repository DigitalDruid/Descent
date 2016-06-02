using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

    [SerializeField]
    public string MainMenu="MainMenu", HighScore="HighScore", Options="Options";
    [SerializeField]
    public string[] Levels; /* = new string[];  { "Level1", "Level2", "Level3" };*/
    public string[] Segues; /* = new string[];  { "Segue1", "Segue2" };*/
    [SerializeField]
    public string GameOver="GameOver", GameEnd="GameEnd", Credits="Credits", Shop="Shop";
    
    public static LevelController instance;
    void Awake() { if (instance == null) { instance = this; } }
}
