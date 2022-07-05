using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float speed = 1;
    private float dir = 1;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 4) dir = -1;
        if (transform.position.y < 1.2f) dir = 1;
        transform.Translate(0, dir * speed * 0.01f, 0);
    }
}
