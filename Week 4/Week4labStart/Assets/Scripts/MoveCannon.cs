using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCannon : MonoBehaviour
{
    public GameObject CannonHeadPart;
    public GameObject Player;

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
        RotateWholeCannon(Player);
        RotateHeadCanon(Player);
    }

    void RotateWholeCannon(GameObject at)
    {
        Vector3 relativePos = at.transform.position - transform.position;
        Quaternion toPlayerRotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = new Quaternion(
            x: transform.rotation.x, 
            y: toPlayerRotation.y, 
            z: transform.rotation.z, 
            w: transform.rotation.w);
    }
    void RotateHeadCanon(GameObject at)
    {
        // Can be simplified using proper quaternions
        Vector3 relativePos = at.transform.position - CannonHeadPart.transform.position;
        Debug.DrawRay(transform.position, relativePos);
        Quaternion toPlayerRotation = Quaternion.LookRotation(relativePos, Vector3.up);
        CannonHeadPart.transform.rotation = toPlayerRotation;
        CannonHeadPart.transform.Rotate(0, 0, 90);
    }
}
