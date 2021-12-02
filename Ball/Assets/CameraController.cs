using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    Vector2 rotation = Vector2.zero;
    public float speed = 3; //the sensibility
    private Rigidbody rb;
    private float xAxis;
    private float zAxis;

    private float force = 100;
    private float jumpForce = 30000;

    bool grounded = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = target.GetComponent<Rigidbody>();
    }
    

    void FixedUpdate()
    {

        
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        Quaternion rot = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 90, 0);
        Vector3 vector = new Vector3(xAxis, 0, zAxis);
        vector.Normalize();

        rb.AddTorque(rot * vector * force);
    }
    void LateUpdate()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * speed;
        transform.position = target.position;

    }

}
