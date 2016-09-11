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
        }
    }

    private Vector3 mousePos;
    private Vector3 playerPos;
    private float angle;
    private float currentSpeed = 5;

    private GameObject legs;

    void Start()
    {
        legs = transform.FindChild("Legs").gameObject;
        EquippedItem = ItemManager.FindWithName("Rock");
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 10;
        playerPos = Camera.main.WorldToScreenPoint(transform.position); // convert player pos to screen coords
        mousePos.x = mousePos.x - playerPos.x; //parse distance
        mousePos.y = mousePos.y - playerPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg; // get angle to rotate to from mouse
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // rotate to angle

        float vAmount = Input.GetAxis("Vertical");
        transform.position += (Vector3.up * vAmount * Time.deltaTime * currentSpeed);
        float hAmount = Input.GetAxis("Horizontal");
        transform.position += (Vector3.right * hAmount * Time.deltaTime * currentSpeed);

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
