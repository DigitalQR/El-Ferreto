using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private Movement ferret;

	// Use this for initialization
	void Start () {
        ferret = FindObjectOfType<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RespawnPlayer()
    {
        //check if it works
        Debug.Log ("Player Respawn");
        ferret.transform.position = currentCheckpoint.transform.position;
    }
}

