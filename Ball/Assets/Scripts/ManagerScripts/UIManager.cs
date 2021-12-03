using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    private static UIManager _instance;

    public static UIManager Instance{
        get{
            if(!_instance) _instance=FindObjectOfType<UIManager>();
            return _instance;
        }
    }

    public GameObject MenuScreen;
    public GameObject PreloaderScreen;
    public GameObject PauseScreen;
    public GameObject LoadingScreen;
    public GameObject GameplayScreen;

    public void Awake() {
        _instance=this;
    }
    private void Start() {
        Load();
    }

    private void Load()
    {
        PreloaderScreen.SetActive(true);
        PauseScreen.SetActive(false);
        LoadingScreen.SetActive(false);
        GameplayScreen.SetActive(false);
        MenuScreen.SetActive(false);
        OnLoadCompleted();
    }

    private void OnLoadCompleted()
    {
        PreloaderScreen.SetActive(false);
        MenuScreen.SetActive(true);
    }
}
