using UnityEngine;
using System.Collections;

public class ItemTypeProjectile : ItemUseable {

	// Use this for initialization
	void Start () {
        ItemType = UseType.Tool;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Use()
    {
        print("Using Projectile Tool Item");

    }
}
