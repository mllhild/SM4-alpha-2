using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIbuttonStartMenuNewGame : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SubMenu);
    }
    public void SubMenu()
    {
        GetComponentInParent<UIControlerSceneStartMenu>().SetUIElement("Introscreen", true);
        FindObjectOfType<StartNewGameIntroScreen>().StartIntroScreen();
        GetComponentInParent<UIControlerSceneStartMenu>().SetUIElement("StartMenu", false);
    }
            

}
