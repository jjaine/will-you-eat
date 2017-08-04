using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToClick : MonoBehaviour {

	float x,y;
	Vector3 targetPos;
	GameObject character;
	GoToClick WallScript, GroundScript;

	// Use this for initialization
	void Start () {
		character = GameObject.FindWithTag("Player");
		targetPos = character.transform.position;
		WallScript = GameObject.Find("Wall").GetComponent<GoToClick>();
		GroundScript = GameObject.Find("Ground").GetComponent<GoToClick>();
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.mousePosition.x;
    	y = Input.mousePosition.y;
    	Debug.Log(targetPos);
    	character.transform.position = targetPos;
	}

	void OnMouseDown(){
		if(transform.name == "Wall"){
			WallScript.enabled = true;
			GroundScript.enabled = false;
			targetPos = Camera.main.ScreenToWorldPoint(new Vector3(x,y,9.0f));
			
		}

		else{
			GroundScript.enabled = true;
			WallScript.enabled = false;
			targetPos = Camera.main.ScreenToWorldPoint(new Vector3(x,y,y/120));
			Debug.Log(targetPos.z);
			
		}
	}			
}
