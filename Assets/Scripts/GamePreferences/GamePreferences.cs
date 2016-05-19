using UnityEngine;
using System.Collections;

public static class GamePreferences {
	
	public static string EasyDifficulty = "EasyDifficulty";
	public static string MediumDifficulty = "MediumDifficulty";
	public static string HardDifficulty = "HardDifficulty";

	public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
	public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
	public static string HardDifficultyHighScore = "HardDifficultyHighScore";

	public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
	public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
	public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

	public static string IsMusicOn = "IsMusicOn";

	// NOTE We are going to use INT to represent Bool var
	// 0 - false, 1 - true


	//0 is off - 1 is on
	public static void SetMusicState (int state){
		PlayerPrefs.SetInt (GamePreferences.IsMusicOn, state);
	}

	public static int GetMusicState(){
		return PlayerPrefs.GetInt(GamePreferences.IsMusicOn);
	}

	public static void SetEasyDifficultyState(int state){
		PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, state);
	}

	public static int GetEasyDificulltyState(){
		return PlayerPrefs.GetInt (GamePreferences.EasyDifficulty);
	}

	public static void SetMediumDifficultyState(int state){
		PlayerPrefs.SetInt(GamePreferences.MediumDifficulty, state);
	}

	public static int GetMediumDificulltyState(){
		return PlayerPrefs.GetInt (GamePreferences.MediumDifficulty);
	}

	public static void SetHardDifficultyState(int state){
		PlayerPrefs.SetInt(GamePreferences.HardDifficulty, state);
	}

	public static int GetHardDificulltyState(){
		return PlayerPrefs.GetInt (GamePreferences.HardDifficulty);
	}

	public static void SetEasyDifficultyHighScoreState(int state){
		PlayerPrefs.SetInt(GamePreferences.EasyDifficultyHighScore, state);
	}

	public static int GetEasyDificulltyHighScoreState(){
		return PlayerPrefs.GetInt (GamePreferences.EasyDifficultyHighScore);
	}

	public static void SetMediumDifficultyHighScoreState(int state){
		PlayerPrefs.SetInt(GamePreferences.MediumDifficultyHighScore, state);
	}

	public static int GetMediumDificulltyHighScoreState(){
		return PlayerPrefs.GetInt (GamePreferences.MediumDifficultyHighScore);
	}

	public static void SetHardDifficultyHighScoreState(int state){
		PlayerPrefs.SetInt(GamePreferences.HardDifficultyHighScore, state);
	}

	public static int GetHardDificulltyHighScoreState(){
		return PlayerPrefs.GetInt (GamePreferences.HardDifficultyHighScore);
	}

	public static void SetEasyDifficultyCoinScoreState(int state){
		PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, state);
	}

	public static int GetEasyDificulltyCoinScoreState(){
		return PlayerPrefs.GetInt (GamePreferences.EasyDifficultyCoinScore);
	}

	public static void SetMediumDifficultyCoinScoreState(int state){
		PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore, state);
	}

	public static int GetMediumDificulltyCoinScoreState(){
		return PlayerPrefs.GetInt (GamePreferences.MediumDifficultyCoinScore);
	}

	public static void SetHardDifficultyCoinScoreState(int state){
		PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore, state);
	}

	public static int GetHardDifficultyCoinScoreState(){
		return PlayerPrefs.GetInt(GamePreferences.HardDifficultyCoinScore);
	}
}
