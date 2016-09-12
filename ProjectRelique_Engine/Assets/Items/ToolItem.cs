using UnityEngine;
using System.Collections;

public class ToolItem : Item
{

    public enum ToolType { Melee, Projectile }
    public ToolType ToolItemType;
    public GameObject HitColliderPrefab;

    private bool canFire = true;
    public float FireRate = 1f;
    private float fireRateTimer = 0f;

    void Update()
    {
        if (fireRateTimer > 0)
        {
            fireRateTimer -= Time.deltaTime;
        }
        else
        {
            fireRateTimer = 0;
            canFire = true;
        }
    }

    public override void Use()
    {
        CreateHitObject();

    }

    private void CreateHitObject()
    {
        if (canFire)
        {
            if (ToolItemType == ToolType.Melee)
            {
                GameObject hcInstance = (GameObject) Instantiate(HitColliderPrefab, 
                   transform.position, transform.rotation);
                hcInstance.transform.SetParent(transform);
                canFire = false;
            }else
            {

            }

            fireRateTimer = FireRate;
        }
    }

}
