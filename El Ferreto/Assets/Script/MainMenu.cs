using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//Variable for enabling/disabling pause menu
	public GameObject GameMenu2;

	private bool paused = false;
	
	void Start(){
	
		GameMenu2.SetActive (true);
		Time.timeScale = 1;

	}

/*	public void Resume(){
		
		paused = false;
		
	}*/

	public void Restart(){

		GameMenu2.SetActive (false);
		Application.LoadLevel(1); //Game loads the first scene

	}

	public void Exit(){

		Application.Quit ();

	}
}
