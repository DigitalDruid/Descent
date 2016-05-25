using UnityEngine;
using System.Collections;

public static class GamePreferences {
	
	public const string EasyDifficulty = "EasyDifficulty";
	public const string MediumDifficulty = "MediumDifficulty";
	public const string HardDifficulty = "HardDifficulty";

	public const string EasyDifficultyHighScore = "EasyDifficultyHighScore";
	public const string MediumDifficultyHighScore = "MediumDifficultyHighScore";
	public const string HardDifficultyHighScore = "HardDifficultyHighScore";

	public const string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
	public const string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
	public const string HardDifficultyCoinScore = "HardDifficultyCoinScore";

	public static string IsMusicOn = "IsMusicOn";
    
    // NOTE We are going to use INT to represent Bool var

    // 0 - false, 1 - true
    public static int EasyDifficultyState {
        set { PlayerPrefs.SetInt(EasyDifficulty, value); }
        get { return PlayerPrefs.GetInt(EasyDifficulty); }
    }
    public static int MediumDifficultyState {
        set { PlayerPrefs.SetInt(MediumDifficulty, value); }
        get { return PlayerPrefs.GetInt(MediumDifficulty); }
    }
    public static int HardDifficultyState {
        set { PlayerPrefs.SetInt(HardDifficulty, value); }
        get { return PlayerPrefs.GetInt(HardDifficulty); }
    }
    public static int EasyDifficultyHighScoreState {
        set { PlayerPrefs.SetInt(EasyDifficultyHighScore, value); }
        get { return PlayerPrefs.GetInt(EasyDifficultyHighScore); }
    }
    public static int MediumDifficultyHighScoreState {
        set { PlayerPrefs.SetInt(MediumDifficultyHighScore, value); }
        get { return PlayerPrefs.GetInt(MediumDifficultyHighScore); }
    }
    public static int HardDifficultyHighScoreState {
        set { PlayerPrefs.SetInt(HardDifficultyHighScore, value); }
        get { return PlayerPrefs.GetInt(HardDifficultyHighScore); }
    }
    public static int EasyDifficultyCoinScoreState {
        set { PlayerPrefs.SetInt(EasyDifficultyCoinScore, value); }
        get { return PlayerPrefs.GetInt(EasyDifficultyCoinScore); }
    }
    public static int MediumDifficultyCoinScoreState {
        set { PlayerPrefs.SetInt(MediumDifficultyCoinScore, value); }
        get { return PlayerPrefs.GetInt(MediumDifficultyCoinScore); }
    }    
    public static int HardDifficultyCoinScoreState {
        set { PlayerPrefs.SetInt(HardDifficultyCoinScore, value); }
        get { return PlayerPrefs.GetInt(HardDifficultyCoinScore); }
    }
    //0 is off - 1 is on
    public static int MusicState {
        set { PlayerPrefs.SetInt(IsMusicOn, value); }
        get { return PlayerPrefs.GetInt(IsMusicOn); }
    }

