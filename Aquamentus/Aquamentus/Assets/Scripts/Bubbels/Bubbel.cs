using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbel : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		speed = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {

			transform.Translate(new Vector3(0, 0.1f, 0));

			speed -= 0.1f;

			transform.localScale = new Vector3(speed, speed, 0);

			if (speed <= 0){
				Destroy(gameObject);
			}
	}
}
