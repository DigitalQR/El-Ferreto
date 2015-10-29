using UnityEngine;
using System.Collections;

public class CameraLaunchScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
