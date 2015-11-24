using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopButton : MonoBehaviour {

    public GameObject item;
    public bool hat;
    public Text header;
    public Text price;
    public Button button;
    public GameObject model;

    void Start()
    {
        updateDisplay();
    }

    public void updateDisplay()
    {
        GameObject display_item = Instantiate(item);

        header.text = item.GetComponent<Item>().item_name;
        price.text = "" + item.GetComponent<Item>().item_price;

        display_item.transform.position += new Vector3(model.transform.position.x, model.transform.position.y, 1);
        display_item.transform.SetParent(model.transform);
    }

    public void OnClick()
    {
        if (hat)
            Outfiter.selected_hat = item;
        else
            Outfiter.selected_effect = item;
    }

}
