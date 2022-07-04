using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarMovement : MonoBehaviour
{
	public float speed=1;	

	Rigidbody rb;

    void Start()
    {
		rb=GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
		Vector3 moveVector = transform.forward;

		rb.velocity = moveVector * speed;
    }
}
