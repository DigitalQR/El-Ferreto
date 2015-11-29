using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	public GameObject ResetButton;

	public void resetTable()
	{
		for (int i = 0; i < 10; i++) {
			PlayerPrefs.SetInt (i + "Score", 0);
			PlayerPrefs.SetString (i + "Name", " ");
			PlayerPrefs.SetInt ("Currency", 0);
		}
	}
}
