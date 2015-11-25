using UnityEngine;
using System.Collections;

public class ConstantRotation : MonoBehaviour {

    public float angular_speed = 0.1f;
    public float distance;
    public float angle;

    void Start()
    {
        angle = Mathf.Rad2Deg * angle;
    }

	void Update () {
        angle += angular_speed * Time.deltaTime;
        transform.localPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0)*distance;
	}
}
