using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Scoring : MonoBehaviour
{

    //variables used in calculating distance travelled
    int furthestDistance = 0;
    float lastPosition;
    private int TrickScore = 0;
    public float DistanceTravelled = 0;
    public int DistRound = 0;
    public int Distance;

    //variables used for highscores
    public String Name;
    public String OldName;
    public const String HighScoreKey = "Score";
    public const String HighScoreNameKey = "Name";
    int OldScore;
    public int TotalScore;
    int Currency;

    //variables used in displaying the various text components
    public Text DistText;
    public Text TrickText;

    //variable for calculating trick score
    private const int PointsPerFlip = 3;


    void Start()
    {
        lastPosition = transform.position.x; //takes initial position of ferret
    }

    void Update()
    {
        DistanceTravelled += (transform.position.x - lastPosition); // adds or subtracts dfepending on movement
        lastPosition = transform.position.x; //sets last position for next frame for calculation
        Distance = Mathf.RoundToInt(DistanceTravelled); //rounds it so it displays nicely

        if (Distance > furthestDistance) //checks weither the ferret is moving forwards past the furthest point reached 
        {
            furthestDistance = Distance;
        }

        DistText.text = "Distance: " + furthestDistance;
        TrickText.text = "Tricks: " + TrickScore;
    }

    public void OnPlayerDeath() //when the player dies highscores are updated and currency is added
    {
        TotalScore = furthestDistance + TrickScore;
        AddToCurrency(TotalScore);
        PlayerPrefs.SetInt("PlayerScore", TotalScore); //to pass to other scripts in different scenes
    }

    public void addToTrickScore(int amount)
    {
        TrickScore += amount * PointsPerFlip; //adds points to tricks depending on predetermined points per flip
    }

    //Used to reset values in playerPrefs
    private void resetTable()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt(i + HighScoreKey, 0);
            PlayerPrefs.SetString(i + HighScoreNameKey, " ");
            PlayerPrefs.SetInt("Currency", 0);
        }
    }

    public void AddToCurrency(int TotalScore)
    {
        if (PlayerPrefs.HasKey("Currency"))//checks if key exists, if it does increaces the value by score achieved
        {
            PlayerPrefs.SetInt("Currency", (PlayerPrefs.GetInt("Currency") + TrickScore));
        }
        else //if key dosent exist, create it
            PlayerPrefs.SetInt("Currency", TotalScore);
    }
}


