using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsControls : MonoBehaviour
{

    Rigidbody rb;
    public float force;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per physics frame (a fixed #times per second)
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //transform.position += move * Time.deltaTime; // bad! (with physics)

        rb.AddForce(move * force);

    }

	private void OnCollisionExit(Collision collision) {
        var colorChanger = GetComponent<ChangeColor>();
        colorChanger.SetColor(Color.red);
	}
}
