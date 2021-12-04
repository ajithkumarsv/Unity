
using UnityEngine;
using UnityEngine.UIElements;

public enum Screens
{
    menu, preloader, pause, loading, game
}
public class UIManager : MonoBehaviour
{

    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (!_instance) _instance = FindObjectOfType<UIManager>();
            return _instance;
        }
    }

    public GameObject MenuScreen;
    public GameObject PreloaderScreen;
    public GameObject PauseScreen;
    public GameObject LoadingScreen;
    public GameObject GameplayScreen;

    public void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Load();
    }
    public void InitScreen(Screens screen)
    {
        switch (screen)
        {
            case Screens.menu:
                MenuScreen.SetActive(true);
                break;
            case Screens.game:
                GameplayScreen.SetActive(true);
                break;
            case Screens.loading:
                LoadingScreen.SetActive(true);
                break;
            case Screens.pause:
                PauseScreen.SetActive(true);
                break;
            case Screens.preloader:
                PreloaderScreen.SetActive(true);
                break;
            default: break;

        }
    }
    public void ExitScreen(Screens screen)
    {
        switch (screen)
        {
            case Screens.menu:
                MenuScreen.SetActive(false);
                break;
            case Screens.game:
                GameplayScreen.SetActive(false);
                break;
            case Screens.loading:
                LoadingScreen.SetActive(false);
                break;
            case Screens.pause:
                PauseScreen.SetActive(false);
                break;
            case Screens.preloader:
                PreloaderScreen.SetActive(false);
                break;
            default: break;

        }
    }
    private void Load()
    {
        OnLoadCompleted();
    }

    private void OnLoadCompleted()
    {
        ExitScreen(Screens.preloader);
        InitScreen(Screens.menu);
    }
    public void ButtonPressed(GameObject but)
    {
        switch (but.name)
        {
            case "Play":
                GameManager.Instance.LoadGame(1);
                break;
            default:
                break;
        }
    }
}
