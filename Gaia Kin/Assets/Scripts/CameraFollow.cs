using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public GameObject background;
	public float smoothSpeed = 0.125f;
	float minX, maxX, minY, maxY;

	void GetMinAndMax() {
		// TODO: Figure out how to use the actual width and height

		//float width = background.GetComponent<SpriteRenderer>().bounds.size.x;
		//float height = background.GetComponent<SpriteRenderer>().bounds.size.y;
		minX = -6.5f;//width / 4 * -1;// + 5f;
		maxX = 6.5f;// width / 2;// - 5f;
		minY = -6.5f;//height / 2 * -1 + 5f;
		maxY = 6.5f;//height / 2 - 5f;
		
	}

	void Start() {
		GetMinAndMax();
	}

	void LateUpdate() {

		Vector3 temp = transform.position;

		if (target.position.x > minX && target.position.x < maxX) { 
			temp.x = target.position.x;
		} else {
		}

		if (target.position.y > minY && target.position.y < maxY) { 
			temp.y = target.position.y;
		} 

		if (temp.x != transform.position.x || temp.y != transform.position.y) {
				transform.position = temp;
		}
		
	}
}
