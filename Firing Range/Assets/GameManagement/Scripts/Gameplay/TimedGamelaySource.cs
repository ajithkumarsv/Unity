using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedGamelaySource : GameplaySource
{
    [SerializeField] float TotalTime = 120;
     float currentTime = 120;
    bool isGameOver=false;
    public override void Begin()
    {
        base.Begin();

        isGameOver =false;

        currentTime =TotalTime;
    }

    public override void Tick()
    {
        if(isGameOver) return;
        base.Tick();

        currentTime-=Time.deltaTime;
        Debug.Log("Time is " + currentTime);
        if(currentTime <= 0)
        {
            End();
        }
    }

    public override void End()
    {
        base.End();
        isGameOver = true;
        gamePlayManager.OnGameOver();
    }

    GameManager gamePlayManager { get { return GameManager.Instance; } }
}
