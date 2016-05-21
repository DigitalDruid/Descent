using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;
    [HideInInspector]
    public static bool gameStartedFromPreviousLevel;
    [HideInInspector]
    public int depthScore, coinScore, lifeScore;
    [SerializeField]
    private int startingLives = 2, startingCoins=0, startingScore=0;

    public static string curScene { get { return SceneManager.GetActiveScene().name; } }

    // Use this for initialization
    void Awake() {
        MakeSingleton();
    }

    void Start() {
        IntializeVariables();
    }
    void MakeSingleton()
    {
        if (instance != null) { Destroy(gameObject); } else { instance = this; DontDestroyOnLoad(gameObject); }
    }

    public void SyncScores(int score, int coins, int lives)
    {
        PlayerScore.Score = score;
        PlayerScore.Coins = coins;
        PlayerScore.Lives = lives;
    }
    void OnLevelWasLoaded() {
        switch (curScene)
        {
            case "GamePlay":
                {
                    if (gameRestartedAfterPlayerDied) { SyncScores(PlayerScore.Score, PlayerScore.Coins, PlayerScore.Lives); }
                    else if (gameStartedFromMainMenu) { SyncScores(startingScore, startingCoins, startingLives); }
                    else { SyncScores(startingScore, startingCoins, startingLives); }
                } break;
            case "GamePlay2":
                {
                    if (gameRestartedAfterPlayerDied || gameStartedFromPreviousLevel) {
                        SyncScores(PlayerScore.Score, PlayerScore.Coins, PlayerScore.Lives);
                    }
                } break;
            case "GamePlay3":
                {
                    if (gameRestartedAfterPlayerDied || gameStartedFromPreviousLevel) {
                        SyncScores(PlayerScore.Score, PlayerScore.Coins, PlayerScore.Lives);
                    }
                } break;

            case "InbetweenScene":
                {
                    
                    
                } break;
        }
    }
    void IntializeVariables() {

        if (!PlayerPrefs.HasKey("Game Initialized")) {
            GamePreferences.EasyDifficultyState = 0;
            GamePreferences.EasyDifficultyCoinScoreState = 0;
            GamePreferences.EasyDifficultyHighScoreState = 0;

            GamePreferences.MediumDifficultyState = 1;
            GamePreferences.MediumDifficultyCoinScoreState = 0;
            GamePreferences.MediumDifficultyHighScoreState = 0;

            GamePreferences.HardDifficultyState = 0;
            GamePreferences.HardDifficultyCoinScoreState = 0;
            GamePreferences.HardDifficultyHighScoreState = 0;

            GamePreferences.MusicState = 0;

            PlayerPrefs.SetInt("Game Initialized", 123);
        }

    }

    public void CheckGameStatus(int score, int coins, int lives) {
        if (lives < 0) {

            if (GamePreferences.EasyDifficultyState == 1) {
                int highScore = GamePreferences.EasyDifficultyHighScoreState;
                if (highScore < score) { GamePreferences.EasyDifficultyHighScoreState = score; }

                int coinHighScore = GamePreferences.EasyDifficultyCoinScoreState;
                if (coinHighScore < coins) { GamePreferences.EasyDifficultyCoinScoreState = coins; }
            }

            if (GamePreferences.MediumDifficultyState == 1) {
                int highScore = GamePreferences.MediumDifficultyHighScoreState;
                if (highScore < score) { GamePreferences.MediumDifficultyHighScoreState = score; }

                int coinHighScore = GamePreferences.MediumDifficultyCoinScoreState;
                if (coinHighScore < coins) { GamePreferences.MediumDifficultyCoinScoreState = coins; }
            }

            if (GamePreferences.HardDifficultyState == 1) {
                int highScore = GamePreferences.HardDifficultyHighScoreState;
                if (highScore < score) { GamePreferences.HardDifficultyHighScoreState = score; }

                int coinHighScore = GamePreferences.HardDifficultyCoinScoreState;
                if (coinHighScore < coins) { GamePreferences.HardDifficultyCoinScoreState = coins; }
            }

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
    public void gotoNextScene()
    {
        gameStartedFromPreviousLevel = true;
        // Current Scene determines the next Scene to load.
        switch (curScene)
        {
            case "GamePlay": loadLevel("InbetweenScene"); break;
            case "InbetweenScene": loadLevel("GamePlay2"); break;
            case "GamePlay2": loadLevel("InbetweenScene2"); break;
            case "InbetweenScene2": loadLevel("GamePlay3"); break;
            case "GamePlay3": loadLevel("MainMenu"); break;
        }
    }
    void loadLevel(string sceneName) { SceneFader.instance.LoadLevel(sceneName); }
}
