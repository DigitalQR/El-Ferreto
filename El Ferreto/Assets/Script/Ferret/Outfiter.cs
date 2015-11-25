using UnityEngine;
using System.Collections;

public class Outfiter : MonoBehaviour
{

    public static GameObject selected_hat;
    public static GameObject selected_effect;

    private GameObject hat;
    private GameObject effect;

    private GameObject hat_pointer;
    private GameObject effect_pointer;

    void Start()
    {
        //Setup player item saving
        if (!PlayerPrefs.HasKey("equipped_hat")) PlayerPrefs.SetString("equipped_hat", "");
        if (!PlayerPrefs.HasKey("equipped_effect")) PlayerPrefs.SetString("equipped_effect", "");

        //Try to equip last hat
        GameObject[] hats = Resources.LoadAll<GameObject>("Cosmetics/Hats");
        foreach (GameObject hat in hats)
        {
            if (PlayerPrefs.GetString("equipped_hat") == hat.GetComponent<Item>().item_name)
            {
                selected_hat = hat;
            }
        }

        //Try to equip last effect
        GameObject[] effects = Resources.LoadAll<GameObject>("Cosmetics/Effects");
        foreach (GameObject effect in effects)
        {
            if (PlayerPrefs.GetString("equipped_effect") == effect.GetComponent<Item>().item_name)
            {
                selected_effect = effect;
            }
        }



    }

    void Update()
    {
        if (hat != selected_hat)
        {
            equipHat();
        }
        if (effect != selected_effect)
        {
            equipEffect();
        }
    }

    public void equipHat()
    {
        //Remove current hat, if there is one
        if (hat_pointer != null) Destroy(hat_pointer);

        //Equip desired hat
        if (selected_hat != null)
        {
            GameObject new_hat = Instantiate(selected_hat);
            hat_pointer = new_hat;

            new_hat.transform.Translate(transform.position);
            new_hat.transform.SetParent(transform);

            PlayerPrefs.SetString("equipped_hat", selected_hat.GetComponent<Item>().item_name);
        }
        else PlayerPrefs.SetString("equipped_hat", "");



        hat = selected_hat;
    }

    public void equipEffect()
    {
        //Remove current effect, if there is one
        if (effect_pointer != null) Destroy(effect_pointer);

        //Equip desired effect
        if (selected_effect != null)
        {
            GameObject new_effect = Instantiate(selected_effect);
            effect_pointer = new_effect;

            new_effect.transform.Translate(new Vector3(transform.position.x, transform.position.y, 0));
            new_effect.transform.SetParent(transform);

            PlayerPrefs.SetString("equipped_effect", selected_effect.GetComponent<Item>().item_name);
        }
        else PlayerPrefs.SetString("equipped_effect", "");

        effect = selected_effect;
    }

}
