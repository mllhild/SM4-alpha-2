using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIStartMenu : MonoBehaviour
{
    
    private List<GameObject> listOfUIelements = new List<GameObject>();
    private void Start()
    {
        listOfUIelements.Clear();
        listOfUIelements.Add(GameObject.Find("StartMenu/Panel"));
        listOfUIelements.Add(GameObject.Find("StartMenu/Menu/NewGame"));
        listOfUIelements.Add(GameObject.Find("StartMenu/Menu/Continue"));
        listOfUIelements.Add(GameObject.Find("StartMenu/Menu/Load"));
        listOfUIelements.Add(GameObject.Find("StartMenu/Menu/Saves"));
        listOfUIelements.Add(GameObject.Find("StartMenu/Menu/Options"));
        listOfUIelements.Add(GameObject.Find("StartMenu/Menu/Credits"));
        listOfUIelements.Add(GameObject.Find("StartMenu/Menu/Exit"));
        listOfUIelements.Add(GameObject.Find("StartMenu/PanelsLowerLeft"));
        listOfUIelements.Add(GameObject.Find("StartMenu/PanelsLowerMiddle"));
        listOfUIelements.Add(GameObject.Find("StartMenu/PanelsLowerRight"));
        listOfUIelements.Add(GameObject.Find("StartMenu/Banner"));
    }

    public void StartMenuVisible(bool isVisible)
    {
        this.gameObject.SetActive(isVisible);
    }
}
