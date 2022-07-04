using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
	public float speed = 0.1f;


    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButton(0)) {
			transform.Rotate(0, Input.GetAxis("Mouse X") * speed, 0);
		}
    }
}
