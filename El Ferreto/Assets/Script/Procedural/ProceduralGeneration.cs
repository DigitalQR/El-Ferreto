using UnityEngine;
using System.Collections;

public class ProceduralGeneration : MonoBehaviour {
	
	public GameObject[] myObjects;
	public static GameObject Manager;

	void Start () 
	{
		Manager = GameObject.Find ("Level Manager"); 
		float xsize = GameObject.FindGameObjectWithTag ("PrefabEnd").transform.position.x - GameObject.FindGameObjectWithTag ("PrefabStart").transform.position.x;
		transform.position = new Vector3(Manager.transform.position.x + xsize + 3 ,GameObject.FindGameObjectWithTag ("PrefabEnd").transform.position.y,0) - GetComponent<Renderer>().bounds.extents;
		myObjects = Resources.LoadAll<GameObject>("Prefabs");
		Manager.transform.position = new Vector3 (GameObject.FindGameObjectWithTag ("PrefabEnd").transform.position.x, GameObject.FindGameObjectWithTag ("PrefabEnd").transform.position.y,0);
	}

	void SpawnRandomBuilding()
	{
		GameObject o = (GameObject)Instantiate (myObjects[Random.Range(0,myObjects.Length)], new Vector3 (1000, 1000, 0), Quaternion.identity);
	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnBecomeInvisible()
	{
		Invoke("SpawnRandomBuilding",1);
		Destroy (gameObject, 1);
	}
}
