using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Head;
    [SerializeField]
    public float WalkSpeedMultiplier = 1;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        RotateBody();
        RotateHead();
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        float walkspeed = 10f * Time.deltaTime;

        // move forward/backward
        transform.Translate(0, 0, Input.GetAxis("Vertical") * WalkSpeedMultiplier * walkspeed);
        
        // reset if out of boundary
        if (isOutOfBoundary())
        {
            transform.Translate(0, 0, -Input.GetAxis("Vertical") * WalkSpeedMultiplier * walkspeed);
        }

        // move left/right
        transform.Translate(Input.GetAxis("Horizontal") * WalkSpeedMultiplier * walkspeed, 0 , 0);

        if (isOutOfBoundary())
        {
            transform.Translate(-Input.GetAxis("Horizontal") * WalkSpeedMultiplier * walkspeed, 0, 0);
        }
    }

    bool isOutOfBoundary()
    {
        if (transform.position.x > 15f || transform.position.x < -15f || transform.position.z > 15f || transform.position.z < -15f)
        {
            return true;
        }
        else
            return false;
    }

    void RotateBody()
    {
        transform.Rotate(
            xAngle: 0,
            yAngle: Input.GetAxis("Mouse X"),
            zAngle: 0);
    }
    
    void RotateHead()
    {
        Head.transform.Rotate(
            xAngle: Input.GetAxis("Mouse Y"),
            yAngle: 0,
            zAngle: 0);
    }

}
