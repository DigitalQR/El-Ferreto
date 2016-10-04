using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject ferret, tutorial, tilt, jump, swipeH, swipeV;
	bool tutorialOn = true;
	int timer;
	int tutorialPart;

	void Start () {
		 timer = 0;
		 tutorialPart = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer = timer + 1;
		if (tutorialPart == 1 && timer == 60) {
			tutorialPart=2;
			timer=0;
			}
		if (tutorialPart == 2 && ferret.GetComponent<Movement>().hasJumped()) {
			tutorialPart=3;
			timer=0;
		}
		if (tutorialPart == 3 && ferret.GetComponent<Tricks>().trick_mode) {
			tutorialPart=4;
			timer=0;
		}
		if (tutorialPart == 4 && timer == 40) {
			tutorialPart=5;
			timer=0;
		}
        if (tutorialPart == 5 && ferret.GetComponent<Tricks>().trick_mode == false && timer > 30)
        {
			tutorialPart=6;
		}

		if (tutorialOn == true)
		{
			if(tutorialPart==1 || tutorialPart==4)
			{
				tiltTutorial ();
			}
			if(tutorialPart==2)
			{
				jumpTutorial ();
			}
			if(tutorialPart==3)
			{
				swipeHTutorial();
			}
			if(tutorialPart==5)
			{
				swipeVTutorial ();
			}
			if(tutorialPart==6)
			{
				tutorialOn=false;
			}
		}
		else
		{
			tutorial.SetActive(false);
		}
	}

	void tiltTutorial()
	{
		tilt.SetActive (true);
		jump.SetActive (false);
		swipeH.SetActive (false);
		swipeV.SetActive (false);
	}

	void jumpTutorial()
	{
		tilt.SetActive (false);
		jump.SetActive (true);
		swipeH.SetActive (false);
		swipeV.SetActive (false);
	}

	void swipeHTutorial()
	{
		tilt.SetActive (false);
		jump.SetActive (false);
		swipeH.SetActive (true);
		swipeV.SetActive (false);
	}

	void swipeVTutorial()
	{
		tilt.SetActive (false);
		jump.SetActive (false);
		swipeH.SetActive (false);
		swipeV.SetActive (true);
	}
}
