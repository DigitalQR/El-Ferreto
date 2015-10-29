using UnityEngine;
using System.Collections;

public class LifeManagement : MonoBehaviour
{
    public int Health;

    void Start()
    {
        Health = 3;
    }

    void Update()
    {
        if ((int)Health <= 0)
        {
          //  GameObject
        }

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
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 10, 10, 100, 30), "lives:" + Health);

    }
}