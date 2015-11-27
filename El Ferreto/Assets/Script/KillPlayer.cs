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
        if(other.gameObject.name == "ferret")
        {
            other.gameObject.GetComponent<Scoring>().OnPlayerDeath();
            kill();
        }
    }

    public void kill()
    {
        Application.LoadLevel("gameover");
    }

}
