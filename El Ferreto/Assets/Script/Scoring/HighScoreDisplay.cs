using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class HighScoreDisplay : MonoBehaviour
{
    //variables used for highscores
    public String OldName;
    public const String HighScoreKey = "Score";
    public const String HighScoreNameKey = "Name";
    int OldScore;
    public int TotalScore;
    int Currency;
    
    public Text ScoreText;
    public Text Name;
    string PlayerName;
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

    public GameObject InputPanel;
    public GameObject DisplayPanel;

    void start()
    {
        InputPanel.SetActive(true);
        DisplayPanel.SetActive(false);
    }

    void Update()
    {
        PlayerName = PlayerPrefs.GetString("PlayerName");
        TotalScore = PlayerPrefs.GetInt("PlayerScore");
        StoreScore(TotalScore);
        HighScoresToString();
    }


    public void StoreScore(int TotalScore)
    {
        for (int i = 0; i < 10; i++)
            {
                if (PlayerPrefs.HasKey(i + Scoring.HighScoreKey))//first checks if the entries for high scores exist
                {
                    if (PlayerPrefs.GetInt(i + Scoring.HighScoreKey) < TotalScore) //checks if the new score is higher than the other scores
                    {
                        OldScore = PlayerPrefs.GetInt(i + HighScoreKey);
                        OldName = PlayerPrefs.GetString(i + HighScoreNameKey);
                        PlayerPrefs.SetInt(i + HighScoreKey, TotalScore);
                        PlayerPrefs.SetString(i + HighScoreNameKey, PlayerName);
                        PlayerPrefs.SetInt("PlayerScore", 0);

                        for (int n = i + 1; n < 10; n++)//for moving other entires down by 1
                        {
                            if (PlayerPrefs.HasKey(n + HighScoreKey)) //checks if entry exists
                            {
                                int tempScore = PlayerPrefs.GetInt(n + HighScoreKey); //scores are temporarilly stored in order to be moved as required
                                String tempName = PlayerPrefs.GetString(n + HighScoreNameKey);
                                PlayerPrefs.SetInt(n + HighScoreKey, OldScore); //Old score moved down to the next space on the table
                                PlayerPrefs.SetString(n + HighScoreNameKey, OldName);
                                OldScore = tempScore; //old score set so the next score can be shifted down
                                OldName = tempName;
                            }
                            else //if the entry in the list dosent exist it needs to be made
                            {
                                PlayerPrefs.SetInt(n + HighScoreKey, OldScore);
                                PlayerPrefs.SetString(n + HighScoreNameKey, OldName);
                                break;
                            }
                        }
                        break;
                    }
                }
                else //if The entry in the table doesn't exist, it's created
                {
                    PlayerPrefs.SetInt(i + HighScoreKey, TotalScore);
                    PlayerPrefs.SetString(i + HighScoreNameKey, " ");
                    PlayerPrefs.SetInt("PlayerScore", 0);
                    break;
                }
            }
    }


    void HighScoresToString()
    {   //because of how player prefs handles values, to convert an integer to a string the integer needs to be stored in a temporaty variable THEN converted to string
        Score1.text = (PlayerPrefs.GetInt("1Score")).ToString();
		Score2.text = (PlayerPrefs.GetInt("2Score")).ToString();
		Score3.text = (PlayerPrefs.GetInt("3Score")).ToString();
		Score4.text = (PlayerPrefs.GetInt("4Score")).ToString();
		Score5.text = (PlayerPrefs.GetInt("5Score")).ToString();
		Score6.text = (PlayerPrefs.GetInt("6Score")).ToString();
		Score7.text = (PlayerPrefs.GetInt("7Score")).ToString();
		Score8.text = (PlayerPrefs.GetInt("8Score")).ToString();
		Score9.text = (PlayerPrefs.GetInt("9Score")).ToString();
		HighScore.text = (PlayerPrefs.GetInt("0Score")).ToString();
		HighName.text = PlayerPrefs.GetString("0Name");
		Name1.text = PlayerPrefs.GetString("1Name");
		Name2.text = PlayerPrefs.GetString("2Name");
		Name3.text = PlayerPrefs.GetString("3Name");
		Name4.text = PlayerPrefs.GetString("4Name");
		Name5.text = PlayerPrefs.GetString("5Name");
		Name6.text = PlayerPrefs.GetString("6Name");
		Name7.text = PlayerPrefs.GetString("7Name");
		Name8.text = PlayerPrefs.GetString("8Name");
		Name9.text = PlayerPrefs.GetString("9Name");

     
    }
}
