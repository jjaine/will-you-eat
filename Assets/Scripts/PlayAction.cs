using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAction : MonoBehaviour {
	public GameObject endScreen; 
	public Text deathCause;
	public Text reload;
	public GameObject ambient, piano;
	public GameObject fail;
	public GameObject ageHandler;
	public GameObject eatButton, saveButton;

	void Start(){
		endScreen.SetActive(false);
		reload.enabled = false;
		ambient = GameObject.Find("AmbientPlayer");
		piano = GameObject.Find("PianoPlayer");
		//fail = GameObject.Find("FailPlayer");
		fail.SetActive(false);
		ageHandler = GameObject.Find("AgeHandler");
	}

	public void GameOver(string reason){
		ageHandler.GetComponent<AgeHandler>().age=0;
		fail.SetActive(true);
		ambient.SetActive(false);
		piano.SetActive(false);
		endScreen.SetActive(true);
		deathCause.text = reason;
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

	public void NextStage(){
		ageHandler.GetComponent<AgeHandler>().age+=5;
	}

	public void EatCoin(){
		if(Random.Range(0.0f, 1.0f) < 0.5f)
			GameOver("You choked on the quarter!");
		else{
			saveButton.SetActive(false);
			NextStage();
			if(ageHandler.GetComponent<AgeHandler>().age > 5)
				GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().smart--;
		}
	}

	public void SaveCoin(){
		GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().money+=1;
		GameObject q = GameObject.FindWithTag("Quarter");
		q.transform.GetChild(0).gameObject.SetActive(false);
		eatButton.SetActive(false);
		saveButton.SetActive(false);
	}

	public void ChooseCoinAction(){
		eatButton.SetActive(true);
		eatButton.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y-100, Input.mousePosition.z);
		saveButton.SetActive(true);
		saveButton.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y+100, Input.mousePosition.z);
	}

	public void GoOutSmart(){
		if(GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().smart < 1){
			GameOver("You got hit by a car, because you were not smart enough");
		}
		else
			NextStage();
	}

	public void BuyStuff(){
		if(GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().money > 0){
			GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().smart++;
			NextStage();
		}
	}
}
