using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VelocityTools : MonoBehaviour
{
	Rigidbody rb;

    void Start()
    {
		rb=GetComponent<Rigidbody>();
    }

	/// <summary>
	/// Projects the current velocity on a given axis.
	/// This way you can split the velocity up into a forward, right, and up component
	///  (that when added together, give the original velocity).
	/// This is useful for creating fine tuned controls, like car controls.
	/// </summary>
	/// <param name="axis"></param>
	/// <returns></returns>
	public Vector3 GetVelocityComponent(Vector3 axis) {
		// @Engineers: you recognize this formula as *vector projection* from Physics Programming:
		axis.Normalize();
		return axis * Vector3.Dot(axis, rb.velocity);
	}

	/// <summary>
	/// Projects the current velocity on the model's x-axis (=right).
	/// This way you can get the part of the velocity that is directed sideways.
	/// </summary>
	public Vector3 GetRightVelocity() {
		return GetVelocityComponent(transform.right);
	}

	/// <summary>
	/// Projects the current velocity on the model's z-axis (=forward).
	/// This way you can get the part of the velocity that is directed forward/backward.
	/// </summary>
	public Vector3 GetForwardVelocity() {
		return GetVelocityComponent(transform.forward);
	}

	/// <summary>
	/// Projects the current velocity on the model's y-axis (=up).
	/// This way you can get the part of the velocity that is directed up/down.
	/// </summary>
	public Vector3 GetUpVelocity() {
		return GetVelocityComponent(transform.up);
	}
}
