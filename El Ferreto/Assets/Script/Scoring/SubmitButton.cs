using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SubmitButton : MonoBehaviour
{
    public Text ScoreText;
    public GameObject InputPanel;
    public GameObject DisplayPanel;
    public GameObject ClapButton;
	String PlayerName;
	String CheckEgg;

    void start()
    {
        InputPanel.SetActive(true);
        DisplayPanel.SetActive(false);
        ClapButton.SetActive(false);
    }

    
    void Update()
    {
        ScoreText.text = "Your Score: " + PlayerPrefs.GetInt("PlayerScore");
    }

    public void SubmitName()
    {
        GameObject inputField = GameObject.FindWithTag("Input");
        PlayerName = inputField.GetComponent<InputField>().text;
        PlayerPrefs.SetString("PlayerName", PlayerName);
		CheckEgg = PlayerName.ToUpper ();
        if (CheckEgg == "IAN")
        {
            PlayerPrefs.SetInt("Ian", 1);
            ClapButton.SetActive(true);
        }
        else if (PlayerName == "RICHARD")
        {
            PlayerPrefs.SetInt("Richard", 1);
        }    
        Debug.Log(PlayerName);
        InputPanel.SetActive(false);
        DisplayPanel.SetActive(true);
    }
}
