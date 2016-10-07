using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{

    public GameObject canvas;
    public GameObject[] screens;

    void Awake()
    {
        GameObject[] _screens = screens; 
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i] = Instantiate(_screens[i]) ;
            screens[i].ParseCloneName();
            screens[i].transform.localScale = new Vector3(1, 1, 1);
            screens[i].transform.SetParent(canvas.transform, false);
            
            if (screens[i].GetComponent<Screen>().StartShowing == false)
            {
                ToggleScreen(screens[i].GetComponent<Screen>());
            }

        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            Screen devScreen = FindScreen("Menu_Developer");
            if (devScreen)
            {
                ToggleScreen(devScreen);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Screen invScreen = FindScreen("Menu_Inventory");
            if (invScreen)
            {
                ToggleScreen(invScreen);
            }
        }
    }

    private void ToggleScreen(Screen screen)
    {
        screen.Showing = !screen.Showing;
        if (screen.Showing)
        {
            print("Showing " + screen.Name + " Screen");
            screen.gameObject.SetActive(true);
        }else
        {
            print("Hiding " + screen.Name + " Screen");
            screen.gameObject.SetActive(false);
        }
    }

    private Screen FindScreen(string name)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            Screen screen = screens[i].GetComponent<Screen>();
            if (screen.Name == name)
            {
                return screen;
            }
        }

        return null;
    }
}
