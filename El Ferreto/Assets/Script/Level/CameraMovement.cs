using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float moveSpeed = 0.5f;
    public float camera_acceleration = 0.1f;
    public Vector2 playerDirection = Vector2.right;    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        moveSpeed += camera_acceleration;
        
        transform.Translate(playerDirection * moveSpeed);
	}
}
