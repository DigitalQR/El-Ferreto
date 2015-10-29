using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour
{

    float distanceTravelled = 0;
	int furthest_distance = 0;
    float lastPosition;
    int fontsize = Screen.width / 20;
    int total_score;

    void Start()
    {
        lastPosition = transform.position.x; //takes initial opsition of ferret
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

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, Screen.width / 20, Screen.height / 10), "Score:" + total_score);
    }

    public void addToScore(int amount) {
        total_score += amount;
    }
}
