using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private int health = 100;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    private GameObject equippedItem;
    public GameObject EquippedItem
    {
        get { return equippedItem; }
        set
        {
            if(equippedItem != null)
            {
                Destroy(equippedItem);
            }
            equippedItem = (GameObject)Instantiate(value, transform.position, transform.rotation);
            equippedItem.ParseCloneName();
            equippedItem.transform.SetParent(transform);
            GetComponent<SpriteRenderer>().sprite = equippedItem.GetComponent<Item>().EquippedSprite;
            if (equippedItem.GetComponent<Item>())
            {
                Item item = equippedItem.GetComponent<Item>();
                if (item.UseAnimationSprites.Length > 0)
                {
                    spriteAnimator.SetSprites(item.UseAnimationSprites, item.DefaultSpriteIndex);
                }
            }
        }
    }

    private Vector3 mousePos;
    private Vector3 playerPos;
    private float angle;
    private float currentSpeed = 5;

    private SpriteAnimator spriteAnimator;
    private GameObject legs;

    void Start()
    {
        spriteAnimator = GetComponent<SpriteAnimator>();
        legs = transform.FindChild("Legs").gameObject;
        EquippedItem = ItemManager.FindWithName("Empty");
    }

    void Update()
    {
        //Input

        //Rotate
        mousePos = Input.mousePosition;
        mousePos.z = 10;
        playerPos = Camera.main.WorldToScreenPoint(transform.position); // convert player pos to screen coords
        mousePos.x = mousePos.x - playerPos.x; //parse distance
        mousePos.y = mousePos.y - playerPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg; // get angle to rotate to from mouse
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // rotate to angle

        //Move
        float vAmount = Input.GetAxis("Vertical");
        transform.position += (Vector3.up * vAmount * Time.deltaTime * currentSpeed);
        float hAmount = Input.GetAxis("Horizontal");
        transform.position += (Vector3.right * hAmount * Time.deltaTime * currentSpeed);


        //Use
        if (Input.GetButtonDown("Fire1"))
        {
            if (equippedItem.GetComponent<Item>())
            {
                print("Using item...");
                Item item = equippedItem.GetComponent<Item>();
                item.Use();
                spriteAnimator.Play();

            }
        }


        //Animate legs
        if ((hAmount > 0 || vAmount > 0) || (hAmount < 0 || vAmount < 0))
        {
            legs.SendMessage("Play");
        }
        else
        {
            legs.SendMessage("Stop");
        }
    }
}
