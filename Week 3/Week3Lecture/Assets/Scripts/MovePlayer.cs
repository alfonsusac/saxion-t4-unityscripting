using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Control { Input, Random}

public class MovePlayer : MonoBehaviour
{
	public Control control;
	public float moveSpeed;
	public float turnSpeed;

	Rigidbody rb;

	float move;
	float turn;
	float angleChange;

	bool grounded;

    void Start()
    {
		rb=GetComponent<Rigidbody>();
    }

	public void Update() {
		if (control==Control.Input) {
			KeyControls();
		} else {
			AutoControls();
		}
	}

	void KeyControls() {
		move = Input.GetAxis("Vertical");
		turn = Input.GetAxis("Horizontal");
	}

	void AutoControls() {
		if (angleChange!=0) {
			turn = Mathf.Sign(angleChange);
		} 
		move=1;
	}

	void FixedUpdate()
    {
		if (CheckGrounded()) {
			if (turn!=0) {
				float oldAngleChange = angleChange;
				float frameTurn = turn * turnSpeed * Time.fixedDeltaTime;
				angleChange-=frameTurn;
				if (angleChange * oldAngleChange<0) {
					angleChange=0;
					turn=0;
				}

				transform.Rotate(0, frameTurn, 0);
			}
			rb.velocity = transform.forward * moveSpeed * move + new Vector3(0,rb.velocity.y,0);
		} 
    }

	bool CheckGrounded() {
		return Physics.Raycast(transform.position, Vector3.down, 1.1f);
	}

	private void OnCollisionStay(Collision collision) {
		// When colliding with a wall, choose a random turn angle, unless an angle was already chosen:
		if (angleChange==0 && collision.GetContact(0).normal.y<0.7f) {
			angleChange = Random.value * 360 - 180;
		}
	}
}
