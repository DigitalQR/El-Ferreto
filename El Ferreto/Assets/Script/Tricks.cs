using UnityEngine;
using System.Collections;

public class Tricks : MonoBehaviour
{

    private Rigidbody2D body;
    private Vector2 touch_start = new Vector2();
    private Vector2 touch_end = new Vector2();
    private Vector2 draw = new Vector2();

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        handleTouch();
    }

    void handleTouch()
    {
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
                draw = touch_end - touch_start;
                draw = draw.normalized;
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
            draw = touch_end - touch_start;
            draw = draw.normalized;
        }
    }

    //For debugging purposes only
    void OnGUI()
    {
        GUI.Label(new Rect(200, 10, 1000, 100), "Tricks Debug:\n" + touch_start + " " + touch_end + "\n" + draw);
    }
}