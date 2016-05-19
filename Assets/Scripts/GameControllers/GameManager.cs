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
            GamePreferences.SetEasyDifficultyState(0);
            GamePreferences.SetEasyDifficultyCoinScoreState(0);
            GamePreferences.SetEasyDifficultyHighScoreState(0);

            GamePreferences.SetMediumDifficultyState(1);
            GamePreferences.SetMediumDifficultyCoinScoreState(0);
            GamePreferences.SetMediumDifficultyHighScoreState(0);

            GamePreferences.SetHardDifficultyState(0);
            GamePreferences.SetHardDifficultyCoinScoreState(0);
            GamePreferences.SetHardDifficultyHighScoreState(0);

            GamePreferences.SetMusicState(0);

            PlayerPrefs.SetInt("Game Initialized", 123);
        }

    }

    public void CheckGameStatus(int score, int coins, int lives) {
        if (lives < 0) {

            if (GamePreferences.GetEasyDificulltyState() == 1) {
                int highScore = GamePreferences.GetEasyDificulltyHighScoreState();
                if (highScore < score) { GamePreferences.SetEasyDifficultyHighScoreState(score); }

                int coinHighScore = GamePreferences.GetEasyDificulltyCoinScoreState();
                if (coinHighScore < coins) { GamePreferences.SetEasyDifficultyCoinScoreState(coins); }
            }

            if (GamePreferences.GetMediumDificulltyState() == 1) {
                int highScore = GamePreferences.GetMediumDificulltyHighScoreState();
                if (highScore < score) { GamePreferences.SetMediumDifficultyHighScoreState(score); }

                int coinHighScore = GamePreferences.GetMediumDificulltyCoinScoreState();
                if (coinHighScore < coins) { GamePreferences.SetMediumDifficultyCoinScoreState(coins); }
            }

            if (GamePreferences.GetHardDificulltyState() == 1) {
                int highScore = GamePreferences.GetHardDificulltyHighScoreState();
                if (highScore < score) { GamePreferences.SetHardDifficultyHighScoreState(score); }

                int coinHighScore = GamePreferences.GetHardDifficultyCoinScoreState();
                if (coinHighScore < coins) { GamePreferences.SetHardDifficultyCoinScoreState(coins); }
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
