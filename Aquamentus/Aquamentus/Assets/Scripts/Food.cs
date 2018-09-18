using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	float Speed = 0.01f;
	float Ypos;
	public float FoodLeft = 10;

	public GameObject Explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Ypos = transform.position.y;

		if(Ypos > 4) {
			transform.Translate(new Vector3(0, -Speed, 0));
		}

		if (Speed < 1){
			Speed += 0.001f;
		}

		if (FoodLeft < 1){
			Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, -5), Quaternion.Euler(new Vector3(-90, 0, 0)));
			Destroy(gameObject);
		}
	}

	
}
