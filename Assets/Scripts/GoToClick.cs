using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToClick : MonoBehaviour {

	float x,y;
	Vector3 targetPos;
	GameObject character;

	// Use this for initialization
	void Start () {
		character = GameObject.FindWithTag("Player");
		targetPos = character.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.mousePosition.x;
    	y = Input.mousePosition.y;
    	character.transform.position = targetPos;
	}

	void OnMouseDown(){
		targetPos = Camera.main.ScreenToWorldPoint(new Vector3(x,y,9.0f));
		Debug.Log("Click at " +targetPos.x+" "+targetPos.y);
	}			
}
