using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarSpawner : MonoBehaviour
{
    public List<Object> cars;
    float lastSpawnedTime;

    // Update is called once per frame
    void Update()
    {
        lastSpawnedTime += Time.deltaTime;
        if(lastSpawnedTime > 1)
        {
            lastSpawnedTime = 0;
            Debug.Log(cars.Count);
            Object c = Instantiate(cars[Random.Range(0,cars.Count)],transform.position,transform.rotation);
        }
    }
}
