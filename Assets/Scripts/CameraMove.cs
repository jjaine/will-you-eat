using System.Collections;
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

		if(Input.mousePosition.x < 175)
			targetPos = new Vector3(2.2f, transform.position.y, transform.position.z);
		else if(Input.mousePosition.x > 175 && Input.mousePosition.x < 350)
			targetPos = new Vector3(1.8f, transform.position.y, transform.position.z);
		else if(Input.mousePosition.x > 350 && Input.mousePosition.x < 525)
			targetPos = new Vector3(1.4f, transform.position.y, transform.position.z);
		else if(Input.mousePosition.x > 525 && Input.mousePosition.x < 700)
			targetPos = new Vector3(1.0f, transform.position.y, transform.position.z);
		else if(Input.mousePosition.x > 700 && Input.mousePosition.x < 875)
			targetPos = new Vector3(0.6f, transform.position.y, transform.position.z);
		else if(Input.mousePosition.x > 875 && Input.mousePosition.x < 1050)
			targetPos = new Vector3(0.2f, transform.position.y, transform.position.z);
		else if(Input.mousePosition.x > 1050 && Input.mousePosition.x < 1225)
			targetPos = new Vector3(-0.2f, transform.position.y, transform.position.z);
		else if(Input.mousePosition.x > 1225 && Input.mousePosition.x < 1400)
			targetPos = new Vector3(-0.6f, transform.position.y, transform.position.z);
		else if(Input.mousePosition.x > 1400 && Input.mousePosition.x < 1575)
			targetPos = new Vector3(-1.0f, transform.position.y, transform.position.z);
		else if(Input.mousePosition.x > 1575 && Input.mousePosition.x < 1750)
			targetPos = new Vector3(-1.4f, transform.position.y, transform.position.z);
		else if(Input.mousePosition.x > 1750 && Input.mousePosition.x < 1925)
			targetPos = new Vector3(-1.8f, transform.position.y, transform.position.z);
		else
			targetPos = origPos;
		//transform.position = targetPos;
		transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime*0.5f);
	}
}
