using UnityEngine;
using System.Collections;

public class OffScreenCameraToggle : MonoBehaviour {

    public Camera camera;

    void OnTriggerEnter2D(Collider2D collision_object)
    {
        if (collision_object.gameObject.name == "ferret")
        {
            camera.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision_object)
    {
        if (collision_object.gameObject.name == "ferret")
        {
            camera.enabled = false;
        }

    }

}
