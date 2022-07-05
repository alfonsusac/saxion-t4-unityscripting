using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
	public Transform target;
	public bool copyRotation = true;

	Vector3 offset;

    void Start()
    {
		offset = transform.position - target.position;
    }

    void LateUpdate()
    {
		transform.position = target.position + offset;
		if (copyRotation) {
			transform.rotation = target.rotation;
		}
    }
}
