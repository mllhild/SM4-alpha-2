using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIbuttonStartMenuContinue : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SubMenu);
    }
    public void SubMenu()
    {
        GetComponentInParent<UIControlerSceneStartMenu>().SetUIElement("StartMenu", false);
        // get last save function not yet added
    }
}
