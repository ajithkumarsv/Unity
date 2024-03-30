using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GM;

public class GunAnimationEvents : MonoBehaviour
{
    GunScript gunscript;
    private void Start()
    {
        gunscript= GetComponentInParent<GunScript>();
    }
    //animation event
    public void Fire()
    {
        gunscript.fireTrigger();
    }
    public void OnRealoadEvent()
    {
        gunscript.OnRealoadEvent();
    }

    public void PlayBoltAudio()
    {
        AudioManager.Instance.PlayBolt();
    }
    public void PlayReload()
    {
        AudioManager.Instance.PlayReload();
    }
    public void PlayTakeAudio()
    {
        AudioManager.Instance.PlayTake();
    }
}
