using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ConfigureVehicle : MonoBehaviour
{
    void Start()
    {
        Rigidbody rb=GetComponent<Rigidbody>();
		// We set the center of mass low, to make sure that we usually "land on our feet" when doing stunts:
		rb.centerOfMass=new Vector3(0, -0.5f, 0);
    }
}
