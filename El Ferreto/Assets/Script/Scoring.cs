using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour
{

    float distanceTravelled = 0;
	int DistRound =0;
    float lastPosition;
    int fontsize = Screen.width / 20;

    void Start()
    {
        lastPosition = transform.position.x; //takes initial opsition of ferret
    }


    void Update()
    {
        distanceTravelled += (transform.position.x - lastPosition);
        lastPosition = transform.position.x;
        int score = Mathf.RoundToInt(distanceTravelled);

        if (score > DistRound)
        {
            DistRound = score;
        }

    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, Screen.width / 20, Screen.height / 10), "distance:" + DistRound);

    }
}
