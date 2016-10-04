using UnityEngine;
using System.Collections;

public class ProceduralStartingScript : MonoBehaviour {

    public static GameObject[] sections;
    public static Camera main_camera;
    public GameObject[] prefab_sections;
    public Camera attatched_camera;

    // Use this for initialization
    void Start () {
        sections = prefab_sections;
        main_camera = attatched_camera;

        Invoke ("SpawnRandomBuilding", 1);
	    Invoke ("SpawnRandomBuilding", 3);
		Invoke ("SpawnRandomBuilding", 5);
	}

	void SpawnRandomBuilding()
    {
        int random_index = Random.Range(0, sections.Length - 1);
        GameObject o = (GameObject)Instantiate(sections[random_index], new Vector3(1000, 1000, 0), Quaternion.identity);
    }
    
}
