using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Scoring : MonoBehaviour
{


    int furthestDistance = 0;
    float lastPosition;
    int TotalScore;
    private int TrickScore = 0;
    public float DistanceTravelled = 0;
    public int DistRound = 0;
    public int Distance;

    public String Name;
    public String OldName;
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
        TotalScore = furthestDistance + TrickScore;
        ScoreText.text = "Total Score:" + TotalScore;
        Name = GUI.TextField(new Rect(25, 25, 100, 30), Name);
        Checkscore(TotalScore);

    }

    public void addToTrickScore(int amount)
    {
        TrickScore += amount * PointsPerFlip; //adds points to tricks depending on predetermined points per flip
    }

    private void Checkscore(int totalScore)
    {
        for (int i = 0; i < 10; i++)
            if (PlayerPrefs.HasKey(i + "HScore"))
            {
                if (PlayerPrefs.GetInt(i + "HScore") < totalScore)
                {
                    OldScore = PlayerPrefs.GetInt(i + "HScore");
                    OldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetInt(i + "HScore", TotalScore);
                    PlayerPrefs.SetString(i + "HScoreName", Name);
                    TotalScore = OldScore;
                    Name = OldName;
                }
                else
                {
                    PlayerPrefs.SetInt(i + "HScore", TotalScore);
                    PlayerPrefs.SetString(i + "HScoreName", Name);
                    TotalScore = 0;
                    Name = " ";

                }
            }
    }
}

