using UnityEngine;
using System.Collections;

public class LockRotation : MonoBehaviour {

    void Update()
    {
        if (transform.lossyScale.x == -1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (transform.lossyScale.x == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }
	
}
