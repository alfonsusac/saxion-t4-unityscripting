using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;
        transform.position += move * Time.deltaTime;

        if (move.magnitude > 0) {
            transform.rotation = Quaternion.LookRotation(move);
        }
        /*
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-0.01f, 0, 0);
		}
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += new Vector3(0.01f, 0, 0);
        }*/
    }
}
