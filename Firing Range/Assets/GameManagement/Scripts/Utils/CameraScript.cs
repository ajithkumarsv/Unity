using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    LayerMask hitlayer;
    [SerializeField]
  
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           Ray ray= cam.ScreenPointToRay(Input.mousePosition);
           if( Physics.Raycast(ray, out RaycastHit hit,1000, hitlayer))
            {
                if(hit.collider.tag =="target")
                {
                    hit.collider.GetComponent<Target>().OnHit(hit.point);
                    
                }

            }
        }
          
    }
}
