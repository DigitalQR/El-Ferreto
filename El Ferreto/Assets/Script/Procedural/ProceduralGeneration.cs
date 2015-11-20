using UnityEngine;
using System.Collections;

public class ProceduralGeneration : MonoBehaviour {
	
	public GameObject[] myObjects;
	public static GameObject Manager;
	static GameObject PrefabStart;
	static GameObject PrefabEnd;

	void Start () 
	{
		PrefabStart = GameObject.Find ("PrefabStarter");
		PrefabEnd = GameObject.Find ("PrefabEnder");
		Manager = GameObject.Find ("Level Manager"); 
		float xsize = PrefabEnd.gameObject.transform.position.x - PrefabStart.gameObject.transform.position.x;
		transform.position = new Vector3(Manager.transform.position.x + xsize + 1, Manager.transform.position.y,0) - GetComponent<Renderer>().bounds.extents;

		Manager.transform.position = new Vector3 (PrefabEnd.gameObject.transform.position.x,Manager.transform.position.y,0);
	}

	void SpawnRandomBuilding()
	{
		GameObject o = (GameObject)Instantiate (myObjects[Random.Range(0,myObjects.Length)], new Vector3 (1000, 1000, 0), Quaternion.identity);
	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnBecameInvisible()
	{
		Invoke("SpawnRandomBuilding",1);
		Destroy (gameObject, 1);
	}
}
