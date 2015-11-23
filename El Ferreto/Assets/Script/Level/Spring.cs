using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {

    public float spring_acceleration = 10;

    void OnTriggerEnter2D(Collider2D other) {
        GameObject game_object = other.gameObject;

        if(game_object.name == "ferret"){
            Rigidbody2D body = game_object.GetComponent<Rigidbody2D>();
            body.AddForce(body.mass * transform.up * spring_acceleration);
        }
    }
}
