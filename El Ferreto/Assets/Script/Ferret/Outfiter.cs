using UnityEngine;
using System.Collections;

public class Outfiter : MonoBehaviour {

    public static GameObject selected_hat;
    public static GameObject selected_effect;

    private GameObject hat;
    private GameObject effect;

    void update() {
        if (hat != selected_hat) {
            equipHat();
        }
    }

    public void equipHat() {
        if (hat != null) DestroyImmediate(hat);
    }

}
