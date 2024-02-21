using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : Handler
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


    public void ActivatePausehandler()
    {
        uiController.ActivatePauseHandler();
        MainDirector.Instance.PauseGame();

    }

}
