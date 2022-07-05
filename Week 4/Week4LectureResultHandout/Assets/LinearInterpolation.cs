using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearInterpolation : MonoBehaviour
{
	public Transform transformA;
	public Transform transformB;
	[Range(0,1)]
	public float interpolation=0.5f;
	public bool interpolatePosition;
	public bool interpolateRotation;

    void Update()
    {
		if (interpolatePosition) {
			// Pick your favorite way to do the same thing:
			transform.position =
				//transformA.position * (1-interpolation) + transformB.position * interpolation;
				Vector3.Lerp(transformA.position, transformB.position, interpolation);
		}
		if (interpolateRotation) {			
			transform.rotation = Quaternion.Lerp(transformA.rotation, transformB.rotation, interpolation);
		}        
    }
}
