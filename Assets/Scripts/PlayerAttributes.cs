using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour {

	public int smart = 0;
	public int sport = 0;
	public int games = 0;
	public int money = 0;

	public void addSmart(){
		smart++;
	}
	public void addSport(){
		sport++;
	}
	public void addGames(){
		games++;
	}

}
