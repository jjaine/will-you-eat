﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	Vector3 targetPos, origPos;
	// Use this for initialization
	void Start () {
		targetPos = transform.position;
		origPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.mousePosition.x < 600)
			targetPos = new Vector3(2.2f, transform.position.y, transform.position.z);
		else if(Input.mousePosition.x < 700)
			targetPos = new Vector3(1.0f, transform.position.y, transform.position.z);
		else if (Input.mousePosition.x > 1000)
			targetPos = new Vector3(-1.0f, transform.position.y, transform.position.z);
		else if (Input.mousePosition.x > 1700)
			targetPos = new Vector3(-2.2f, transform.position.y, transform.position.z);
		else
			targetPos = origPos;
		transform.position = targetPos;
		//transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime*0.5f);
	}
}
