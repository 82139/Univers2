using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDestroy : MonoBehaviour {

	float timer = 500;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= 1;

		if (timer < 0){
			Destroy(gameObject);
		}
	}
}
