using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{

    public void switchScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void giveMoney(int amount)
    {
        PlayerPrefs.SetInt("Currency", PlayerPrefs.GetInt("Currency") + amount);
    }

    public void resetInventory()
    {
        GameObject[] hats = Resources.LoadAll<GameObject>("Cosmetics/Hats");
        foreach (GameObject hat in hats)
        {
            PlayerPrefs.SetInt("Item_" + hat.GetComponent<Item>().item_name, 0);
        }

        GameObject[] effects = Resources.LoadAll<GameObject>("Cosmetics/Effects");

        foreach (GameObject effect in effects)
            PlayerPrefs.SetInt("Item_" + effect.GetComponent<Item>().item_name, 0);
    }
}

