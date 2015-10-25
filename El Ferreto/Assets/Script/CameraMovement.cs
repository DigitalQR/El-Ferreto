using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float moveSpeed = 0.5f;
    public Vector2 playerDirection = Vector2.right;    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(playerDirection * moveSpeed * Time.deltaTime);
	}
}
