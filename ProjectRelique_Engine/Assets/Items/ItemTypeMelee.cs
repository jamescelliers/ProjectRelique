using UnityEngine;
using System.Collections;

public class ItemTypeMelee : ItemUseable  {

    public Vector2 HitColliderSize;

	void Start () {
        ItemType = UseType.Tool;
        itemCollider.size = HitColliderSize;
    }
	

	void Update () {
	
	}

    public override void Use()
    {
        print("Using Melee Tool Item");
    }
}
