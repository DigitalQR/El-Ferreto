using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Scoring : MonoBehaviour
{


    int furthestDistance = 0;
    float lastPosition;
    private int TrickScore = 0;
    public float DistanceTravelled = 0;
    public int DistRound = 0;
    public int Distance;

    public String Name;
    public String OldName;
    const String HighScoreKey = "HighScore";
    const String HighScoreNameKey = "HighScoreName";
    int OldScore;

    public float _fontSize;
    public Text DistText;
    public Text TrickText;
    public Text ScoreText;

    private const int PointsPerFlip = 3;

    void Start()
    {
        lastPosition = transform.position.x; //takes initial position of ferret
        _fontSize = Mathf.Min(Screen.width, Screen.height) / 20;
        ScoreText.fontSize = (int)_fontSize;
        DistText.fontSize = (int)_fontSize;
        TrickText.fontSize = (int)_fontSize / 2;
    }

    void Update()
    {
        DistanceTravelled += (transform.position.x - lastPosition); // adds or subtracts dfepending on movement
        lastPosition = transform.position.x; //sets last position for next frame for calculation
        Distance = Mathf.RoundToInt(DistanceTravelled); //rounds it so it displays nicely

        if (Distance > furthestDistance)
        {
            furthestDistance = Distance;
        }

        DistText.text = "distance:" + furthestDistance;
        TrickText.text = "Tricks:" + TrickScore;
    }

    public void OnPlayerDeath()
    {
        int TotalScore = furthestDistance + TrickScore;
        StoreScore(TotalScore);

        //ScoreText.text = "Total Score:" + TotalScore;
        //Name = GUI.TextField(new Rect(25, 25, 100, 30), Name);
        //if (totalscore>(Score+str(1)))

    }

    public void addToTrickScore(int amount)
    {
        TrickScore += amount * PointsPerFlip; //adds points to tricks depending on predetermined points per flip
    }

    //Used to reset values in playerPrefs
    private void resetTable(){
        for (int i = 0; i < 10; i++)
            {
                PlayerPrefs.SetInt(i + HighScoreKey, 0);
                PlayerPrefs.SetString(i + "HScoreName", Name);
            }
    }

    public void StoreScore(int TotalScore)
    {

        for (int i = 0; i < 10; i++)
        {
            //The entry in the table exists
            if (PlayerPrefs.HasKey(i + HighScoreKey))
            {
                if (PlayerPrefs.GetInt(i + HighScoreKey) < TotalScore)
                {
                    OldScore = PlayerPrefs.GetInt(i + HighScoreKey);
                    OldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetInt(i + HighScoreKey, TotalScore);
                    PlayerPrefs.SetString(i + "HScoreName", Name);

                    //Move other entires down by 1
                    for (int n = i + 1; n < 10; n++) {

                        //The entry in the table exists
                        if (PlayerPrefs.HasKey(n + HighScoreKey))
                        {
                            int tempScore = PlayerPrefs.GetInt(n + HighScoreKey);
                            String tempName = PlayerPrefs.GetString(n + "HScoreName");

                            PlayerPrefs.SetInt(n + HighScoreKey, OldScore);
                            PlayerPrefs.SetString(n + "HScoreName", OldName);

                            OldScore = tempScore;
                            OldName = tempName;
                        }
                        //The entry in the table doesn't exist
                        else
                        {
                            PlayerPrefs.SetInt(n + HighScoreKey, OldScore);
                            PlayerPrefs.SetString(n + "HScoreName", OldName);
                            break;
                        }
                    }
                    break;
                }
            }
            //The entry in the table doesn't exist
            else 
            {
                PlayerPrefs.SetInt(i + HighScoreKey, TotalScore);
                PlayerPrefs.SetString(i + "HScoreName", Name);
                break;
            }
        }

        //TEST--------------------------------------------#
        String table = "";
        for (int i = 0; i < 10; i++) {
            if (PlayerPrefs.HasKey(i + HighScoreKey))
            {
                table += i + " Score:" + PlayerPrefs.GetInt(i + HighScoreKey) + "\n";
            }
        }
        Debug.Log(table);

    }


    public void OnGUI()
    {
        Debug.Log(OldScore);
    }
}


