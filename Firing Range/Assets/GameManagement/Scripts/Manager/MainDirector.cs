using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDirector : Singleton<MainDirector>
{
    LoadingManager loadingManager { get { return LoadingManager.Instance; } }
    MenuController menuController { get { return MenuController.Instance; } }
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
}
