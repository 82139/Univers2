using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

	private Vector3 Waypoint;
	float speed = 100f;

	public float Xpos;
	public float Ypos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Xpos = transform.position.x;
		Ypos = transform.position.y;

		GameObject.FindWithTag("MainCamera").GetComponent<CameraMovement>().WayPointX = Xpos;
		GameObject.FindWithTag("MainCamera").GetComponent<CameraMovement>().WayPointY = Ypos;

		Waypoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Waypoint.z = transform.position.z;

		transform.position = Vector3.MoveTowards(transform.position, Waypoint, speed * Time.deltaTime);

		if (Input.GetMouseButtonDown(0)){
			
		}
	}
}
