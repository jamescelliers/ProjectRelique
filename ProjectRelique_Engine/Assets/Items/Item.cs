using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{

    public string Name;
    public Sprite EquippedSprite;
    public Sprite DroppedSprite;
    private bool dropped;
    public bool Dropped
    {
        get { return dropped; }
        set
        {
            if (!value)
            {

            }
            else
            {
                itemCollider.size = ColliderSize;
                transform.SetParent(null);
                gameObject.AddComponent<SpriteRenderer>().sprite = DroppedSprite;
            }
            dropped = value;
        }
    }
    public Vector2 ColliderSize;
    public BoxCollider2D itemCollider { get; private set; }

    void Awake()
    {
        itemCollider = gameObject.AddComponent<BoxCollider2D>();
        itemCollider.isTrigger = true;
        itemCollider.size = ColliderSize;
        itemCollider.offset = new Vector2( 0.0f, ColliderSize.y / 2);
    }

    public virtual void Use()
    {
        if (!dropped)
        {
            print("Used Item");
        }
    }


}
