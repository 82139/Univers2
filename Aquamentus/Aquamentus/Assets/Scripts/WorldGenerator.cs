using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldGenerator : MonoBehaviour {

	public GameObject BG_SAND_LEFT_SIDE;
	public GameObject BG_SAND_RIGHT_SIDE;
	public GameObject BG_LEFT_SIDE;
	public GameObject BG_RIGHT_SIDE;
	public GameObject BG_SURFACE_LEFT_SIDE;
	public GameObject BG_SURFACE_RIGHT_SIDE;
	public GameObject BG_WATER;
	public GameObject BG_WATER_SURFACE;
	public GameObject BG_SAND1;
	public GameObject BG_SAND2;
	public GameObject BG_SAND3;
	public GameObject BG_SAND4;
	public GameObject BG_SAND5;

	public int WaterQuality = 0;
	public bool PumpKaput;
	public float WaterQualityTimer = 1000;

	public Text WaterQualityText;

	public GameObject Food;
	bool SpawnFood = true;

	public GameObject Pump;

	public GameObject Lighting;

	int RandomSand;

	public GameObject PLANT;
	public GameObject PLANT2;
	public GameObject PLANT_BG;
	public GameObject BUBBLE;
	public GameObject Fish;

	float Width;
	float Height;

	float WorldHeight = 50;
	public float WorldWidth = 50;

	int RandomPlacement;
	float RandomBubblePlacement;
	bool SpawnBubblee = true;

	// Use this for initialization
	void Start () {

		WorldWidth = 200;

		Instantiate(Lighting, new Vector3(WorldWidth / 2, 25, 9), Quaternion.identity);
		Instantiate(Pump, new Vector3(6.5f, 40, 0), Quaternion.identity);

		for (Width = 0; Width < WorldWidth; Width += 5){
			for (Height = 0; Height < WorldHeight; Height += 5){


					//Center
					if (Width > 5 && Width < WorldWidth - 5 && Height == 5){

						RandomSand = Random.Range(0, 5);

						switch (RandomSand){
							case 0: 
								Instantiate(BG_SAND1, new Vector3(Width, Height, 7), Quaternion.identity);
							break; 

							case 1: 
								Instantiate(BG_SAND2, new Vector3(Width, Height, 7), Quaternion.identity);
							break; 

							case 2: 
								Instantiate(BG_SAND3, new Vector3(Width, Height, 7), Quaternion.identity);
							break; 

							case 3: 
								Instantiate(BG_SAND4, new Vector3(Width, Height, 7), Quaternion.identity);
							break; 

							case 4: 
								Instantiate(BG_SAND5, new Vector3(Width, Height, 7), Quaternion.identity);
							break; 
						}


						Width += 7.5f;

						RandomPlacement = Random.Range(0, 4);

						if (RandomPlacement == 0) {
							Instantiate(PLANT, new Vector3(Width, Height + 8, -2), Quaternion.identity);
						}
						if (RandomPlacement == 2) {
							Instantiate(PLANT2, new Vector3(Width, Height + 3.5f, -2), Quaternion.identity);
						}

						if (RandomPlacement == 3 || RandomPlacement == 2) {
							Instantiate(PLANT_BG, new Vector3(Width, Height + 5, 8), Quaternion.identity);
						}
					}

					if (Width < WorldWidth - 18){
						Instantiate(BG_WATER, new Vector3(Width + 10, 35, 10), Quaternion.identity);
					}
					



			}
		}

		Instantiate(Fish, new Vector3(10, 5, -2), Quaternion.identity);
		Instantiate(Fish, new Vector3(10, 10, -2), Quaternion.identity);
		Instantiate(Fish, new Vector3(10, 15, -2), Quaternion.identity);
		Instantiate(Fish, new Vector3(10, 20, -2), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {

		if (WaterQuality == 0) {
		WaterQualityText.text = "WATERQUALITY: GOOD";
		}
		if (WaterQuality == 1) {
		WaterQualityText.text = "WATERQUALITY: MEDIUM";
		}
		if (WaterQuality == 2) {
		WaterQualityText.text = "WATERQUALITY: BAD";
		}
		if (WaterQuality == 3) {
		WaterQualityText.text = "WATERQUALITY: SUPER BAD";
		}
		if (WaterQuality == 4) {
		WaterQualityText.text = "WATERQUALITY: AWFUL";
		}

		if (SpawnBubblee == true) {
			Instantiate(BUBBLE, new Vector3(Random.Range(WorldWidth - WorldWidth + 5, WorldWidth - 5), Random.Range(WorldHeight - WorldHeight + 5, WorldHeight - 5), -1), Quaternion.identity);
			StartCoroutine(SpawnBubble());
			SpawnBubblee = false;
		}

		if (SpawnFood == true){
			Instantiate(Food, new Vector3(Random.Range(WorldWidth - WorldWidth + 5, WorldWidth - 5), WorldHeight, -1), Quaternion.identity);
			StartCoroutine(FoodSpawn());
			SpawnFood = false;
		}

		if (PumpKaput == true){
			if (WaterQualityTimer > 0){
				WaterQualityTimer -= 1;
			}else{
				WaterQuality += 1;
				WaterQualityTimer = Random.Range(500, 1000);
			}
		}

	}

	IEnumerator SpawnBubble(){
		yield return new WaitForSeconds(0.05f);
		SpawnBubblee = true;
	}

	IEnumerator FoodSpawn(){
		yield return new WaitForSeconds(Random.Range(1, 20));
		SpawnFood = true;
	}
}
