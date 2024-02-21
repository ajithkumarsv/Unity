using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsHandler : Handler
{
    
    public override void Init()
    {
        base.Init();
    }
    public override void DeInit()
    {
        base.DeInit();
    }

    public void CloseButton()
    {
        MenuController.Instance.ActivateMenuHandler();
    }

}
