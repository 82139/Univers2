using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLighting : MonoBehaviour {

	float Width;

	// Use this for initialization
	void Start () {
		Width = GameObject.FindWithTag("MainCamera").GetComponent<WorldGenerator>().WorldWidth;

		transform.localScale = new Vector3(Width / 20, 5, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
