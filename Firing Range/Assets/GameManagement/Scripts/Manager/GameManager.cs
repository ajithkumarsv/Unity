using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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


    public void OnHitTarget(int val)
    {
        gameplaySource?.OnHitTarget(val);
    }

    public void StartGame()
    {

        Time.timeScale = 1;
        IsPaused = false;
        
        InputManager.IsInputEnabled = true;
        GameUIController.Instance.OnLoaded();
        WeatherManager.Instance.ChangeSkyToDefault();
        gameplaySource = new TimedGamelaySource();
        GameStartOptions gameStartParameters = new GameStartOptions();
        gameStartParameters.totalTime = 5;
        gameplaySource.Begin(gameStartParameters);
    }

    public void Retry()
    {
        //StartGame();
        ReloadScene();
    }

    public void ReloadScene()
    {
        LoadingManager.Instance.RetryGame(OnGameSceneLoaded);
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

    public void OnGameOver(GameOverOption gameOverOption)
    {
        InputManager.IsInputEnabled = false;
        LockUnlockCursor(false);
        Time.timeScale =0;
        GameUIController.Instance.ActivateGameoverhandler();
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

        if (gameplaySource != null) { gameplaySource.Tick(Time.deltaTime); }

    }
  
    #endregion
    LoadingManager loadingManager { get { return LoadingManager.Instance; } }
    MenuController menuController { get { return MenuController.Instance; } }
    SaveManager saveManager { get { return SaveManager.Instance; } }
}
