using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{

    public string Name;
    private bool dropped;

    public Sprite EquippedSprite;
    public Sprite DroppedSprite;
    public Sprite[] UseAnimationSprites;
    public int DefaultSpriteIndex;

    public bool Dropped
    {
        get { return dropped; }
        set
        {
            if (!value)
            {
                //Pickup

            }
            else
            {
                //Drop
                transform.SetParent(null);
                gameObject.AddComponent<SpriteRenderer>().sprite = DroppedSprite;
            }
            dropped = value;
        }
    }

    public virtual void Use()
    {
        if (!dropped)
        {
            print("Tried To Use Item (Does nothing, is it Empty?)");
        }
    }


}
