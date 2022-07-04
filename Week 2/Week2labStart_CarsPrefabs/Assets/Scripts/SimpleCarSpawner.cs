using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarSpawner : MonoBehaviour
{
    public Object car;


    // Start is called before the first frame update
    void Start()
    {
    }




    float lastSpawnedTime;

    // Update is called once per frame
    void Update()
    {
        lastSpawnedTime += Time.deltaTime;
        Debug.Log(lastSpawnedTime);
        if(lastSpawnedTime > 1)
        {
            lastSpawnedTime = 0;
            Instantiate(car,transform.position,transform.rotation);
        }
    }
}
