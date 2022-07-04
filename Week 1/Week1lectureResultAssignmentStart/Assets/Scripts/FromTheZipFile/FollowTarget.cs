using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	public Transform target;
	Vector3 offset = new Vector3(0, 0, 0);
	[Range(-1,5)]
	public float scale = 1;

    // Start is called before the first frame update
    void Start()
    {
		offset = transform.position - target.position;

		Debug.Log("Offset length: " + offset.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = target.position + offset * scale;

		transform.rotation = target.rotation;
    }
}
