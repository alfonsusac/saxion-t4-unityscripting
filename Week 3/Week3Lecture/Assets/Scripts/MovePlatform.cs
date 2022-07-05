using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
	public Vector3 velocity;
	Rigidbody rb;
	
    void Start()
    {
		rb=GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
		Move();
    }

	private void Move() {
		//rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
		transform.Translate(velocity * Time.fixedDeltaTime);
	}

	private void OnTriggerEnter(Collider other) {
		//Debug.Log("Triggered!");
		if (other.GetComponent<Rigidbody>() == null) {
			//Debug.Log("Reverse");
			velocity *= -1; // reverse velocity when bumping into static colliders
		}
	}
}
