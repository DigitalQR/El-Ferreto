using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopButton : MonoBehaviour {

    private static uint item_track = 0;
    private uint ID = item_track++;

    public Text header;
    public Text price;
    public Button button;
    public GameObject item;

    void Start()
    {
        updateDisplay();
        Debug.Log("Item '" + item.name + "' ID:" + ID);
    }

    public void updateDisplay()
    {
        GameObject display_item = Instantiate(item);

        header.text = item.GetComponent<Item>().item_name;
        price.text = "" + item.GetComponent<Item>().item_price;

        display_item.transform.position = new Vector3(transform.position.x-0.3f, transform.position.y - 0.4f, -1);
        display_item.transform.SetParent(transform);
    }

}
