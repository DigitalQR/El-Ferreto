using UnityEngine;
using System.Collections;

public class SpitballScript : MonoBehaviour {

    public float speed = 0.1f;
    private Rigidbody2D body;

	void Start ()
    {
        GameObject ferret = GameObject.Find("ferret");
        body = GetComponent<Rigidbody2D>();

        Vector2 direction = new Vector2(
            ferret.transform.position.x - transform.position.x,
            ferret.transform.position.y - transform.position.y          
           
        );

        body.velocity = direction.normalized * speed;


        body.rotation = Vector2.Angle(-Vector2.right, direction);

        if (direction.y > 0)
        {
            body.rotation *= -1;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject game_object = collision.gameObject;

        if (game_object.name == "ferret")
        {
            game_object.GetComponent<LifeManagement>().decreaseLife();
            Destroy(this.gameObject);
        }
    }
}
