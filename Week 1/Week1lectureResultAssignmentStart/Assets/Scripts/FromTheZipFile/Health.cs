using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public int health = 10;

	public void TakeDamage(int damage) {
		health -= damage;
		Debug.Log("Taking "+damage+" damage! Health="+health);

		if (health<=0) {
			GetComponent<PlayerControls>().speed=0;
			Debug.Log("GAME OVER");
		}
	}
}
