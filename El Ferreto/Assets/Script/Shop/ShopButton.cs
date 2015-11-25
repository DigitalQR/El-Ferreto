using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopButton : MonoBehaviour {

    private float track = 0;
    private float range = 0.01f;

    public GameObject item;
    public bool hat;
    public bool move_object = false;
    public Text header;
    public Text price;
    public Button button;
    public GameObject model;

    public GameObject display_item;

    void Start()
    {
        if (item != null) updateDisplay();
        else 
        {
            header.text = "Nothing";
            price.text = "";
        }
    }

    public void updateDisplay()
    {
        display_item = Instantiate(item);

        header.text = item.GetComponent<Item>().item_name; 
        price.text = "" + item.GetComponent<Item>().item_price;

        display_item.transform.position += new Vector3(model.transform.position.x, model.transform.position.y, 1);
        display_item.transform.SetParent(model.transform);
    }

    void Update()
    {
        if (display_item != null && move_object)
        {
            track += Time.deltaTime;
            display_item.transform.Translate(new Vector3(Mathf.Cos(track), 0, 0) * range);
        }
    }

    public void OnClick()
    {
        if (hat)
            Outfiter.selected_hat = item;
        else
            Outfiter.selected_effect = item;
    }

}
