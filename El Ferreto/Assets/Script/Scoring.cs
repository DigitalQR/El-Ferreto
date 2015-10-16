using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour
{

    float distanceTravelled = 0;
	int DistRound =0;
    float lastPosition;


    void Start()
    {
        lastPosition = transform.position.x;
    }


    void Update()
    {
        distanceTravelled += (transform.position.x - lastPosition);
        lastPosition = transform.position.x;
		DistRound = Mathf.RoundToInt (distanceTravelled);

    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "distance:" + DistRound);
    }
}
