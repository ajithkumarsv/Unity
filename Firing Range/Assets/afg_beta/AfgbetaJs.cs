using UnityEngine;
using System.Runtime.InteropServices;

public class AfgbetaJs : MonoBehaviour {
    [DllImport("__Internal")]
    public static extern void InterstialAd();


    void Start() {
        Debug.Log("Start Afgbeta");
    }

    public void ShowInterstialAd()
    {
        // Calling JS function
        Debug.Log("ShowInterstialAd");
        InterstialAd();
    }
}