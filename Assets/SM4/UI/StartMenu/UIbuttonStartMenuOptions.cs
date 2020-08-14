using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIbuttonStartMenuOptions : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SubMenu);
    }
    public void SubMenu()
    {
        GetComponentInParent<UIControlerSceneStartMenu>().SetUIElement("Options", true);
        GetComponentInParent<UIControlerSceneStartMenu>().SetUIElement("StartMenu", false);
    }
}
