using UnityEngine;
using System.Collections;

public class Grounding : MonoBehaviour {

    private bool touching_ground = false;
    public float angle_leniency = 10f;

    //Stores last object the player stood on
    private GameObject ground_object;

    void OnCollisionEnter2D(Collision2D collision_object)
    {

        for (int i = 0; i < collision_object.contacts.Length; i++) {
            Vector2 contant_normal = collision_object.contacts[i].normal;
            Debug.Log(contant_normal);

            //If the contact normal is pointing up, the player must be on a flat surface
            float angle = Vector2.Angle(contant_normal, new Vector2(0, 1));
            if (angle <= angle_leniency && angle >= -angle_leniency)
            {
                touching_ground = true;
                ground_object = collision_object.gameObject;
                Debug.Log(true);
            }
            else
            {
                Debug.Log(false);
            }
        }

    }

    void OnCollisionExit2D(Collision2D collision_object)
    {
        if (collision_object.gameObject == ground_object) touching_ground = false;
    }

    public bool isTouchingGround() {
        return touching_ground;
    }

    public void setTouchingGround(bool value) {
        touching_ground = value;
    }
}


