using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float turnSpeed = 0.01f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            transform.LookAt(target);
        } else {
            transform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed, 0);
        }
    }
}
