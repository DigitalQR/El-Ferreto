using UnityEngine;
using System.Collections;

public class Outfiter : MonoBehaviour {

    public static GameObject selected_hat;
    public static GameObject selected_effect;

    private GameObject hat;
    private GameObject effect;

    private GameObject hat_pointer;
    private GameObject effect_pointer;

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
        if (hat_pointer != null) Destroy(hat_pointer);

        if (selected_hat != null)
        {
            GameObject new_hat = Instantiate(selected_hat);
            hat_pointer = new_hat;

            new_hat.transform.Translate(transform.position);
            new_hat.transform.SetParent(transform);
        }
        hat = selected_hat;
    }

    public void equipEffect()
    {
        if (effect_pointer != null) Destroy(effect_pointer);

        if (selected_effect != null)
        {
            GameObject new_effect = Instantiate(selected_effect);
            effect_pointer = new_effect;

            new_effect.transform.Translate(new Vector3(transform.position.x, transform.position.y, 0));
            new_effect.transform.SetParent(transform);
        }
        effect = selected_effect;
    }

}
