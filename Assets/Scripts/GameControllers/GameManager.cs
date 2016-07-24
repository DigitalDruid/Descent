using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField]
    public int startingLives = 0, startingCoins = 0, startingScore = 0;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;
    [HideInInspector]
    public static bool gameStartedFromPreviousLevel;
    [HideInInspector]
    public int depthScore, coinScore/*, lifeScore*/;

    public static string curScene { get { return SceneManager.GetActiveScene().name; } }
    int LargerOf (int a, int b) { return (a > b) ? a : b; }

    // Array of all Scenes in the project.
    private string[] Scenes = new string[] {
        "Credits", /*"GameOver",*/
        "GamePlay", /*"GamePlay2", "GamePlay3",*/
         /*"InbetweenScene", "InbetweenScene2", "EndScene",*/
        "MainMenu", "HighScore", "OptionsMenu", /*"OpeningCredits",*/ "Shop"
    };
    // Use this for initialization
    void Awake() { MakeSingleton(); }
    void MakeSingleton() {
        if (instance != null) { Destroy(gameObject); } else { instance = this; DontDestroyOnLoad(gameObject); }
    }

    void Start() { IntializeVariables(); }
    void IntializeVariables() {
        if (!PlayerPrefs.HasKey("Game Initialized")) {
            GamePreferences.RestoreDefaults();
            PlayerPrefs.SetInt("Game Initialized", 123);
        }
        MusicController.instance.SetBGMClip();
    }

    public void SyncScores (int score = 0, int coins = 0, int lives = 0) {
        PlayerScore.Score = score;
        PlayerScore.Coins = coins;
        //PlayerScore.Lives = lives;
    }

    public void loadLevel (string sceneName) { SceneFader.instance.LoadLevel(sceneName); }

    void unloadScenes() {
        foreach (var item in Scenes) { if (curScene != item) { SceneManager.UnloadScene(item); } }
    }
    void OnLevelWasLoaded() {
        unloadScenes();
        if (curScene == LevelController.instance.Levels[0]) {   // "GamePlay"
            if (gameRestartedAfterPlayerDied) { SyncScores(PlayerScore.Score, PlayerScore.Coins, PlayerScore.Lives); }
            else if (gameStartedFromMainMenu) { SyncScores(startingScore, startingCoins, startingLives); }
            //else { SyncScores(startingScore, startingCoins, startingLives); }
        }
        else if (
              curScene == LevelController.instance.Levels[1] ||  // "GamePlay2"
              curScene == LevelController.instance.Levels[2]     // "GamePlay3"
            ) {
            if (gameRestartedAfterPlayerDied || gameStartedFromPreviousLevel) {
                SyncScores(PlayerScore.Score, PlayerScore.Coins);
            }
        }

        MusicController.instance.SetBGMClip();
    }
    public void CheckGameStatus(int score, int coins)
    {
        GamePreferences.HighScoreState = LargerOf(GamePreferences.HighScoreState, score);
        GamePreferences.CoinScoreState = LargerOf(GamePreferences.CoinScoreState, coins);

        gameStartedFromMainMenu = false;
        gameRestartedAfterPlayerDied = false;
        gameStartedFromPreviousLevel = false;

        GamePlayController.instance.GameOverShowPanel(score, coins);
    }
    public void CheckGameStatus(int score, int coins, int lives) {
        if (lives < 0) {
            GamePreferences.HighScoreState = LargerOf(GamePreferences.HighScoreState, score);
            GamePreferences.CoinScoreState = LargerOf(GamePreferences.CoinScoreState, coins);

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;
            gameStartedFromPreviousLevel = false;

            GamePlayController.instance.GameOverShowPanel(score, coins);
        } else {
            PlayerScore.Score = score;
            PlayerScore.Coins = coins;
            PlayerScore.Lives = lives;

            gameRestartedAfterPlayerDied = true;
            gameStartedFromMainMenu = false;
            gameStartedFromPreviousLevel = false;

            GamePlayController.instance.PlayerDiedRestartTheGame();
        }
    }

    public void gotoNextScene() {
        gameStartedFromPreviousLevel = true;
        
        // Current Scene determines the next Scene to load.
        switch (curScene) {
            case "GamePlay":        loadLevel("InbetweenScene");    break;
            case "InbetweenScene":  loadLevel("GamePlay2");         break;
            case "GamePlay2":       loadLevel("InbetweenScene2");   break;
            case "InbetweenScene2": loadLevel("GamePlay3");         break;
            case "GamePlay3":       loadLevel("MainMenu");          break;
        }
        
    }
}
