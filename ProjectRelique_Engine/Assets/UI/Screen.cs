using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Screen : MonoBehaviour {

    public string Name;
    public bool Showing { get; set; }
    private RectTransform rectTransform;
    private GameObject headerText;
    public bool StartShowing;


	// Use this for initialization
	void Awake () {
        Showing = true;
        headerText = transform.FindChild("HeaderText").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}

}
