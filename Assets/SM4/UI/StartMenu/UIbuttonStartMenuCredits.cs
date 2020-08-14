using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIbuttonStartMenuCredits : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SubMenu);
    }
    public void SubMenu()
    {
        GetComponentInParent<UIControlerSceneStartMenu>().SetUIElement("Credits", true);
        GetComponentInParent<UIControlerSceneStartMenu>().SetUIElement("StartMenu", false);
    }
}
