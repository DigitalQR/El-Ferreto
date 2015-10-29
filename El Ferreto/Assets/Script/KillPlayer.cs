using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;

	// Use this for initialization
	void Start () {
        
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //if player enters this trigger zone
    void onTriggerEnter2D(Collider2D other)
    {
        if(other.name == "ferret")
        {
            levelManager.RespawnPlayer();
            
        }
    }
}
