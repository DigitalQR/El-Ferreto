using UnityEngine;
using System.Collections;

public class Tricks : MonoBehaviour
{

    private Rigidbody2D body;
    private Movement movement_script;
    private bool trick_mode = false;

    private Vector2 touch_start = new Vector2();
    private Vector2 touch_end = new Vector2();
    private Vector2 draw = new Vector2();

    public float angle_leniency = 10;
    public float angular_speed = 4f;
    private bool vertical_swipe = false;
    private bool horizontal_swipe = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        movement_script = GetComponent<Movement>();
    }

    void Update()
    {
        handleTouch();

        //Horizontal swipe puts the ferret into trick mode
        if (horizontal_swipe)
        {
            horizontal_swipe = false;
            //If not on the ground, go into trick mode
            if (!GetComponent<Grounding>().isTouchingGround())
            {
                enterTrickMode();
            }
        }

        //Vertical swipe puts the ferret back into regular mode
        if (vertical_swipe)
        {
            vertical_swipe = false;
			calculateScore();
			leaveTrickMode();
        }

        if (trick_mode) {
            trickUpdate();
        }
        else
        {
            body.rotation /= 1.3f;
        }
    }

    void trickUpdate()
    {
        Vector2 movement;

        if (movement_script.keyboard_controlled)
        {
            movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        }
        else
        {
            movement = new Vector2(Input.acceleration.x * 3f, 0);
        }
        
        body.rotation -= movement.x * angular_speed;

        if (GetComponent<Grounding>().isTouchingGround()) {
            leaveTrickMode();

            //Take damage, but only if ferret has not landed on it's feet
            if (body.rotation > 45 || body.rotation < -45)
            {
                GetComponent<LifeManagement>().decreaseLife();
            }
        }
    }

    //Calculates score based on how many flips the ferret has done
    void calculateScore()
    {
        int amount = (int)Mathf.Abs(body.rotation / 360f);
        GetComponent<Scoring>().addToTrickScore(amount);
    }

    void handleTouch()
    {
        //Table touchscreen
        if (Input.touchCount > 0)
        {
            //Only cares about first touch
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touch_start = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                touch_end = Input.GetTouch(0).position;
                createLine();
            }
            
        }

        //Keyboard controlled
        if (Input.GetMouseButtonDown(0))
        {
            touch_start = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            touch_end = Input.mousePosition;
            createLine();
        }
    }

    //Looks at the line that has been drawn and sees if the line is (close enough) a horizontal or vertical line
    void createLine()
    {
        draw = touch_end - touch_start;
        draw = draw.normalized;

        //Is line close enough to a horizontal line?
        float horizontal_angle = Vector2.Angle(draw, new Vector2(1, 0));

        if (horizontal_angle <= angle_leniency && horizontal_angle >= -angle_leniency ||
            horizontal_angle - 180 <= angle_leniency && horizontal_angle - 180 >= -angle_leniency)
        {
            horizontal_swipe = true;
        }

        //Is line close enough to a vertical line?
        float vertical_angle = Vector2.Angle(draw, new Vector2(0, 1));
        if (vertical_angle <= angle_leniency && vertical_angle >= -angle_leniency ||
            vertical_angle - 180 <= angle_leniency && vertical_angle - 180 >= -angle_leniency)
        {
            vertical_swipe = true;
        }
    }

    void enterTrickMode() {
        trick_mode = true;
        movement_script.enabled = false;
        body.freezeRotation = false;
    }

    void leaveTrickMode() {
        movement_script.enabled = true;
        body.freezeRotation = true;
        trick_mode = false;

        while (body.rotation >= 360) body.rotation -= 360;
        while (body.rotation <= -360) body.rotation += 360;
        if (body.rotation >= 180) body.rotation -= 360;
        if (body.rotation <= -180) body.rotation += 360;
    }

}