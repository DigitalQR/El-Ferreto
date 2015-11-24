using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopManager : MonoBehaviour {

    public Text currency;

    void Update() {
        if (!PlayerPrefs.HasKey("Currency")) PlayerPrefs.SetInt("Currency", 0);
        currency.text = "" + PlayerPrefs.GetInt("Currency");
    }
}
