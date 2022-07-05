using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public Transform target;
    public float hitRadius = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = target.position - transform.position;

        if (difference.magnitude < hitRadius) {
            Debug.Log("BOOOOM!");

            target.GetComponent<PlayerControls>().speed = 0;
        }
        //Debug.Log(difference);
    }
}
