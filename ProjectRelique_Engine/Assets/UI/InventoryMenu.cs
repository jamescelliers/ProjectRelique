using UnityEngine;
using System.Collections;

public class InventoryMenu : Screen {

    public GameObject ItemButtonPrefab;
    GameObject[] itemButton;
    InventorySlot[] itemList;
    public GameObject itemListParent;

	void Start () {
        itemList = GameObject.FindWithTag("Inventory").GetComponent<Inventory>().GetSlots();
        itemButton = new GameObject[itemList.Length];
        for (int i = 0; i < itemList.Length; i++)
        {
            itemButton[i] = Instantiate(ItemButtonPrefab);
            itemButton[i].ParseCloneName();
            itemButton[i].transform.SetParent(itemListParent.transform);
            itemButton[i].transform.localScale = new Vector3(1, 1, 1);
            itemButton[i].gameObject.name = "ItemUI" + i;
            itemButton[i].GetComponent<ItemUI>().SetText(itemList[i].ItemInSlot.GetComponent<Item>().Name);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
