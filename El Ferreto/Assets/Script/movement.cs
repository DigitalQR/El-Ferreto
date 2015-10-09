using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
    }

    const float speed = 20f;
    const float speed_cap = 10f;

    // Update is called once per frame
    void Update () {
        Vector2 movement = new Vector2(
            Input.acceleration.x,
            Input.acceleration.y
            );

        Rigidbody2D body = GetComponent<Rigidbody2D>();

        body.velocity += (movement * Time.deltaTime * speed);
        body.freezeRotation = true;
        
    }
}
