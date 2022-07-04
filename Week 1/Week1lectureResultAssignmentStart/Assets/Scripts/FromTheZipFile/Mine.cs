using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
	public Transform player;
	public float triggerDistance = 1;
	public int damage = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	// Update is called once per frame
	void Update() {
		float distance = (player.position - transform.position).magnitude;

		if (distance < triggerDistance) {
			Debug.Log("BIG EXPLOSION!");
			Destroy(gameObject);

			Health health = player.gameObject.GetComponent<Health>();
			if (health!=null) {
				health.TakeDamage(damage);
			}
		}


	}
}
