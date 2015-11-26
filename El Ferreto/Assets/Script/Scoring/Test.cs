using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Test : MonoBehaviour {


    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var submit = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;

        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }

    private void SubmitName(string Name)
    {
        PlayerPrefs.SetInt("Name", Name);
        Debug.Log(Name);
    }
}
