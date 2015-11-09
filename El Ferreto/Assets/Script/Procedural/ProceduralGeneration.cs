using UnityEngine;
using System.Collections;

public class ProceduralGeneration : MonoBehaviour {
	
	public static GameObject[] myObjects;

	void Start () 
	{
		myObjects = Resources.LoadAll<GameObject>("Prefabs");
	}

	void SpawnRandomBuilding()
	{
		int number = Random.Range (0, 10);
		GameObject myObj = Instantiate(myObjects[number],
	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnBecomeInvisible()
	{
		Destroy (Prefab);
		SpawnRandomBuilding();
	}
}
