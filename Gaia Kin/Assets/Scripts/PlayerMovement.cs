using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 2.0f;
	private Rigidbody2D myBody;
	private float maxVelocity = 2.0f;

	//Screen limits
	private float minX, minY, maxX, maxY;
	private float bgWidth, bgHeight, playerWidth, playerHeight;

	void Awake() {
		myBody = GetComponent<Rigidbody2D>();

		GameObject bg = GameObject.Find("BasicGround2");
		bgWidth = bg.GetComponent<SpriteRenderer>().bounds.size.x;
		bgHeight = bg.GetComponent<SpriteRenderer>().bounds.size.y;
		playerWidth = this.GetComponent<SpriteRenderer>().bounds.size.x;
		playerHeight = this.GetComponent<SpriteRenderer>().bounds.size.x;

		maxX = bgWidth / 2 - playerWidth / 2;
		minX = -maxX;
		maxY = bgHeight / 2 - playerHeight / 2;
		minY = -maxY;
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

			if ((transform.position.y) + forceY <= maxY) { 
				temp = transform.position;
				temp.y += forceY;
				transform.position = temp;
			}
			//myBody.AddForce(new Vector2(0, forceY));
		}

		if (Input.GetKey("s")) {

			forceY = 0f;
			vel = Mathf.Abs(myBody.velocity.y);

			if (vel < maxVelocity) {
				forceY = -speed;
			}

			if ((transform.position.y + forceY) >= minY) {
				temp = transform.position;
				temp.y += forceY;
				transform.position = temp;
			}
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

			if ((transform.position.x + forceX) >= minX) { 
				temp = transform.position;
				temp.x += forceX;
				transform.position = temp;
			}
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

			if ((transform.position.x + forceX) <= maxX) {
				temp = transform.position;
				temp.x += forceX;
				transform.position = temp;
			}
		}
	}
}
