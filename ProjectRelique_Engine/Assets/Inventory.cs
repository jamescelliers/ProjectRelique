using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    private GameObject[] slots;
    private int size = 20;

    private void Awake()
    {
        slots = new GameObject[size];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new GameObject("Slot" + i);
            slots[i].transform.SetParent(transform);
            slots[i].AddComponent<InventorySlot>();
        }
    }

    public void Add(GameObject item)
    {
        //find next empty
    }

    public void Replace(GameObject item, int index)
    {
        //Add in index
    }

    public InventorySlot[] GetSlots()
    {
        InventorySlot[] _slots = new InventorySlot[slots.Length];
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i] = slots[i].GetComponent<InventorySlot>();
        }
        return _slots;
    }

    public void FindNextSlotWithItem(string itemName)
    {
        //iterate slots and check if item name is same as input param
    }
}
