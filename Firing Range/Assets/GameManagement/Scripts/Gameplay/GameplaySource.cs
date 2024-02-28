using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySource 
{
    
  
    public virtual void Begin()
    {

    }
    public virtual void Tick()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (!GameManager.IsPaused)
            {
                //GameManager.Instance.PauseGame();
                GameUIController.Instance.PauseGame();
            }
            else
            {
                //GameManager.Instance.ResumeGame();
                GameUIController.Instance.Resume();
            }

        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            if (Cursor.visible)
            {
                GameManager.Instance.LockUnlockCursor(true);

            }
            else
            {
                GameManager.Instance.LockUnlockCursor(false);
            }

        }
    }

    public virtual void End()
    {
    }

    

}
