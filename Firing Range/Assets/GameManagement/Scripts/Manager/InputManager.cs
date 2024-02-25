using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private static bool isInputEnabled;
    public static bool IsInputEnabled
    {
        get
        {
            return isInputEnabled;
        }
        set
        {
            isInputEnabled = value;
        }
        
    }
}
