using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {

	float WayPointX;
	float WayPointY;
	float Xpos;
	float Ypos;

	Transform WayPoint;

	float Direction;
	float angle;
	
	float Speed = 0;

	float Rotation;

	bool Selected = false;
	bool Clicked = false;

	bool StartFish = true;

	float Health;
	float HungerLimit;
	float Hunger;
	string FishType;

	float HungerTime = 100;

	public Sprite NormalFish;
	public Sprite NormalFishSelected;

	public Sprite NormalFish2;
	public Sprite NormalFish2Selected;

	public Sprite NormalFish3;
	public Sprite NormalFish3Selected;

	int WaterQuality;
	float WaterQualitytimer;

	int WithFish;

	// Use this for initialization
	void Start () {

		WithFish = Random.Range(1, 4);

		if (WithFish == 1){
			
			WithFish = 1;

			FishType = "NormalFish";
			Hunger = 100;
			HungerLimit = 100;
			Health = 50;	
			gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish;

			}

			if (WithFish == 2){
			
			WithFish = 2;

			FishType = "FISH";
			Hunger = 150;
			HungerLimit = 150;
			Health = 100;	
			gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish2;
			
			}

			if (WithFish == 3){
			
			WithFish = 3;

			FishType = "YellowFish";
			HungerLimit = 200;
			Hunger = 200;
			Health = 200;	
			gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish3;
			
			}

	}
	
	// Update is called once per frame
	void Update () {

			Xpos = transform.position.x;
			Ypos = transform.position.y;

		WaterQuality = GameObject.FindWithTag("MainCamera").GetComponent<WorldGenerator>().WaterQuality;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler (0, 0, angle), 10 * Time.deltaTime);

	if (Health > 0) {
		if (WaterQualitytimer > 0) {
			WaterQualitytimer -= 1;
		}else{
			Health -= WaterQuality;
			WaterQualitytimer = 100;
		}

		if (HungerTime > 0){
			HungerTime -= 1;
		}else{
			Hunger -= 1;
			HungerTime = 100;
		}

		if (Hunger < 1){
			Health -= 1;
		}

		WayPoint = GameObject.FindWithTag("WayPoint").transform;

		Rotation = transform.eulerAngles.z;

		if (Rotation >= 0 && Rotation < 90 || Rotation < 380 && Rotation > 300){
			gameObject.GetComponent<SpriteRenderer>().flipY = false;
		}else{
			gameObject.GetComponent<SpriteRenderer>().flipY = true;
		}


		if (StartFish == false) {
			transform.Translate(new Vector3(Speed, 0, 0));
		}

		
			if (WayPointX + 1f > Xpos && WayPointX - 1f < Xpos && WayPointY + 1f > Ypos && WayPointY - 1f < Ypos){
				Speed = 0;
			}else{
				Speed = 0.1f;
			}


		if (Selected == true){

			if(WithFish == 1) {
			gameObject.GetComponent<SpriteRenderer>().sprite = NormalFishSelected;
			}
			if (WithFish == 2){
				gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish2Selected;
			}

			if (WithFish == 3){
				gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish3Selected;
			}

			GameObject.FindWithTag("MainCamera").GetComponent<FishOverViewUI>().FishUIOn = true;
			GameObject.FindWithTag("MainCamera").GetComponent<FishOverViewUI>().Hunger = Hunger;
			GameObject.FindWithTag("MainCamera").GetComponent<FishOverViewUI>().Health = Health;
			GameObject.FindWithTag("MainCamera").GetComponent<FishOverViewUI>().FishType = FishType;

					Clicked = true;


			if (Input.GetMouseButtonDown(0)){	
				if (Clicked == true){

				if(WithFish == 1) {
				gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish;
				}

				if (WithFish == 2){
				gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish2;
				}

				if (WithFish == 3){
				gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish3;
				}
					GameObject.FindWithTag("MainCamera").GetComponent<FishOverViewUI>().FishUIOn = false;
					
					WayPointX = WayPoint.transform.position.x;
					WayPointY = WayPoint.transform.position.y;

					Vector3 Direction = WayPoint.position - transform.position;
					angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
					//transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				
					Selected = false;
					Clicked = false;
					StartFish = false;

				}

			}

			if (Input.GetMouseButtonDown(1)){

				if(WithFish == 1) {
				gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish;
				}

				if (WithFish == 2){
				gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish2;
				}

				if (WithFish == 3){
				gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish3;
				}
					GameObject.FindWithTag("MainCamera").GetComponent<FishOverViewUI>().FishUIOn = false;
					

					Selected = false;
					Clicked = false;
			}
		}
	}else{
		Selected = false;
		Clicked = false;

		if(WithFish == 1) {
			gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish;
		}

		if (WithFish == 2){
			gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish2;
		}

		if (WithFish == 3){
			gameObject.GetComponent<SpriteRenderer>().sprite = NormalFish3;
		}

		angle = 180;

		transform.Translate(new Vector3(0, 0.01f, 0));

		if (Ypos < -10){
			Destroy(gameObject);
		}
	}
}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown(0)){
			StartCoroutine(WaitForSelect());
		}
	}

	IEnumerator WaitForSelect(){
		yield return new WaitForSeconds(0.1f);
			Selected = true;
		
	}

	void OnTriggerStay2D(Collider2D other){
		if (Health > 0) {
		if (other.gameObject.tag == "Plant"){
			if (Hunger < HungerLimit) {
			Hunger += 1;
			other.GetComponent<Plants>().Food -= 1;
			}
		}

		if (other.gameObject.tag == "FOOD"){
			if (Hunger < HungerLimit) {
			Hunger += 1;
			other.GetComponent<Food>().FoodLeft -= 1;
			}
		}
	}
	}
}
