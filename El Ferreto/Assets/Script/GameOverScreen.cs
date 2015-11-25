using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	public GameObject overScreen;

	public void Start(){
	
		overScreen.SetActive (true);
		Time.timeScale = 1;

	}

	public void Restart(){

		overScreen.SetActive (false);
		Application.LoadLevel(1); //Game loads the first scene

	}

	public void Exit(){

		Application.Quit ();

	}
}
