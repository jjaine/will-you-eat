﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgeHandler : MonoBehaviour {
	public List<GameObject> yearold0;
	public List<GameObject> yearold5;
	public List<GameObject> yearold10;
	public List<GameObject> yearold15;
	public List<GameObject> yearold20;
	public int age = 0;
	public GameObject current;

	// Use this for initialization
	void Start () {
		for(int i=0; i<yearold0.Count; i++){
			yearold0[i].SetActive(true);
		}
		for(int i=0; i<yearold5.Count; i++){
			yearold5[i].SetActive(false);
		}
		for(int i=0; i<yearold10.Count; i++){
			yearold10[i].SetActive(false);
		}
		for(int i=0; i<yearold15.Count; i++){
			yearold15[i].SetActive(false);
		}
		for(int i=0; i<yearold20.Count; i++){
			yearold20[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		current.GetComponent<Text>().text = "You are " + age + " years old.";
		if(age == 5){
			for(int i=0; i<yearold0.Count; i++){
				yearold0[i].SetActive(false);
			}
			for(int i=0; i<yearold5.Count; i++){
				yearold5[i].SetActive(true);
			}
		}
		else if(age == 10){
			for(int i=0; i<yearold5.Count; i++){
				yearold5[i].SetActive(false);
			}
			for(int i=0; i<yearold10.Count; i++){
				yearold10[i].SetActive(true);
			}
		}
		else if(age == 15){
			for(int i=0; i<yearold10.Count; i++){
				yearold10[i].SetActive(false);
			}
			for(int i=0; i<yearold15.Count; i++){
				yearold15[i].SetActive(true);
			}
		}
		else if(age == 20){
			for(int i=0; i<yearold15.Count; i++){
				yearold15[i].SetActive(false);
			}
			for(int i=20; i<yearold20.Count; i++){
				yearold20[i].SetActive(true);
			}
		}
	}
}