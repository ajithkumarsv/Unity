using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIHandler : Handler
{
    GameUIController uiController { get { return GameUIController.Instance; } }

    public GameObject sniperscope;
    [SerializeField] TextMeshProUGUI timetext;

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
    public void SetTime(float Time)
    {
        timetext.text = Time.ToString("00.00");
    }

}
