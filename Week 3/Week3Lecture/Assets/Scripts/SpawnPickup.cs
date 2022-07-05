using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickup : MonoBehaviour
{
	public GameObject prefab;
	public float emptyRadius;
	public Vector3 spawnPositionCorner;
	public Vector3 spawnRange;

	GameObject lastSpawn = null;

    void Update()
    {
        if (lastSpawn==null) {
			//Find an empty place to spawn a pickup:
			Vector3 spawnPosition = 
				spawnPositionCorner +
				new Vector3(
					Random.value * spawnRange.x,
					Random.value * spawnRange.y,
					Random.value * spawnRange.z
				);
			// Test whether it's really empty:
			if (Physics.OverlapSphere(spawnPosition,emptyRadius).Length==0) {
				// Create a copy of [prefab] at position [spawnPosition], with no rotation, and
				// store the copy in the variable lastSpawn:
				lastSpawn = Instantiate(prefab, spawnPosition, Quaternion.identity);
				Debug.Log("Spawning pickup at "+spawnPosition);
			}
		}
    }
}
