using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	float SpeedX;
	float SpeedY;

	float Ypos;
	float Xpos;

	public float WayPointX;
	public float WayPointY;

	float WorldWidth;

	float Heightup;
	float HeightDown;
	float WidthLeft;
	float WidthRight;

	bool calculate = true;

	float Speed = 1f;

	// Use this for initialization
	void Start () {
			transform.position = new Vector3(25, 15, -20);

	}
	
	// Update is called once per frame
	void Update () {

		//Scrolling

			if (Input.GetAxis("Mouse ScrollWheel") < 0){
				if (gameObject.GetComponent<Camera>().orthographicSize <= 20)
				gameObject.GetComponent<Camera>().orthographicSize += 10;
			}
			else
			if (Input.GetAxis("Mouse ScrollWheel") > 0){
				if (gameObject.GetComponent<Camera>().orthographicSize >= 20)
				gameObject.GetComponent<Camera>().orthographicSize -= 10;
			}

		//endscrolling

		Xpos = transform.position.x;
		Ypos = transform.position.y;

		WorldWidth = this.GetComponent<WorldGenerator>(). WorldWidth;
		transform.Translate(new Vector3(SpeedX, SpeedY, 0));

	if (calculate == true) {
			Heightup = 55;
			HeightDown = 11;
			WidthLeft = 25;
			WidthRight = WorldWidth - 30;

			calculate = false;
	}

		if (Input.GetKey("w")){
			if (Ypos < Heightup) {
			SpeedY = Speed;
			}else{
				SpeedY = 0;
			}
		}
		if (Input.GetKeyUp("w")){
			SpeedY = 0;
		}

		if (Input.GetKey("s")){
			if (Ypos > HeightDown) {
			SpeedY = -Speed;
			}else{
				SpeedY = 0;
			}
		}
		if (Input.GetKeyUp("s")){
			SpeedY = 0;
		}

		if (Input.GetKey("d")){
			if (Xpos < WidthRight) {
			SpeedX = Speed;
			}else{
				SpeedX = 0;
			}
		}
		if (Input.GetKeyUp("d")){
			SpeedX = 0;
		}

		if (Input.GetKey("a")){
			if (Xpos > WidthLeft) {
			SpeedX = -Speed;
			}else{
				SpeedX = 0;
			}
		}
		if (Input.GetKeyUp("a")){
			SpeedX = 0;
		}


	}
}
