using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : Handler
{
    GameUIController uiController { get { return GameUIController.Instance; } }

    private void Start()
    {

    }

    public override void Init()
    {
        base.Init();
    }

    public override void DeInit()
    {
        base.DeInit();
    }

    public void OnResume()
    {
        uiController.ActivateGameHandler();
        //GameManager.Instance.ResumeGame();
    }

    public void OnMenu()
    {
        uiController.OnMenu();
    }

   

    
}
