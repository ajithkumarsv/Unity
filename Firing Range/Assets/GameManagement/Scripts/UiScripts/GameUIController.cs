using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : Singleton<GameUIController>
{
    Handler currentActiveHandler = null;

    [SerializeField] PauseHandler pausehandler;
    [SerializeField] GameHandler gameHandler;

    public void OnLoaded()
    {
        DeactivateAll();
        ActivateGameHandler();
    }

    public void DeactivateAll()
    {
        pausehandler.DeInit();
        gameHandler.DeInit();
    }

    public void ActivateHandler(Handler handler)
    {
        if (currentActiveHandler != null) currentActiveHandler.DeInit();
        handler.Init();
        currentActiveHandler = handler;
    }

    public void ActivatePauseHandler()
    {
        ActivateHandler(pausehandler);
    }

    public void ActivateGameHandler()
    {
        ActivateHandler(gameHandler);
    }

    

}
