using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    public float speed = 20f;
    public float jump_height = 10f;
    public bool keyboard_controlled = false;

    private bool touching_ground = false;

    // Update is called once per frame
    void Update () {
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        Vector2 movement = new Vector2(Input.acceleration.x,0);

        if (keyboard_controlled) {
            movement = new Vector2(Input.GetAxis("Horizontal"),0);
        }
        
        if (hasJumped() && touching_ground) {
            Debug.Log("Jump attempt");
            jump(body);
        }

        body.velocity += (movement * Time.deltaTime * speed);
    }

    public void jump(Rigidbody2D body) {
        //If the player is on the ground and they jump
        body.velocity+= new Vector2(0f, jump_height);
        touching_ground = false;
        Debug.Log("Jump");
    }

    //Has the player tried to jump
    public bool hasJumped() {
        if (keyboard_controlled) Input.GetKeyDown(KeyCode.W);

        //TODO Add accelerometer jump
        return Input.GetKeyDown(KeyCode.W);
    }

    public void OnCollisionEnter2D(Collision2D collision_object) {
        //If the player is touching buildings, it will be classed as on the ground
        if (collision_object.gameObject.tag == "building") {

            touching_ground = true;
            Debug.Log("Grounded");
        }
    }

}
