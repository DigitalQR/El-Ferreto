using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class HighScoreDisplay : MonoBehaviour
{

    public Text ScoreText;
    public Text Name;
    public InputField NameInput;
    InputField.SubmitEvent Submit;
    string strName;
    public Text HighScore;
    public Text HighName;
    public Text Score1;
    public Text Name1;
    public Text Score2;
    public Text Name2;
    public Text Score3;
    public Text Name3;
    public Text Score4;
    public Text Name4;
    public Text Score5;
    public Text Name5;
    public Text Score6;
    public Text Name6;
    public Text Score7;
    public Text Name7;
    public Text Score8;
    public Text Name8;
    public Text Score9;
    public Text Name9;


       



        // Use this for initialization
        void Start()
    {
        ScoreText.text = "Total Score: " + PlayerPrefs.GetInt("PlayerScore");
        NameInput = gameObject.GetComponent<InputField>();
        Submit = new InputField.SubmitEvent();
        Submit.AddListener(SubmitInput);
        NameInput.onEndEdit = Submit;
        HighScoresToString();
    }

    private void SubmitInput(String strName)
    {
        Debug.Log(Name);
    }

    void HighScoresToString()
    {   //because of how player prefs handles values, to convert an integer to a string the integer needs to be stored in a temporaty variable THEN converted to string
        int Temp0 = PlayerPrefs.GetInt("0Score");
        int Temp1 = PlayerPrefs.GetInt("1Score");
        int Temp2 = PlayerPrefs.GetInt("2Score");
        int Temp3 = PlayerPrefs.GetInt("3Score");
        int Temp4 = PlayerPrefs.GetInt("4Score");
        int Temp5 = PlayerPrefs.GetInt("5Score");
        int Temp6 = PlayerPrefs.GetInt("6Score");
        int Temp7 = PlayerPrefs.GetInt("7Score");
        int Temp8 = PlayerPrefs.GetInt("8Score");
        int Temp9 = PlayerPrefs.GetInt("9Score");
        String StrHighScore = Temp0.ToString(); //ints are converted to the strings to be thenb converted to text objects
        String StrScore1= Temp1.ToString();
        String StrScore2= Temp2.ToString();
        String StrScore3= Temp3.ToString();
        String StrScore4 = Temp4.ToString();
        String StrScore5 = Temp5.ToString();
        String StrScore6 = Temp6.ToString();
        String StrScore7 = Temp7.ToString();
        String StrScore8 = Temp8.ToString();
        String StrScore9 = Temp9.ToString();
        HighScore.text = (PlayerPrefs.GetString(0 + Scoring.HighScoreNameKey) + StrHighScore); //Strings are combined it to the text objects required for displaying
        Score1.text = (PlayerPrefs.GetString(1 + Scoring.HighScoreNameKey) + StrScore1);
        Score2.text = (PlayerPrefs.GetString(2 + Scoring.HighScoreNameKey) + StrScore2);
        Score3.text = (PlayerPrefs.GetString(3 + Scoring.HighScoreNameKey) + StrScore3);
        Score4.text = (PlayerPrefs.GetString(4 + Scoring.HighScoreNameKey) + StrScore4);
        Score5.text = (PlayerPrefs.GetString(5 + Scoring.HighScoreNameKey) + StrScore5);
        Score6.text = (PlayerPrefs.GetString(6 + Scoring.HighScoreNameKey) + StrScore6);
        Score7.text = (PlayerPrefs.GetString(7 + Scoring.HighScoreNameKey) + StrScore7);
        Score8.text = (PlayerPrefs.GetString(8 + Scoring.HighScoreNameKey) + StrScore8);
        Score9.text = (PlayerPrefs.GetString(9 + Scoring.HighScoreNameKey) + StrScore9);
    }
}
