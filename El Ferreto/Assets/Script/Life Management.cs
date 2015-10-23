using UnityEngine;
using System.Collections;

public class LifeManagement : MonoBehaviour
{
    public int Health;
    public int gameover;

    void Start()
    {
        Health = 3;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Health = Health - 1;
        }
        else if (other.gameObject.tag == "Offscreen")
        {  
            Health = 0;
        }
        
    }
}
