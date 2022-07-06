using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBalls : MonoBehaviour
{
    public GameObject cannonBall;
    private float time = 0;
    void Update()
    {
        Debug.Log(transform.parent.GetComponent<MoveCannon>().PlayerSeen);
        if (time > 0.5000f && transform.parent.GetComponent<MoveCannon>().PlayerSeen)
        {
            Debug.Log("Shooott");
            time = 0;
            GameObject cb = Instantiate(cannonBall,transform.position + transform.forward * 3, transform.rotation,null);
            
            Rigidbody cbr = cb.GetComponent<Rigidbody>();
            cbr.velocity = transform.forward * 50f;
        }
        time += Time.deltaTime;

    }
}
