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

    public SaveManager saveManager;

    private GameData gameData;

    
    public void SaveData()
    {
        gameData = new GameData();
        gameData.playerScore = 100;
        gameData.isGameCompleted = false;
        gameData.playerName = "Player";

        // Save game data
        saveManager.Save(gameData);
    }


    public void LoadData()
    {
        GameData loadedData = saveManager.Load();
        if (loadedData != null)
        {
            gameData =loadedData;
            Debug.Log("Loaded player score: " + loadedData.playerScore);
            Debug.Log("Loaded game completed status: " + loadedData.isGameCompleted);
            Debug.Log("Loaded player name: " + loadedData.playerName);
        }
    }
    #region gameFlow
    public void PlayGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        isPaused = false;
        InputManager.IsInputEnabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        InputManager.IsInputEnabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnPreLoaded()
    {
        menuController.OnLoaded();

    }

    public void OnGameSceneLoaded()
    {
        Time.timeScale = 1;
        IsPaused =false;
        Debug.Log("Gamescenes Loaded");
        InputManager.IsInputEnabled = true;
        GameUIController.Instance.OnLoaded();

    }

    public void OnMenuSceneLoaded()
    {
        MenuController.Instance.OnLoaded();
        Debug.Log("MenuScenes Loaded");
    }
    #endregion
    LoadingManager loadingManager { get { return LoadingManager.Instance; } }
    MenuController menuController { get { return MenuController.Instance; } }
}
