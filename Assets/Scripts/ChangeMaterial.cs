using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {
	
	public Material mat0y, mat5y, mat10y, mat15y, mat20y;

	// Update is called once per frame
	void Update () {
		if(GameObject.Find("AgeHandler").GetComponent<AgeHandler>().age == 0){
			transform.GetComponent<Renderer>().material = mat0y;
		}
		else if(GameObject.Find("AgeHandler").GetComponent<AgeHandler>().age == 5){
			transform.GetComponent<Renderer>().material = mat5y;
		}
		else if(GameObject.Find("AgeHandler").GetComponent<AgeHandler>().age == 10){
			transform.GetComponent<Renderer>().material = mat10y;
		}
		else if(GameObject.Find("AgeHandler").GetComponent<AgeHandler>().age == 15){
			transform.GetComponent<Renderer>().material = mat15y;
		}
		else if(GameObject.Find("AgeHandler").GetComponent<AgeHandler>().age == 20){
			transform.GetComponent<Renderer>().material = mat20y;
		}
	}
}
