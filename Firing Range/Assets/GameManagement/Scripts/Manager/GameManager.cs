using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private static bool isPaused;
    public static bool IsPaused
    {
        get
        {
            return isPaused;
        }
        set
        {
            isPaused = value;
        }

    }

   

    private GameData gameData;

    
    public void SaveData()
    {
        gameData = new GameData();
        //gameData.playerScore = 100;
        //gameData.isGameCompleted = false;
        gameData.playerName = "Player";

        // Save game data
        saveManager.Save(gameData);
    }


    public void LoadData()
    {
        if (saveManager)
        {

        }
        else
        {
            Debug.Log("savemanager is null");
        }
        GameData loadedData = saveManager.Load();
        if (loadedData != null)
        {
            gameData =loadedData;
            //Debug.Log("Loaded player score: " + loadedData.playerScore);
            //Debug.Log("Loaded game completed status: " + loadedData.isGameCompleted);
            Debug.Log("Loaded player name: " + loadedData.playerName);
        }
        SettingsManager.Instance.Load();
    }
    #region gameFlow


    GameplaySource gameplaySource;


    public void StartGame()
    {

        Time.timeScale = 1;
        IsPaused = false;
        Debug.Log("Gamescenes Loaded");
        InputManager.IsInputEnabled = true;
        GameUIController.Instance.OnLoaded();
        WeatherManager.Instance.ChangeSkyToDefault();
        gameplaySource = new TimedGamelaySource();
        gameplaySource.Begin();
    }
    public void OnGameOver()
    {
        InputManager.IsInputEnabled = false;
    }

    public void LockUnlockCursor(bool islock)
    {

        if (islock)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void PlayGame()
    {
        LockUnlockCursor(true);
        loadingManager.LoadGamePlay(OnGameSceneLoaded);
    }

    public void LoadMenu()
    {
        loadingManager.LoadMenu(OnMenuSceneLoaded);
    }

    public void PauseGame()
    {
        IsPaused = true;
        InputManager.IsInputEnabled = false;
        LockUnlockCursor(false);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        isPaused = false;
        InputManager.IsInputEnabled = true;
        LockUnlockCursor(true);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        InputManager.IsInputEnabled = false;
       LockUnlockCursor(false);
    }

    public void OnPreLoaded()
    {
        menuController.OnLoaded();
        LoadData();
    }

    public void OnGameSceneLoaded()
    {
        StartGame();
    }

    public void OnMenuSceneLoaded()
    {
        MenuController.Instance.OnLoaded();
        Debug.Log("MenuScenes Loaded");
    }

    private void Update()
    {

        if (gameplaySource != null) { gameplaySource.Tick(); }

    }
  
    #endregion
    LoadingManager loadingManager { get { return LoadingManager.Instance; } }
    MenuController menuController { get { return MenuController.Instance; } }
    SaveManager saveManager { get { return SaveManager.Instance; } }
}
