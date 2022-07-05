using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCannon : MonoBehaviour
{
    public GameObject CannonHeadPart;
    public GameObject Player;
    public float CannonRotationMaxSpeed = 1f;
    public float CannonHeadRotationMaxSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.GetChild(0).name);
        if (CannonHeadPart == null) CannonHeadPart = transform.Find("CannonHeadPart").gameObject;
        if (Player == null) Player = transform.parent.Find("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCannon();
    }

    public bool EasedMotion = true;
    void RotateCannon()
    {
        // Gets the relative displacement from player to cannon
        Vector3 relativePos = Player.transform.position - CannonHeadPart.transform.position;

        // Rotate Base of Turret left to right
        Vector3 relativePosXZPlane = new Vector3(relativePos.x, 0, relativePos.z);
        Quaternion rotationToLookAt = Quaternion.LookRotation(relativePosXZPlane);
        
        // Instantly 
        if(!EasedMotion)
            transform.rotation = rotationToLookAt;
        
        // Eased
        else
            transform.rotation = Quaternion.Lerp(
                a: transform.rotation, 
                b: rotationToLookAt, 
                t: Time.deltaTime * CannonRotationMaxSpeed
            );

        // Rotate Head of turrent up and down
        Vector3 rotationToLookAt2 = Quaternion.LookRotation(relativePos).eulerAngles;

        // Instantly 
        if(!EasedMotion)
            CannonHeadPart.transform.localRotation = Quaternion.Euler(
                        x: rotationToLookAt2.x,
                        y: 0,
                        z: 90);

        // Eased
        else
            CannonHeadPart.transform.localRotation = Quaternion.Lerp(
                    a: CannonHeadPart.transform.localRotation,
                    b: Quaternion.Euler(
                        x: rotationToLookAt2.x,
                        y: 0,
                        z: 90),
                    t: Time.deltaTime * CannonHeadRotationMaxSpeed
            );
    }
}
