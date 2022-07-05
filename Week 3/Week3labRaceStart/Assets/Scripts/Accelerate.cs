using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : MonoBehaviour
{
    public float speed = 1;
    public float turnSpeed = 1;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        (GameObject ground, bool isGrounded) = CheckGround();
        if (isGrounded)
        {
            HandleAcceleration();
            ApplyGroundFriction(ground.tag);
            HandleTurning();
        }
        
    }
    (GameObject, bool)  CheckGround()
    {
        // Set up variable
        Vector3 origin = transform.position;
        Vector3 direction = Vector3.down;
        RaycastHit hitInfo;
        float maxDistance = 1f;
        // Check if its grounded via the raycast
        if (Physics.Raycast(origin, direction, out hitInfo, maxDistance))
            // check about smth
            return (hitInfo.transform.gameObject, true);
        else
            return (null, false);

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(Time.time);
    }


    void HandleAcceleration()
    {
        float verticalforce = Input.GetAxis("Vertical") * Time.deltaTime * 5000 * speed;
        
        rb.AddForce(transform.forward * verticalforce);
    }
    void ApplyGroundFriction(string tag)
    {
        if(tag == "Road")
            rb.velocity *= 0.99f;
        else
            rb.velocity *= 0.97f;
    }
    void HandleTurning()
    {
        float speedfraction = rb.velocity.magnitude / (Time.deltaTime * 5000 * speed);
        float horizontalturn = speedfraction * Input.GetAxis("Horizontal") * Time.deltaTime * 500 * turnSpeed;
        transform.RotateAround(transform.position - new Vector3(0, 0, 1.5f), Vector3.up, horizontalturn);
    }

}
