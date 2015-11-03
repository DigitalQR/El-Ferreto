using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour
{

	int furthest_distance = 0;
    float lastPosition;
    int total_score;
    public Text Scoretext;
    public float distanceTravelled = 0;
    public int DistRound = 0;
    public int fontsize = Screen.width / 20;
    public float _fontSize;

    void Start()
    {
        lastPosition = transform.position.x; //takes initial opsition of ferret
        _fontSize = Mathf.Min(Screen.width, Screen.height) / 20; 
        Scoretext.fontSize = (int)_fontSize;
    }

    void Update()
    {
        distanceTravelled += (transform.position.x - lastPosition);
        lastPosition = transform.position.x;
        int score = Mathf.RoundToInt(distanceTravelled);

        if (score > furthest_distance)
        {
            addToScore(score - furthest_distance);
            furthest_distance = score;

        }

    }


    public void addToScore(int amount) {
        total_score += amount;
        Scoretext.text = "Score:" + total_score;
    }
}
