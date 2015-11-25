using UnityEngine;
using System.Collections;

public class ProceduralGeneration : MonoBehaviour {
	
	public GameObject Manager;
	private GameObject PrefabStart;
	private GameObject PrefabEnd;
    private Vector2 end_position;

	void Start () 
	{
		PrefabStart = GameObject.Find ("PrefabStarter");
		PrefabEnd = GameObject.Find ("PrefabEnder");
		Manager = GameObject.Find ("Level Manager");
        
        float xsize = PrefabEnd.gameObject.transform.position.x - PrefabStart.gameObject.transform.position.x;

        transform.position = new Vector3(Manager.transform.position.x, 0, 1) - PrefabStart.transform.localPosition;
		Manager.transform.position = new Vector3 (PrefabEnd.gameObject.transform.position.x, Manager.transform.position.y, 0);

        end_position = PrefabEnd.transform.position;
    }

	void SpawnRandomBuilding()
	{
        int random_index = Random.Range(0, ProceduralStartingScript.sections.Length - 1);
        GameObject o = (GameObject)Instantiate(ProceduralStartingScript.sections[random_index], new Vector3(1000, 1000, 0), Quaternion.identity);
    }

    void FixedUpdate()
    {
        //If off left side of the screen
        Vector2 clip_position = ProceduralStartingScript.main_camera.WorldToViewportPoint(end_position);

        if (clip_position.x < 0)
        {
            recycle();
        }
    }

    void recycle()
    {
        Destroy(gameObject);
        SpawnRandomBuilding();
	}
}
