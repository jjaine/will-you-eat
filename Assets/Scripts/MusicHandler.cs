using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour {

	AudioSource ambient;
	GameObject piano;
	public AudioClip ambient2;
	public AudioClip ambient3;
	public AudioClip piano2;
	bool pianoActive;

	// Use this for initialization
	void Start () {
		ambient = GameObject.Find("AmbientPlayer").GetComponent<AudioSource>();
		piano = GameObject.Find("PianoPlayer");
		piano.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("AgeHandler").GetComponent<AgeHandler>().age == 5){
			if(ambient.loop && !pianoActive){
				ambient.loop = false;
			}
			if(!ambient.isPlaying){
				piano.SetActive(true);
				if(ambient.gameObject.activeSelf)
					ambient.Play();
				ambient.loop = true;
				pianoActive = true;
			}
		}
		else if(GameObject.Find("AgeHandler").GetComponent<AgeHandler>().age == 10){
			changeAmbient(ambient2);
		}
		else if(GameObject.Find("AgeHandler").GetComponent<AgeHandler>().age == 15){
			changePiano(piano2);
		}
		else if(GameObject.Find("AgeHandler").GetComponent<AgeHandler>().age == 20){
			changeAmbient(ambient3);
		}
	}

	void changeAmbient(AudioClip a){
		if(ambient.clip != a){
			ambient.clip = a;
			ambient.Play();
			if(!piano.activeSelf)
				piano.SetActive(true);
			piano.GetComponent<AudioSource>().Stop();
			piano.GetComponent<AudioSource>().Play();
		}
	}	

	void changePiano(AudioClip a){
		if(piano.GetComponent<AudioSource>().clip != a){
			piano.GetComponent<AudioSource>().clip = a;
			piano.GetComponent<AudioSource>().Play();
			ambient.Stop();
			ambient.Play();
		}
	}	
}
