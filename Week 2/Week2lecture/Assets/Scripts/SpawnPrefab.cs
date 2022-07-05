using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 spawnRange;

    private GameObject instantiatedPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (instantiatedPrefab==null) {
            Vector3 spawnPosition = transform.position + new Vector3(
                Random.value * spawnRange.x,
                Random.value * spawnRange.y,
                Random.value * spawnRange.z
            );
            var overlaps = Physics.OverlapSphere(spawnPosition, 1);
            if (overlaps.Length == 0) {
                instantiatedPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);
            } else {
                Debug.Log("Overlapping with " + overlaps[0].name); // Try again next frame...
			}
		}
    }
}
