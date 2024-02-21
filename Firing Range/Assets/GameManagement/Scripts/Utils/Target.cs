using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] float resetTime =1;
   public void OnHit(Vector3 position)
    {
        Debug.Log("target hit"+ Vector3.Distance(position,transform.position));
        _anim.Play("target_hit");
        StartCoroutine(OnReset());
    }

    public IEnumerator OnReset()
    {
        yield return new WaitForSeconds(resetTime);
        _anim.Play("target_reset");
    }
}
