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
    public const String HighScoreNameKey = "ScoreName";
    int OldScore;
    public int TotalScore;
    int Currency;

    //variables used in displaying the various text components
    public float _fontSize;
    public Text DistText;
    public Text TrickText;

    //variable for calculating trick score
    private const int PointsPerFlip = 3;


    void Start()
    {
        lastPosition = transform.position.x; //takes initial position of ferret
        _fontSize = Mathf.Min(Screen.width, Screen.height) / 20; //sets the font size to be used by the game, scales with resolution and aspect ratio
        DistText.fontSize = (int)_fontSize;
        TrickText.fontSize = (int)_fontSize / 2;
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

        DistText.text = "Distance:" + furthestDistance;
        TrickText.text = "Tricks:" + TrickScore;
    }

    public void OnPlayerDeath() //when the player dies highscores are updated and currency is added
    {
        TotalScore = furthestDistance + TrickScore;
        AddToCurrency(TotalScore);
        StoreScore(TotalScore);
        PlayerPrefs.SetInt("PlayerScore", TotalScore);
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
            PlayerPrefs.SetString(i + HighScoreNameKey, Name);
        }
    }

    public void StoreScore(int TotalScore)
    {

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(i + HighScoreKey))//first checks if the entries for high scores exist
            {
                if (PlayerPrefs.GetInt(i + HighScoreKey) < TotalScore) //checks if the new score is higher than the other scores
                {
                    OldScore = PlayerPrefs.GetInt(i + HighScoreKey);
                    OldName = PlayerPrefs.GetString(i + HighScoreNameKey);
                    PlayerPrefs.SetInt(i + HighScoreKey, TotalScore);
                    PlayerPrefs.SetString(i + HighScoreNameKey, Name);
 
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
                PlayerPrefs.SetString(i + HighScoreNameKey, Name);
                break;
            }
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


