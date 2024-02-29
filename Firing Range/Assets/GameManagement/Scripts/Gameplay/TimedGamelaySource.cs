using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class TimedGamelaySource : GameplaySource
{
     float TotalTime = 120;
     float currentTime = 120;
    
    
    public override void Begin(GameStartOptions gameStartParameters)
    {
        base.Begin(gameStartParameters);

        isGameOver =false;


        TotalTime = gameStartParameters.totalTime;
        currentTime = gameStartParameters.totalTime;
    }

    public override void Tick(float delta)
    {

        if(isGameOver) return;

        base.Tick(delta);

        currentTime-= delta;

        Debug.Log("Time is " + currentTime);

        if(currentTime <= 0)
        {
           OnTimeOver();
        }

    }

    public void OnTimeOver()
    {
        GameOverOption gameOverOption = new GameOverOption();
        gameOverOption.score =score;
        gameOverOption.GameOverCause = "Time Finished";
        gameOverOption.TimeTaken = TotalTime - currentTime;

        End(gameOverOption);
    }

    public override void End(GameOverOption gameOverParameter)
    {

        base.End(gameOverParameter);

        isGameOver = true;

        gamePlayManager.OnGameOver(gameOverParameter);

    }

    

    GameManager gamePlayManager { get { return GameManager.Instance; } }

}
