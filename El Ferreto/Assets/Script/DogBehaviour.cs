using UnityEngine;
using System.Collections;

public class DogBehaviour : MonoBehaviour {
	
	public float JumpForce = 10;
	float Timer;
	public Rigidbody2D RigidBody;
	
	// Use this for initialization
	void Start () {
		Timer = 200;
	}
	
	// Update is called once per frame
	void Update () {
		Timer--;
		if (Timer == 0)
		{
			RigidBody.AddForce((new Vector3(0,1,0) * JumpForce),ForceMode2D.Impulse);
			Timer = 200;
		}
	}
}
