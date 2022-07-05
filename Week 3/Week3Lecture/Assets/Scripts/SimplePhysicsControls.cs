using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lecture2Result {
	public enum ControlType {Force, Velocity, Position}

	public class SimplePhysicsControls : MonoBehaviour {

		public ControlType control;

		public float moveForce;
		public float moveSpeed;
		public float jumpPower;
		public float raycastLength = 1.1f;

		Rigidbody rb;

		public bool grounded; // Shouldn't be public, but just for demo...

		void Start() {
			rb=GetComponent<Rigidbody>();
			rb.sleepThreshold = 0;
		}

		private void Update() {
			grounded = IsGrounded();

			if (Input.GetKeyDown(KeyCode.Space) && grounded) {
				rb.AddForce(Vector3.up * jumpPower);
			}
		}

		public bool IsGrounded() {
			Debug.DrawRay(transform.position, new Vector3(0, -1, 0) * raycastLength, Color.red);

			RaycastHit hitInfo;

			if (Physics.Raycast(transform.position, new Vector3(0,-1,0), out hitInfo, raycastLength)) {	
				// It's not great to do this here, but for demo purposes...:
				if (hitInfo.collider.GetComponent<MovePlatform>() != null) {
					transform.parent = hitInfo.collider.transform; // Moving platform becomes parent!
				} else {
					transform.parent = null;
				}

				return true;
			}
			return false;
		}


		void FixedUpdate() {
			Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		
			if (IsGrounded()) {
				control = ControlType.Velocity;
			} else {
				control = ControlType.Force;
			}

			switch (control) {
				case ControlType.Position:
					transform.Translate(moveVector * moveSpeed);
					break;
				case ControlType.Force:
					rb.AddForce(moveVector * moveForce);
					break;
				case ControlType.Velocity:
					// Preserving the velocity.y helps to keep movement correct on slopes, and
					// helps with correct gravity when also using velocity controls while not grounded
					// (added after the lecture)
					rb.velocity = moveVector * moveSpeed + new Vector3(0,rb.velocity.y,0);
					break;
			}
			//grounded = false;
		}

		private void OnCollisionStay(Collision collision) {
			// visualize normal:
			//Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal);

			if (collision.contacts[0].normal.y > 0.7f) {
				//grounded = true;
			}
		}

		private void OnCollisionExit(Collision collision) {
			//grounded = false;
		}
	}
}
