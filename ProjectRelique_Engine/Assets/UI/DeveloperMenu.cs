using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeveloperMenu : Screen {

    Player player;

    Dropdown dropdown;

    

	// Use this for initialization
	void Start () {
        dropdown = transform.FindChild("Dropdown").GetComponent<Dropdown>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GivePlayerItem()
    {
        string toFind = "Empty";
        toFind = dropdown.options[dropdown.value].text;
        player.EquippedItem = ItemManager.FindWithName(toFind);
        print("Equipping " + toFind + " To Player");
    }
}
