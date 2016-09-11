using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public string Name;
    public Sprite EquippedSprite;
    public Sprite DroppedSprite;
    private bool dropped;
    public bool Dropped {
        get { return dropped; }
        set {
            if (!value)
            {

            }else
            {

            }
            dropped = value;
        }
    }


}
