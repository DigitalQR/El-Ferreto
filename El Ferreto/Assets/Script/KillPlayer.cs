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
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "ferret")
        {
            kill();
            
        }
    }

    public void kill()
    {
        levelManager.RespawnPlayer();
        Application.LoadLevel(Application.loadedLevel);
    }

}
