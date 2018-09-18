using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pump : MonoBehaviour {

	public Sprite NormalPump;
	public Sprite NormalPumpSelected;

	public GameObject PumpUI;

	public GameObject bubble;

	bool Selected = false;
	public float KaputTimer = 5000;
	public bool IsKaput = false;
	bool SpawnKaputIcon = true;

	public GameObject KaputIcon;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = NormalPump;
		bubble.SetActive(true);
		PumpUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Selected == true){
			gameObject.GetComponent<SpriteRenderer>().sprite = NormalPumpSelected;
			PumpUI.SetActive(true);
		}else{
			gameObject.GetComponent<SpriteRenderer>().sprite = NormalPump;
			PumpUI.SetActive(false);
		}

		if (Input.GetMouseButtonDown(1)){
			Selected = false;
		}

		if (KaputTimer > 0){
			KaputTimer -= 1;
			bubble.SetActive(true);
			SpawnKaputIcon = true;
			GameObject.FindWithTag("MainCamera").GetComponent<WorldGenerator>().PumpKaput = false;
			GameObject.FindWithTag("MainCamera").GetComponent<WorldGenerator>().WaterQuality = 0;
			GameObject.FindWithTag("MainCamera").GetComponent<WorldGenerator>().WaterQualityTimer = Random.Range(500, 1000);
		}else{
			bubble.SetActive(false);
			IsKaput = true;
			GameObject.FindWithTag("MainCamera").GetComponent<WorldGenerator>().PumpKaput = true;
		}

		if (IsKaput == true){
			if (SpawnKaputIcon == true){
				//Instantiate(KaputIcon, new Vector3(transform.position.x, transform.position.y, -6), Quaternion.identity);
				SpawnKaputIcon = false;
			}
		}
		
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown(0)){
			Selected = true;
		}
	}

	public void Repair(){
		if (IsKaput == true){
			KaputTimer = Random.Range(5000, 10000);
			IsKaput = false;
		}
	}
}
