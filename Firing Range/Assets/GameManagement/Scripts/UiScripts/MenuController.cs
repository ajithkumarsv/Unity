using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : Singleton<MenuController>
{
    //Queue<Handler> handler = new Queue<Handler>();

    Handler currentActiveHandler = null;

    [SerializeField] MenuHandler menuhandler;
    [SerializeField] OptionsHandler optionsHandler;

    public void OnLoaded()
    {
        menuhandler.DeInit();
        optionsHandler.DeInit();
        ActivateMenuHandler();
    }

  
    public void ActivateHandler(Handler handler)
    {
        if (currentActiveHandler != null) currentActiveHandler.DeInit();
        handler.Init();
        currentActiveHandler = handler;
    }

    public void ActivateMenuHandler()
    {
        ActivateHandler(menuhandler);
    }

    public void ActivateOptionsHandler()
    {
        ActivateHandler(optionsHandler);
    }

    public void PlayGame()
    {

        MainDirector.Instance.PlayGame();
        
    }

   
}
