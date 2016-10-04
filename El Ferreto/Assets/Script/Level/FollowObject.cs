using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

    public GameObject entity;
    public GameObject main_camera;
    Camera camera;

    void Start () {
        camera = GetComponent<Camera>();
    }
	
	void Update () {
        transform.position = new Vector3(entity.transform.position.x, entity.transform.position.y, transform.position.z);

        //Camera follows ferret in the x direction
        float x_pos = ((transform.position.x - main_camera.transform.position.x)/main_camera.GetComponent<Camera>().orthographicSize)/2.4f + 0.5f - camera.rect.width/2f;

        //Limit the camera to the range [0,1], so that it stays within the main viewport 
        if (x_pos > 1f - camera.rect.width) x_pos = 1f - camera.rect.width;
        if (x_pos < 0) x_pos = 0;

        camera.rect = new Rect(x_pos, camera.rect.y, camera.rect.width, camera.rect.height);
    }
}
