using UnityEngine;
using System.Collections;

public class ItemUseable : Item {

    public Sprite[] UseAnimationSprites;
    public int DefaultSpriteIndex;
    public enum UseType {Tool, Consumable, Placeable }
    public UseType ItemType;
    public override void Use()
    {
        print("using overriden item");
    }
    
}
