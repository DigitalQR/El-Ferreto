using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Test : MonoBehaviour {


    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var Submit = new InputField.SubmitEvent();
        Submit.AddListener(SubmitName);
        input.onEndEdit = Submit;
    }

    private void SubmitName(string Name)
    {
        PlayerPrefs.SetString("Name", Name);
        Debug.Log(Name);
    }
}