    // Useful functions
    public static void RestoreDefaults() {
        EasyDifficultyState = 0;
        EasyDifficultyCoinScoreState = 0;
        EasyDifficultyHighScoreState = 0;

        MediumDifficultyState = 1;
        MediumDifficultyCoinScoreState = 0;
        MediumDifficultyHighScoreState = 0;

        HardDifficultyState = 0;
        HardDifficultyCoinScoreState = 0;
        HardDifficultyHighScoreState = 0;

        MusicState = 0;
    }
    public static string DifficultyState {
        get {
            if (EasyDifficultyState == 1) { return EasyDifficulty; } else
            if (HardDifficultyState == 1) { return HardDifficulty; } else
            { return MediumDifficulty; }
        }
        set {
            switch (value) {
                case EasyDifficulty: EasyDifficultyState = 1; MediumDifficultyState = HardDifficultyState = 0; break;
                case HardDifficulty: HardDifficultyState = 1; EasyDifficultyState = MediumDifficultyState = 0; break;
                case MediumDifficulty: default: MediumDifficultyState = 1; EasyDifficultyState = HardDifficultyState = 0; break;
            }
        }
    }
    public static int HighScoreState {
        get {
            int highScore;
            switch (DifficultyState) {
                case EasyDifficulty: { highScore = EasyDifficultyHighScoreState; } break;
                case HardDifficulty: { highScore = HardDifficultyHighScoreState; } break;
                case MediumDifficulty: default: { highScore = MediumDifficultyHighScoreState; } break;
            }
            return highScore;
        }
        set {
            switch (DifficultyState) {
                case EasyDifficulty: EasyDifficultyHighScoreState = value; break;
                case HardDifficulty: HardDifficultyHighScoreState = value; break;
                case MediumDifficulty: default: MediumDifficultyHighScoreState = value; break;
            }
        }
    }
    public static int CoinScoreState {
        get {
            int coinScore;
            switch (DifficultyState) {
                case EasyDifficulty: coinScore = EasyDifficultyCoinScoreState; break;
                case HardDifficulty: coinScore = HardDifficultyCoinScoreState; break;
                case MediumDifficulty: default: coinScore = MediumDifficultyCoinScoreState; break;
            }
            return coinScore;
        }
        set {
            switch (DifficultyState) {
                case EasyDifficulty: EasyDifficultyCoinScoreState = value; break;
                case HardDifficulty: HardDifficultyCoinScoreState = value; break;
                case MediumDifficulty: default: MediumDifficultyCoinScoreState = value; break;
            }
        }
    }
    // Old Functions
    /*
    public static void SetMusicState (int state){ PlayerPrefs.SetInt (GamePreferences.IsMusicOn, state); }
    public static int GetMusicState(){ return PlayerPrefs.GetInt(GamePreferences.IsMusicOn); }    
	
    public static void SetEasyDifficultyState(int state){ PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, state); }
    public static int GetEasyDificulltyState(){	return PlayerPrefs.GetInt (GamePreferences.EasyDifficulty); }
	public static void SetMediumDifficultyState(int state){ PlayerPrefs.SetInt(GamePreferences.MediumDifficulty, state); }
    public static int GetMediumDificulltyState(){ return PlayerPrefs.GetInt (GamePreferences.MediumDifficulty); }
	public static void SetHardDifficultyState(int state){ PlayerPrefs.SetInt(GamePreferences.HardDifficulty, state); }
    public static int GetHardDificulltyState(){	return PlayerPrefs.GetInt (GamePreferences.HardDifficulty); }
	public static void SetEasyDifficultyHighScoreState(int state){ PlayerPrefs.SetInt(GamePreferences.EasyDifficultyHighScore, state); }
    public static int GetEasyDificulltyHighScoreState(){ return PlayerPrefs.GetInt (GamePreferences.EasyDifficultyHighScore); }
	public static void SetMediumDifficultyHighScoreState(int state){ PlayerPrefs.SetInt(GamePreferences.MediumDifficultyHighScore, state); }
    public static int GetMediumDificulltyHighScoreState(){ return PlayerPrefs.GetInt (GamePreferences.MediumDifficultyHighScore); }
	public static void SetHardDifficultyHighScoreState(int state){ PlayerPrefs.SetInt(GamePreferences.HardDifficultyHighScore, state); }
    public static int GetHardDificulltyHighScoreState(){ return PlayerPrefs.GetInt (GamePreferences.HardDifficultyHighScore); }
	public static void SetEasyDifficultyCoinScoreState(int state){ PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, state); }
    public static int GetEasyDificulltyCoinScoreState(){ return PlayerPrefs.GetInt (GamePreferences.EasyDifficultyCoinScore); }
	public static void SetMediumDifficultyCoinScoreState(int state){ PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore, state); }
    public static int GetMediumDificulltyCoinScoreState(){ return PlayerPrefs.GetInt (GamePreferences.MediumDifficultyCoinScore); }
	public static void SetHardDifficultyCoinScoreState(int state){ PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore, state); }
    public static int GetHardDifficultyCoinScoreState(){ return PlayerPrefs.GetInt(GamePreferences.HardDifficultyCoinScore); }
    */
}
