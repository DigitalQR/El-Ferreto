using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeManagement : MonoBehaviour
{
    public int Health;
    public Text Healthk;
    public float _fontSize;
    public LevelManager levelManager;


    void Start()
    {
        Health = 3;
        _fontSize = Mathf.Min(Screen.width, Screen.height) / 20;
        Healthk.fontSize = (int)_fontSize;
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
        Healthk.text = "Lives:" + Health; 
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