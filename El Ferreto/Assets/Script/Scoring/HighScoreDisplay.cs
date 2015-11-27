using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class HighScoreDisplay : MonoBehaviour
{
    //variables used for highscores
    public String OldName;
    public const String HighScoreKey = "Score";
    public const String HighScoreNameKey = "ScoreName";
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
                    PlayerPrefs.SetString(i + HighScoreNameKey, PlayerName);
                    PlayerPrefs.SetInt("PlayerScore", 0);
                    break;
                }
            }
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
        HighScore.text = (PlayerPrefs.GetString(0 + HighScoreNameKey) + StrHighScore); //Strings are combined it to the text objects required for displaying
        Score1.text = (PlayerPrefs.GetString(1 + HighScoreNameKey) + StrScore1);
        Score2.text = (PlayerPrefs.GetString(2 + HighScoreNameKey) + StrScore2);
        Score3.text = (PlayerPrefs.GetString(3 + HighScoreNameKey) + StrScore3);
        Score4.text = (PlayerPrefs.GetString(4 + HighScoreNameKey) + StrScore4);
        Score5.text = (PlayerPrefs.GetString(5 + HighScoreNameKey) + StrScore5);
        Score6.text = (PlayerPrefs.GetString(6 + HighScoreNameKey) + StrScore6);
        Score7.text = (PlayerPrefs.GetString(7 + HighScoreNameKey) + StrScore7);
        Score8.text = (PlayerPrefs.GetString(8 + HighScoreNameKey) + StrScore8);
        Score9.text = (PlayerPrefs.GetString(9 + HighScoreNameKey) + StrScore9);
    }
}
