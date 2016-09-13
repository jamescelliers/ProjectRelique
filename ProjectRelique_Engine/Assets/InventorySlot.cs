using UnityEngine;
using System.Collections;

public class InventorySlot : MonoBehaviour {

    private bool initialized = false;
    public bool Initialized {
        get { return initialized; }
        private set { initialized = value; }
    }
    public int Index { get; set; }
    public GameObject ItemInSlot { get; set; }
    public int ItemCondition { get; set; }
    public int ItemAmmo { get; set; }

    // Use this for initialization
    void Start () {
        Index = int.Parse(gameObject.name.Replace("Slot", ""));
        ItemInSlot = ItemManager.FindWithName("Empty");
        print("Created Inventory Slot with Index of [" + Index + "] and " + ItemInSlot.GetComponent<Item>().Name + " as Default Item");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
