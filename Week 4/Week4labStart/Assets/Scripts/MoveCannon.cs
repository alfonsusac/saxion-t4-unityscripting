using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Smoothing { None, Lerp, Slerp, MoveTowards}

public class MoveCannon : MonoBehaviour
{
    public Smoothing SmoothingMethod;
    public GameObject CannonHeadPart;
    public GameObject Player;

    public float CannonRotationMaxSpeed = 1f;
    public float CannonHeadRotationMaxSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (CannonHeadPart == null) CannonHeadPart = transform.Find("CannonHeadPart").gameObject;
        if (Player == null)         Player = transform.parent.Find("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePositionToPlayer = GetRelativePosition();
        (GameObject objectHit, bool isPlayerVisible) = IsPlayerVisible(relativePositionToPlayer);
        if (isPlayerVisible && objectHit.name == "Player")
        {
            RotateCannon(relativePositionToPlayer);
        }
    }

    (GameObject, bool) IsPlayerVisible(Vector3 relativePosition)
    {
        RaycastHit hitInfo;
        Debug.DrawRay(CannonHeadPart.transform.position, relativePosition);
        if (Physics.Raycast(CannonHeadPart.transform.position, relativePosition, out hitInfo, Mathf.Infinity))
            return (hitInfo.transform.gameObject, true);
        else
            return (null, false);
    }
    Vector3 GetRelativePosition()
    {
        return Player.transform.position - CannonHeadPart.transform.position;
    }
    void RotateCannon(Vector3 relativePosition)
    {
        // Gets the relative displacement from player to cannon
        Vector3 relativePos = Player.transform.position - CannonHeadPart.transform.position;

        // Rotate Base of Turret left to right
        Vector3 relativePosXZPlane = new Vector3(relativePos.x, 0, relativePos.z);
        Quaternion rotationToLookAt = Quaternion.LookRotation(relativePosXZPlane);
        InstantRotation(transform, rotationToLookAt);

        // Rotate Head of turrent up and down
        Vector3 eulerRotation = Quaternion.LookRotation(relativePos).eulerAngles;
        Quaternion newRotation = Quaternion.Euler(eulerRotation.x, 0, 90);
        InstantRotation(CannonHeadPart.transform, newRotation, localRotation: true);
    }

    void InstantRotation(Transform obj, Quaternion rotateTo, bool localRotation = false)
    {
        Quaternion rotationStep = new Quaternion();
        // Instant
        if (SmoothingMethod == Smoothing.None)
            rotationStep = rotateTo;

        // Eased
        else if (SmoothingMethod == Smoothing.Lerp)
            rotationStep = Quaternion.Lerp(
                a: localRotation ? obj.localRotation : obj.rotation,
                b: rotateTo,
                t: Time.deltaTime * CannonRotationMaxSpeed
            );

        //Slerp
        else if (SmoothingMethod == Smoothing.Slerp)
            rotationStep = Quaternion.Slerp(
                a: localRotation ? obj.localRotation : obj.rotation,
                b: rotateTo,
                t: Time.deltaTime * CannonRotationMaxSpeed
            );

        //Constant Movement
        else if (SmoothingMethod == Smoothing.MoveTowards)
            rotationStep = Quaternion.RotateTowards(
                           from: localRotation ? obj.localRotation : obj.rotation,
                             to: rotateTo,
                maxDegreesDelta: 1f
            );

        if (localRotation) obj.localRotation = rotationStep;
        else obj.rotation = rotationStep;
    }
}
