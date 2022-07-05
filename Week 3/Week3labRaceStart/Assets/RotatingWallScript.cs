using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWallScript : MonoBehaviour
{
    public float speed = 2;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(0, speed * Time.deltaTime * 100000000, 0);
    }
}
