using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAction : MonoBehaviour {
	public GameObject endScreen; 
	public Text deathCause;
	public Text reload;
	GameObject ambient;
	GameObject fail;

	void Start(){
		endScreen.SetActive(false);
		reload.enabled = false;
		ambient = GameObject.Find("AmbientPlayer");
		fail = GameObject.Find("FailPlayer");
		fail.SetActive(false);
	}

	public void GameOver(){
		fail.SetActive(true);
		ambient.SetActive(false);
		endScreen.SetActive(true);
		deathCause.text = "You fell on your head!";
		StartCoroutine(Reload());
	}

	IEnumerator Reload(){
		StartCoroutine(ShowText());
		yield return new WaitForSeconds(5.0f);
		SceneManager.LoadScene(0);
		yield return null;
	}

	IEnumerator ShowText(){
		yield return new WaitForSeconds(1.0f);
		reload.enabled = true;
	}
}
