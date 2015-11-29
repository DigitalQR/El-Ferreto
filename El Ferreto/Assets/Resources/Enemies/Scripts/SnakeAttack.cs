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
            Fire();
        }
    }

    void Fire()
    {
        GameObject spitball = Instantiate(fireball);
        spitball.transform.position = transform.position;
    }
}
