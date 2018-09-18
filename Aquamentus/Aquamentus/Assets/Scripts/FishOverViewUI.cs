using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishOverViewUI : MonoBehaviour {

	public GameObject FishUI;
	public Text FishTypeText;
	public Text HealthText;
	public Text HungerText;

	public string FishType;
	public float Health;
	public float Hunger;

	public bool FishUIOn;

	// Use this for initialization
	void Start () {
		FishUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (FishUIOn == true){
			FishUI.SetActive(true);

			FishTypeText.text = FishType;
			HealthText.text = "HEALTH " + Health;
			HungerText.text = "HUNGER " +Hunger;

		}else{
			FishUI.SetActive(false);
		}
	}
}
