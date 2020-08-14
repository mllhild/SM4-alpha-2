using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControlerSceneStartMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject background;
    public GameObject loadMenu;
    public GameObject saveMenu;
    public GameObject credits;
    public GameObject introScreen;
    public GameObject smCreator;
    public GameObject optionMenu;
    public Dictionary<string,GameObject> listOfUiElements = new Dictionary<string, GameObject>();
    private void Awake()
    {
        
    }

    private void Start()
    {
        optionMenu.GetComponent<SM4UIOptions>().GetResolutions();
        var options = optionMenu.GetComponent<SM4UIOptions>().options;
        //options.LoadOptions(options,true);
        startMenu.SetActive(true);
        background.SetActive(true);
        GetUIElements();
    }


    private void GetUIElements()
    {
        listOfUiElements.Add("StartMenu", startMenu);
        listOfUiElements.Add("BG",background);
        listOfUiElements.Add("LoadMenu",loadMenu);
        listOfUiElements.Add("SaveMenu",saveMenu);
        listOfUiElements.Add("Credits",credits);
        listOfUiElements.Add("Introscreen",introScreen);
        listOfUiElements.Add("SMCreator",smCreator);
        listOfUiElements.Add("Options",optionMenu);
    }

    public void SetUIElement(string name, bool state)
    {
        try
        {
            listOfUiElements[name].SetActive(state);
        }
        catch
        {
            return;
        }
        
    }

    public void HideAllUIElements()
    {
        foreach (var sKey in listOfUiElements.Keys)
        {
            SetUIElement(sKey, false);
        }
    }
    
}
