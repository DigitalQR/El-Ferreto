using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GameObject pauseButton, pausePanel;

	public void Start()
	{
		OnUnPause ();
	}

	public void OnPause()
	{
		Time.timeScale = 0; // Stops time
		pauseButton.SetActive(false);
		pausePanel.SetActive (true);
	}

	public void OnUnPause()
	{
		Time.timeScale = 1;
		pauseButton.SetActive(true);
		pausePanel.SetActive (false);
	}

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel); // Loads current scene
	}

	public void Quit()
	{
		Application.Quit();
	}
}
