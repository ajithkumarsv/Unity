using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
   
    private void Start()
    {
      
    }
    public void aim()
    {

        gameObject.SetActive(false);
        
    }
     
    public void AimBack()
    {
        gameObject.SetActive(true);
        

     }

    
}
