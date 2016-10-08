using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour{
    public GameObject menuMain, menuOptions, menuLevelSel;
    public void levelSelect(int num)
    {
        Application.LoadLevel(num);
    }

    public void menuSelect(string name)
    {
        if (name.Equals("Main"))
        {
            menuOptions.GetComponent<Canvas>().enabled = false;
            menuMain.GetComponent<Canvas>().enabled = true;
            menuLevelSel.GetComponent<Canvas>().enabled = false;
        }
        if (name.Equals("Options"))
        {
            menuOptions.GetComponent<Canvas>().enabled = true;
            menuMain.GetComponent<Canvas>().enabled = false;
            menuLevelSel.GetComponent<Canvas>().enabled = false;
        }
        if (name.Equals("LevelSelect"))
        {
            menuOptions.GetComponent<Canvas>().enabled = false;
            menuMain.GetComponent<Canvas>().enabled = false;
            menuLevelSel.GetComponent<Canvas>().enabled = true;
        }
        else if (name.Equals("Play"))
            Application.LoadLevel(1);
        else if (name.Equals("Exit"))
        {
            Application.Quit();
        }
    }
    void Start()
    {
        Vector3 hideMenu = new Vector3(0, 0, 0);
        Vector3 showMenu = new Vector3(1, 1, 1);
        menuLevelSel.GetComponent<Canvas>().enabled = false;
        menuOptions.GetComponent<Canvas>().enabled = false;
        menuMain.GetComponent<Canvas>().enabled = true;
        //menuMain.transform.localScale = showMenu;
        //menuOptions.transform.localScale = hideMenu;
        //menuLevelSel.transform.localScale = hideMenu;
    }


}