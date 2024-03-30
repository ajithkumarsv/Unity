using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GM;

public class ADS : Singleton<ADS>
{
    public void Start()
    {
       // showAd();
    }
    public void showAd()
    {
        Debug.Log("showAd");
        AfgbetaJs.InterstialAd();
    }

    public void pauseGame()
    {
        Debug.Log("pauseGame");
    }

    public void resumeGame()
    {
        Debug.Log("resumeGame");
    }
}
