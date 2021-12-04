
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance{
        get{
            if(!_instance) _instance=FindObjectOfType<GameManager>();
            return _instance;
        }
    }
    private void Awake() {
        _instance=this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void LoadGame(int index){
        StartCoroutine(LoadLevelCoroutine(index));
        
    }
    public void ExitGame(){
        StartCoroutine(LoadLevelCoroutine(0));
        
    }

    IEnumerator LoadLevelCoroutine(int i)
    {
        UIManager.Instance.ExitScreen(Screens.menu);
        UIManager.Instance.InitScreen(Screens.loading);
        yield return null;
        AsyncOperation asyncOp=SceneManager.LoadSceneAsync(i);
        while(!asyncOp.isDone){
            yield return null;
        }
        yield return null;
        UIManager.Instance.ExitScreen(Screens.loading);
    }
}
