using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
