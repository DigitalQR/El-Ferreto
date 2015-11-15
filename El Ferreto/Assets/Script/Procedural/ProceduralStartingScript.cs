﻿using UnityEngine;
using System.Collections;

public class ProceduralStartingScript : MonoBehaviour {

	public GameObject[] myObjects;
	public static GameObject Manager;

	// Use this for initialization
	void Start () {
		Manager = GameObject.Find ("Level Manager"); 
		Invoke ("SpawnRandomBuilding", 1);
		Invoke ("SpawnRandomBuilding", 2);
	}

	void SpawnRandomBuilding()
	{
		GameObject o = (GameObject)Instantiate (myObjects[Random.Range(0,myObjects.Length)], new Vector3 (1000, 1000, 0), Quaternion.identity);
	}
	// Update is called once per frame
	void Update () {

	}

	void OnBecomeInvisible()
	{
		Destroy (gameObject);
	}
}
