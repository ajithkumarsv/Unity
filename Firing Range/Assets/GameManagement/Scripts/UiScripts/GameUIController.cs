using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : Singleton<GameUIController>
{
    Handler currentActiveHandler = null;

    [SerializeField] PauseHandler pausehandler;
    [SerializeField] GameHandler gameHandler;
    [SerializeField] OptionsHandler optionsHandler;

    public void OnLoaded()
    {
        DeactivateAll();
        ActivateGameHandler();
    }

    public void DeactivateAll()
    {
        pausehandler.DeInit();
        gameHandler.DeInit();
        optionsHandler.DeInit();
    }

    public void ActivateHandler(Handler handler)
    {
        if (currentActiveHandler != null) currentActiveHandler.DeInit();
        handler.Init();
        currentActiveHandler = handler;
    }

    public void CrossHair(bool enable)
    {
        gameHandler.CrossHair(enable);
    }

    public void ActivatePauseHandler()
    {
        ActivateHandler(pausehandler);
    }

    public void ActivateOptionsHandler()
    {
        ActivateHandler(optionsHandler);
    }


    public void PauseGame()
    {
        GameManager.Instance.PauseGame();
        ActivatePauseHandler();
    }

    public void Resume()
    {
       GameManager.Instance.ResumeGame();
        pausehandler.OnResume();
    }

    public void OnMenu()
    {
        GameManager.Instance.LoadMenu();
    }


    public void ActivateGameHandler()
    {
        ActivateHandler(gameHandler);
    }
    

    


}
