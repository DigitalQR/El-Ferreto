using UnityEngine;
using System.Collections;
using System;

public class Movement : MonoBehaviour
{

    private Rigidbody2D body;
    private Grounding ground;
    private Animator anim;
    //Stores last y accelerometer states where 0 is the current state
    private float[] jump_state = new float[10];

    public float jump_threshold;
    public float movement_magnitude;
    public float max_speed;
    public float jump_height;

    public bool keyboard_controlled = false;

    private Vector2 movement_force = new Vector2();

    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Grounding>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 movement;

        if (keyboard_controlled)
        {
            movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        }
        else
        {
            movement = new Vector2(Input.acceleration.x * 3f, 0);
            pollJumpStates();
        }

        //Jump, if the player has tried to jump and is touching the ground
        if (hasJumped() && ground.isTouchingGround())
        {
            jump(body);
        }

        movement_force += movement * movement_magnitude * body.mass * Time.deltaTime;
        movement_force *= 0.8f;

        //Ensure the current x velocity isn't greater than the max speed
        if (Mathf.Abs(movement_force.x) > max_speed)
        {
            movement_force = new Vector2(max_speed * Math.Sign(movement_force.x), movement_force.y);
        }

        body.AddForce(movement_force);

        animationUpdate();
    }

    void animationUpdate()
    {
        // setting ground condition for Animator
        anim.SetBool("ground", ground.isTouchingGround() || Math.Round(body.velocity.x * 100) == 0);

        // setting speed condition for Animator
        anim.SetFloat("speed", Mathf.Abs(body.velocity.x));

        //Flip sprite to face correct direction
        if (body.velocity.x < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (body.velocity.x > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //Shift every value in the array and add current state
    void pollJumpStates()
    {
        float current_state = Input.acceleration.y;

        for (int i = jump_state.Length - 1; i > 0; i--)
        {
            jump_state[i] = jump_state[i - 1];
        }

        jump_state[0] = current_state;
    }

    void jump(Rigidbody2D body)
    {
        //If the player is on the ground and they jump
        body.velocity += new Vector2(0f, jump_height);
        ground.setTouchingGround(false);
    }

    //Has the player tried to jump
    bool hasJumped()
    {
        if (keyboard_controlled) return Input.GetKeyDown(KeyCode.W);

        if (getJumpMagnitude() >= jump_threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    float getJumpMagnitude()
    {
        return Math.Abs(jump_state[0] - jump_state[jump_state.Length - 1]);
    }

    //For debugging purposes only
    void OnGUI()
    {
        //GUI.Label(new Rect(100, 10, 1000, 100), "Debug:\n" + body.position + "\n" + Input.acceleration + "\n" + (int)(getJumpMagnitude() * 100) / 100f + "\n" + ground.isTouchingGround() + "\n" + body.velocity + " " + body.velocity.normalized);
    }
}