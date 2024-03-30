using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GM;

public class Target : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] float resetTime =1;

    

    private void Start()
    {
        
    }

    public void OnHit(Vector3 position)
    {
       int score= Mathf.Clamp((20- Mathf.FloorToInt(Vector3.Distance(position, transform.position)*10)),1,20);
        GetComponent<Collider>().enabled = false;
        _anim.Play("target_hit");
        gameplaySource?.OnHitTarget(score);
        StartCoroutine(OnReset());
    }

    public IEnumerator OnReset()
    {
        yield return new WaitForSeconds(resetTime);
        GetComponent<Collider>().enabled = true;
        _anim.Play("target_reset");
    }

    GameplaySource gameplaySource { get { return GameManager.Instance.GameplaySource; } }
}
