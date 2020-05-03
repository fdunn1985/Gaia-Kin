using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	//public Camera camera;
	public Transform target;
	public GameObject background;
	public float smoothSpeed = 0.125f;
	private float threshold = 1f;
	float minX, maxX, minY, maxY;
	float camLeft, camRight, camTop, camBottom;

	void GetMinAndMax() {
		float width = background.GetComponent<SpriteRenderer>().bounds.size.x;
		float height = background.GetComponent<SpriteRenderer>().bounds.size.y;
		print("Width: " + width);
		print("Height: " + height);
		minX = width / 2 * -1 + 5f;
		maxX = width / 2 - 5f;
		minY = height / 2 * -1 + 5f;
		maxY = height / 2 - 5f;
		
	}

	void Start() {
		GetMinAndMax();
	}

	void LateUpdate() {
		SetCameraBoundsValues();

		Vector3 temp = transform.position;

		if (camLeft > minX && camRight < maxX && target.position.x > minX && target.position.x < maxX ) {
			print("Temp X: " + temp.x + " CamLeft: " + camLeft + " MinX: " + minX);
			temp.x = target.position.x;
		} else {
			//print("Min/Max X hit: " + target.position.x);
			print("OOB -- Temp X: " + temp.x + " CamLeft: " + camLeft + " MinX: " + minX);
		}

        if (camTop > minY && camBottom < maxY) {
			temp.y = target.position.y;
		} 
		//else {
		//	print("Min/Max Y hit: " + target.position.y);
		//}

		if (temp.x != transform.position.x || temp.y != transform.position.y) {
			if (temp.x > (minX + threshold)*2 && temp.x < (maxX - threshold)*2 && temp.y > (minY + threshold) && temp.y < (maxY - threshold)) {
				transform.position = temp;
			}
		}
		
	}

	void SetCameraBoundsValues() {
		var lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
		var upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		camLeft = lowerLeft.x + 5f;
		camRight = upperRight.x - 5f;
		camTop = upperRight.y - 5f;
		camBottom = lowerLeft.y + 5f;
	}
}
