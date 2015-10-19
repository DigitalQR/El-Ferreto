using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public float MoveSpeed = 3.0f;

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       // this.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        this.gameObject.transform.position += new Vector3(0.05f,0,0);

	}
}
