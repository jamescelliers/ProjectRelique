using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour
{

    public static Item[] Items;
    public Item[] ItemsToLoad;

    protected ItemManager() { }

    void Awake()
    {
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
        print("ERROR: Couldnt find item with name of \"" + nameToFind + "\". Returned Default(empty) Item instead");
        return Items[0].gameObject;
    }

    public void SetItems()
    {
        Items = ItemsToLoad;

    }
}
