using UnityEngine;
using System.Collections;

public class SnakeAttack : MonoBehaviour
{
    [Range (0,1)]
    public float fire_time;
    private float current_state = 0;
    private int current_degree = 0;
    private bool can_fire = true;

    public GameObject fireball;
    private bool ferret_in_range = false;
    private GameObject ferret;

    void Start()
    {
        ferret = GameObject.Find("ferret");
    }

    void Update()
    {
        AnimatorStateInfo animation = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        current_state = animation.normalizedTime - current_degree;

        while (current_state >= 1)
        {
            current_degree++;
            current_state -= 1;
            can_fire = true;
        }

        if (fire_time >= current_state && can_fire)
        {
            can_fire = false;
            if(ferret_in_range) Fire();
        }
        
    }

    void Fire()
    {
        GameObject spitball = Instantiate(fireball);
        spitball.transform.position = transform.position;
        spitball.transform.parent = transform;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "ferret")
            ferret_in_range = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "ferret")
            ferret_in_range = false;
    }
}
