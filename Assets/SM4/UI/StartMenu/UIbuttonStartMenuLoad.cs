using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIbuttonStartMenuLoad : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SubMenu);
    }
    public void SubMenu()
    {
        GetComponentInParent<UIControlerSceneStartMenu>().SetUIElement("LoadMenu", true);
        GetComponentInParent<UIControlerSceneStartMenu>().SetUIElement("StartMenu", false);
    }
}
