using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour {

	AudioSource ambient;
	GameObject piano;
	public bool changePiano = false;

	// Use this for initialization
	void Start () {
		ambient = GameObject.Find("AmbientPlayer").GetComponent<AudioSource>();
		piano = GameObject.Find("PianoPlayer");
		piano.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(changePiano){
			piano.SetActive(true);
		}
	}	
}
