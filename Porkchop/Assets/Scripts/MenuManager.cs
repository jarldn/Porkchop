using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Menu currentMenu;
    // Start is called before the first frame update
    void Start()
    {
        ShowMenu(currentMenu);
    }

    // Update is called once per frame
  public void ShowMenu (Menu menu)
    {
        if (currentMenu != null)
            currentMenu.IsOpen = false;
        currentMenu = menu;
        currentMenu.IsOpen = true;
    }
}
