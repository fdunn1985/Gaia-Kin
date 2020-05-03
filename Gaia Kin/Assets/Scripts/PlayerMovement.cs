using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 2.0f;
	private Rigidbody2D myBody;
	private float maxVelocity = 2.0f;

	void Awake() {
		myBody = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float forceY, forceX, vel;
		Vector3 temp;

		// Keyboard Movement
		if (Input.GetKey("w")) {
			//Vector3 temp = transform.localScale;
			//temp.y -= speed;
			//transform.localScale = temp;

			forceY = 0f;
			vel = Mathf.Abs(myBody.velocity.y);

			if (vel < maxVelocity) {
				forceY = speed;
			}

			temp = transform.position;
			temp.y += forceY;
			transform.position = temp;
			//myBody.AddForce(new Vector2(0, forceY));
		}

		if (Input.GetKey("s")) {

			forceY = 0f;
			vel = Mathf.Abs(myBody.velocity.y);

			if (vel < maxVelocity) {
				forceY = -speed;
			}

			temp = transform.position;
			temp.y += forceY;
			transform.position = temp;
		}

		if (Input.GetKey("a")) {
			forceX = 0f;
			vel = Mathf.Abs(myBody.velocity.x);

			temp = transform.localScale;
			temp.x = -Mathf.Abs(temp.x);
			transform.localScale = temp;

			if (vel < maxVelocity) {
				forceX = -speed;
			}

			temp = transform.position;
			temp.x += forceX;
			transform.position = temp;
		}

		if (Input.GetKey("d")) {
			forceX = 0f;
			vel = Mathf.Abs(myBody.velocity.x);

			temp = transform.localScale;
			temp.x = Mathf.Abs(temp.x);
			transform.localScale = temp;

			if (vel < maxVelocity) {
				forceX = speed;
			}

			temp = transform.position;
			temp.x += forceX;
			transform.position = temp;
		}
	}
}
