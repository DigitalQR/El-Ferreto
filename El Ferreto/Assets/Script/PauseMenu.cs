using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	//Variable for enabling/disabling pause menu
	public GameObject GameMenu;

	private bool paused = false;
	
	void Start(){
	
		GameMenu.SetActive (false);

	}

	void Update(){
	
		if(Input.GetButtonDown("Pause")){

			paused = !paused;

		}

		if(paused){

			GameMenu.SetActive(true);
			Time.timeScale = 0; //Sets the time to 0, stops everything

		}

		if(!paused){

			GameMenu.SetActive (false);
			Time.timeScale = 1;

		}

	}

	public void Resume(){
		
		paused = false;
		
	}

	public void Restart(){

		Application.LoadLevel(Application.loadedLevel); //Game loads the first scene

	}

	public void Exit(){

		Application.Quit ();

	}
}
