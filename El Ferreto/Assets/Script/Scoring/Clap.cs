using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clap : MonoBehaviour {

    public GameObject ClapButton;
    int ClickCount = 0;

    public void IanButton()
    {
        ClickCount = ClickCount + 1;
        if (ClickCount == 10)
        {
            ClapButton.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("Currency", PlayerPrefs.GetInt("Currency") + 100);
        }
    }
}
