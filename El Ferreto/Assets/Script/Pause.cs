using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GameObject pauseButton, pausePanel;

	public void Start()
	{

		OnUnPause();

	}

	public void OnPause()
	{

		pauseButton.SetActive (false);
		pausePanel.SetActive (true);
		Time.timeScale = 0; // Stops the time

	}

	public void OnUnPause()
	{

		pauseButton.SetActive (true);
		pausePanel.SetActive (false);
		Time.timeScale = 1; // Resumes the time

	}

	public void Restart()
	{

		Application.LoadLevel (Application.loadedLevel); // Loads current scene

	}

	public void Exit()
	{

		Application.Quit ();

	}

}
