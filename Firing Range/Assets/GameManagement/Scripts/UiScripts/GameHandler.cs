using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : Handler
{
    GameUIController uiController { get { return GameUIController.Instance; } }

    public GameObject sniperscope;
    

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

    public void CrossHair(bool enable)
    {
        sniperscope.SetActive(enable);
    }

    public void EnableSniperScope(bool val)
    {
        sniperscope.SetActive(val);
    }
    public void ActivatePausehandler()
    {
        uiController.ActivatePauseHandler();
        GameManager.Instance.PauseGame();

    }

}
