using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : Handler
{
    public override void Init()
    {
        base.Init();
        

    }
    public override void DeInit()
    {
        base.DeInit();
    }

    public void Menu()
    {
        GameUIController.Instance.OnMenu();
    }

    public void Retry()
    {
        GameUIController.Instance.OnRetry();
    }

}
