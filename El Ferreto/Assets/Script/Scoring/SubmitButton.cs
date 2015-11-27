using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SubmitButton : MonoBehaviour
{
    public Text ScoreText;
    public GameObject InputPanel;
    public GameObject DisplayPanel;

    void start()
    {
        InputPanel.SetActive(true);
        DisplayPanel.SetActive(false);
    }

    
    void Update()
    {
        ScoreText.text = "Your Score: " + PlayerPrefs.GetInt("PlayerScore");
    }

    public void SubmitName()
    {
        GameObject inputField = GameObject.FindWithTag("Input");
        String PlayerName = inputField.GetComponent<InputField>().text;
        PlayerPrefs.SetString("PlayerName", PlayerName);
        Debug.Log(PlayerName);
        InputPanel.SetActive(false);
        DisplayPanel.SetActive(true);
    }
}
