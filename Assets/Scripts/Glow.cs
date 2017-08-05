using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glow : MonoBehaviour {
	
	public Material glowMaterial;
	Material origMaterial;
	bool showPopUp=false;
	public Button button;

	void Start(){
		origMaterial = transform.GetComponent<Renderer>().material;
	}

	void OnMouseEnter(){
		transform.GetComponent<Renderer>().material = glowMaterial;
		showPopUp = true;
	}

	void OnMouseExit(){
		transform.GetComponent<Renderer>().material = origMaterial;
		showPopUp = false;
	}

	void Update(){
		if(showPopUp){
			button.gameObject.SetActive(true);
			button.gameObject.transform.position = Input.mousePosition;
		}
		else
			button.gameObject.SetActive(false);
	}
}
