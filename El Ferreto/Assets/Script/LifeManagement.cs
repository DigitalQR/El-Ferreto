using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeManagement : MonoBehaviour
{
    public int Health;
    public LevelManager levelManager;

    public GameObject heart_1, heart_2, heart_3;



    void Start()
    {
        Health = 3;
    }

    public void decreaseLife() {
        Health--;
    }

    void Update()
    {

        if ((int)Health <= 0)
        {
            GetComponent<KillPlayer>().kill();
        }

        if (Health == 3)
        {
            heart_1.SetActive(true);
            heart_2.SetActive(true);
            heart_3.SetActive(true);
        }
        
        if (Health == 2)
        {
            heart_1.SetActive(true);
            heart_2.SetActive(true);
            heart_3.SetActive(false);
        }

        if (Health == 1)
        {
            heart_1.SetActive(true);
            heart_2.SetActive(false);
            heart_3.SetActive(false);
        }

        if (Health == 0)
        {
            heart_1.SetActive(false);
            heart_2.SetActive(false);
            heart_3.SetActive(false);
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
}