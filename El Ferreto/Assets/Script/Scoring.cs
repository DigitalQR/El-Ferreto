using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour
{

	int furthest_distance = 0;
    float lastPosition;
    int TotalScore;
    public int TrickScore;
    public Text DistText;
    public Text TrickText;
    public Text ScoreText;
    public float DistanceTravelled = 0;
    public int DistRound = 0;
    public int Distance;
    public float _fontSize;
    public int PointsPerFlip;

    void Start()
    {
        lastPosition = transform.position.x; //takes initial position of ferret
        _fontSize = Mathf.Min(Screen.width, Screen.height) / 20; 
        ScoreText.fontSize = (int)_fontSize;
        DistText.fontSize = (int)_fontSize;
        TrickText.fontSize = (int)_fontSize/2;
    }

    void Update()
    {
        DistanceTravelled += (transform.position.x - lastPosition); // adds or subtracts dfepending on movement
        lastPosition = transform.position.x; //sets last position for next frame for calculation
        int Distance = Mathf.RoundToInt(DistanceTravelled); //rounds it so it displays nicely

        if (Distance < furthest_distance)
        {
            Distance = furthest_distance;
        }
        addToTrickScore(Distance - furthest_distance);
        DistText.text = "distance:" + Distance;
        TrickText.text = "Tricks:" + TrickScore;
    }

    public void addToTrickScore(int amount) {
        TrickScore += amount*PointsPerFlip;

    }
}
