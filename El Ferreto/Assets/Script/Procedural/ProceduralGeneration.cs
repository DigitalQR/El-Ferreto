using UnityEngine;
using System.Collections;

public class ProceduralGeneration : MonoBehaviour {
	
	public Object[] myObjects;
	public static GameObject Manager;


	void Start () 
	{
		Manager = GameObject.Find ("Level Manager"); 
		float xsize = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		transform.position = new Vector3(Manager.transform.position.x + xsize * 2 + 10  ,Manager.transform.position.y,0);
		myObjects = Resources.LoadAll<GameObject>("Prefabs");
		Manager.transform.Translate (new Vector3 (transform.position.x,transform.position.y,0));
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
		SpawnRandomBuilding();
		Destroy (gameObject);
	}
}
