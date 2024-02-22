using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
   
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

        loadingManager.LoadGamePlay(OnGameSceneLoaded);
    }

    public void LoadMenu()
    {
        loadingManager.LoadMenu(OnMenuSceneLoaded);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {

        Time.timeScale = 1;
    }
    public void GameOver()
    { 
    
    }

    public void OnPreLoaded()
    {
        menuController.OnLoaded();

    }

    public void OnGameSceneLoaded()
    {
        Debug.Log("Gamescenes Loaded");
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
