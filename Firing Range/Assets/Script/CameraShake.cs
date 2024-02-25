using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    

    public Transform cameraTransform;
    public float recoilAmount = 0.5f;
    public float recoilSpeed = 5f;

    private Vector3 originalPosition;
    private bool isRecoiling;

    private void Start()
    {
        originalPosition = cameraTransform.localPosition;
    }

    private void Update()
    {
       
        if (isRecoiling)
        {
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, originalPosition, Time.deltaTime * recoilSpeed);

            if (cameraTransform.localPosition == originalPosition)
            {
                isRecoiling = false;
            }
        }
    }

    public void Recoil()
    {
        originalPosition = cameraTransform.localPosition;
        isRecoiling = true;
        Vector3 recoilPosition = cameraTransform.localPosition - Vector3.forward * recoilAmount;
        cameraTransform.localPosition = recoilPosition;
    }
}