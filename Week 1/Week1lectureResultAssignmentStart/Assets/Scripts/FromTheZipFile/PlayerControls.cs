using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

	[Range(0.01f,1)]
	public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {

    }

	// Update is called once per frame
	void Update() {
		Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;

		transform.position += moveVector;

		if (moveVector.magnitude>0) {
			transform.rotation = Quaternion.LookRotation(moveVector);
		}

	}
}
