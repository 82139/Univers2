using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour {

public Sprite Plant_1;
public Sprite Plant_2;
public GameObject PlantDestroy;

float timer = 60;

SpriteRenderer m_SpriteRenderer;


public float Food = 50;

	// Use this for initialization
	void Start () {

		m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

		
	}
	
	// Update is called once per frame
	void Update () {

		if (Food <= 0){
			Instantiate(PlantDestroy, new Vector3(transform.position.x, transform.position.y, -5), Quaternion.Euler(new Vector3(-90, 0, 0)));
			Destroy(gameObject);
		}

		if (timer > 30){
			m_SpriteRenderer.sprite = Plant_2;
			timer -= 1;
		}else if (timer <= 30 && timer > 0){
			m_SpriteRenderer.sprite = Plant_1;
			timer -= 1;
		}else if (timer <= 0){
			timer = 60;
		}

		/*if (timer > 60){

			m_SpriteRenderer.sprite = Plant_2;
			timer -= 1;

		}else if (timer > 30 && timer <= 60){

			m_SpriteRenderer.sprite = Plant_1;
			timer -= 1;

			}else if (timer > -1 && timer <= 30){

			m_SpriteRenderer.sprite = Plant_1;

			timer -= 1;

		}else if (timer < 0){
			if (m_SpriteRenderer.flipX == false){
				transform.position = new Vector3(transform.position.x - 0.3f , transform.position.y, -1);
				m_SpriteRenderer.flipX = true;
			}else if (m_SpriteRenderer.flipX == true){
				transform.position = new Vector3(transform.position.x + 0.3f , transform.position.y, -1);
				m_SpriteRenderer.flipX = false;
			}
			timer = 120;
		}
		 */
		
	}
}
