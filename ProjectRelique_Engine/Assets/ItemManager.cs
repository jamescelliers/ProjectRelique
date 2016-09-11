using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

    public static Item[] Items;
    public Item[] ItemsToLoad;


	void Start () {
        Items = ItemsToLoad;
	}

    public static GameObject FindWithName(string nameToFind)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i].Name == nameToFind)
            {
                return Items[i].gameObject;
            }
        }
        return Items[0].gameObject;
    }
}
