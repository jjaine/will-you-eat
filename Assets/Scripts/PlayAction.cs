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
	public GameObject current;
	public GameObject nextButton;
	static string buttonName;

	void Start(){
		endScreen.SetActive(false);
		reload.enabled = false;
		ambient = GameObject.Find("AmbientPlayer");
		fail.SetActive(false);
		ageHandler = GameObject.Find("AgeHandler");
	}

	public void GameOver(string reason){
		//ageHandler.GetComponent<AgeHandler>().age=0;
		fail.SetActive(true);
		ambient.SetActive(false);
		endScreen.SetActive(true);
		deathCause.text = reason;
		piano.SetActive(false);
		//StartCoroutine(Reload());
	}

	public void Restart(){
		SceneManager.LoadScene(0);
	}

	public void UpdateText(){
		if(gameObject.transform.name=="BookButton"){
			current.GetComponent<Text>().text = "You find an interesting book and\nuse the rest of the evening reading it.";
			buttonName = "BookButton";
		}
		else if(gameObject.transform.name=="DoorButton"){
			current.GetComponent<Text>().text = "The sun is shining and all your friends are calling\nso you decide to go out to play with them.";
			buttonName = "DoorButton";
		}
		else if(gameObject.transform.name=="ShelfButton"){
			current.GetComponent<Text>().text = "You climb up the bookcase.";
			buttonName = "ShelfButton";
		}
		else if(gameObject.transform.name=="PoopButton"){
			current.GetComponent<Text>().text = "You decide to continue your daily routine\nof eating, sleeping and pooping.";
			buttonName = null;
		}
		else if(gameObject.transform.name=="CribButton"){
			current.GetComponent<Text>().text = "You try to stand up against your crib.";
			buttonName = "CribButton";
		}
		else if(gameObject.transform.name=="DoorSmartButton"){
			current.GetComponent<Text>().text = "You decide that the best place \nto release all that excess energy is outside.";
			buttonName = "DoorSmartButton";
		}
		else if(gameObject.transform.name=="AmigaButton"){
			current.GetComponent<Text>().text = "The only thing in your house that is relevant\nto your interests is your computer.";
			buttonName = "AmigaButton";
		}
		else if(gameObject.transform.name=="BuyLegosButton"){
			BuyStuff("lego");
			current.GetComponent<Text>().text = "For a long time you have wanted to buy some building\nblocks and now you finally have the money for it.";
			buttonName = "BuyLegosButton";
		}
		else if(gameObject.transform.name=="SchoolButton"){
			current.GetComponent<Text>().text = "Now is the time to study.";
			buttonName = "SchoolButton";
		}
		else if(gameObject.transform.name=="FishingButton"){
			current.GetComponent<Text>().text = "Being outdoors is your thing.";
			buttonName = "FishingButton";
		}
		else if(gameObject.transform.name=="BuyCandyButton"){
			BuyStuff("candy");
			current.GetComponent<Text>().text = "All you want to do is eat some candy,\nluckily your home includes a vending machine that sells it.";
			buttonName = null;
		}
		else if(gameObject.transform.name=="BuyASMButton"){
			BuyStuff("asm");
			current.GetComponent<Text>().text = "You can finally go to the ASM party.";
			buttonName = "BuyASMButton";
		}
		else if(gameObject.transform.name=="ExamButton"){
			current.GetComponent<Text>().text = "You spend your time studying because you want to be\na doctor one day and need to ace that entrance exam.";
			buttonName = "ExamButton";
		}
		else if(gameObject.transform.name=="FootballButton"){
			current.GetComponent<Text>().text = "You have no time for anything but football.";
			buttonName = "FootballButton";
		}
		else if(gameObject.transform.name=="BeerButton"){
			current.GetComponent<Text>().text = "You like to hang out with your friends drinking beer.";
			buttonName = "BeerButton";
		}
		else if(gameObject.transform.name=="JukolaButton"){
			current.GetComponent<Text>().text = "You have a very promising relay career\nand little to no time for anything else.";
			buttonName = "JukolaButton";
		}
		else if(gameObject.transform.name=="JumpButton"){
			current.GetComponent<Text>().text = "You just can't concentrate on anything\nso you jump around the house.";
			buttonName = "JumpButton";
		}

		nextButton.SetActive(true);
	}

	public void NextStage(){
		if(buttonName=="DoorSmartButton"){
			if(GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().smart < 1){
				GameOver("You got hit by a car, because you were not smart enough");
			}
			else
				ageHandler.GetComponent<AgeHandler>().age+=5;
		}
		else if(buttonName=="BeerButton"){
			if(Random.Range(0.0f, 1.0f) < 0.5f)
				GameOver("You got alcohol poisoning!");
			else{
				GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().sport--;
				ageHandler.GetComponent<AgeHandler>().age+=5;
			}
		}
		else if(buttonName=="CribButton"){
			GameOver("you fell on your head!");
		}
		else if(buttonName=="ShelfButton"){
			GameOver("you fell!");
		}
		else if(buttonName=="JumpButton"){
			GameOver("you hit your head!");
		}
		else if(buttonName=="BookButton"||buttonName=="BuyLegosButton"||buttonName=="SchoolButton"||buttonName=="ExamButton"){
			GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().smart++;
			ageHandler.GetComponent<AgeHandler>().age+=5;
		}
		else if(buttonName=="DoorButton"||buttonName=="FishingButton"||buttonName=="FootballButton"||buttonName=="JukolaButton"){
			GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().sport++;
			if(buttonName=="JukolaButton")
				GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().sport++;
			ageHandler.GetComponent<AgeHandler>().age+=5;
		}
		else if(buttonName=="AmigaButton"||buttonName=="BuyASMButton"||buttonName=="FootballButton"||buttonName=="JukolaButton"){
			GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().games++;
			if(buttonName=="BuyASMButton")
				GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().games++;
			ageHandler.GetComponent<AgeHandler>().age+=5;
		}
		else
			ageHandler.GetComponent<AgeHandler>().age+=5;

		nextButton.SetActive(false);

		if(ageHandler.GetComponent<AgeHandler>().age == 0){
			current.GetComponent<Text>().text = "You are under one year old and you know how to crawl.\nYou want to explore your home.";
		}
		else if(ageHandler.GetComponent<AgeHandler>().age == 5){
			current.GetComponent<Text>().text = "Now you are 5 years old.\nYou are feeling bored and need something to do.";
		}
		else if(ageHandler.GetComponent<AgeHandler>().age == 10){
			current.GetComponent<Text>().text = "You have reached the age of 10.\nYou are home alone and have lots of energy.";		
		}
		else if(ageHandler.GetComponent<AgeHandler>().age == 15){
			current.GetComponent<Text>().text = "You are a 15-year-old teenager\nin some rebellious teenage phase.";
		}
		else if(ageHandler.GetComponent<AgeHandler>().age == 20){
			current.GetComponent<Text>().text = "You are a young adult in your twenties, congrats!\nNow what will you do?";
		}
		buttonName = null;
		Debug.Log("smart: " + GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().smart + " sport: " + GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().sport + " games: " + GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().games);
	}

	public void EatCoin(){
		if(Random.Range(0.0f, 1.0f) < 0.5f)
			GameOver("You choked on the quarter!");
		else{
			saveButton.SetActive(false);
			eatButton.SetActive(false);
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

	public void BuyStuff(string type){
		if(GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().money > 0){
			if(type == "lego")
				GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().smart++;
			else if(type == "candy")
				GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().sport--;
			else if(type == "asm" && GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().money > 1){
				GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().games+=2;
				GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().money--;
			}
			GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>().money--;
		}
	}
}
