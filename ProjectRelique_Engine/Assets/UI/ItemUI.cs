using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetText(string text)
    {
        transform.FindChild("Text").GetComponent<Text>().text = text;
    }
}
