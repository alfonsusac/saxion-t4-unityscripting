using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerControls : MonoBehaviour
{
	public float speed=1;

    Rigidbody rb;
    Vector3 startPosition;

    void Start()
    {
		rb=GetComponent<Rigidbody>();
		startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            ResetPosition();
        }
    }

    void Update()
    {
        HandleInputPhysics();
    }

    void HandleInput()
    {
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(moveVector * speed);
    }

    void HandleInputPhysics()
    {
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * 100000 * Time.deltaTime);
    }

    void ResetPosition() {
        if (rb != null) {
            rb.position = startPosition;
        } else {
            Debug.Log("Warning: no rigidbody attached to player");
        }
    }
}
