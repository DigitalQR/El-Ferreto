using UnityEngine;
using System.Collections;

public class DistanceTracking : MonoBehaviour
{

    float distanceTravelled = 0;
    Vector3 lastPosition;


    void Start()
    {
        lastPosition = transform.position;
    }


    void Update()
    {
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;

    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "distance:" + distanceTravelled);
    }
}
