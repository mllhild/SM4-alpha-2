using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseMenuBar : MonoBehaviour
{
    public GameObject houseSubMenu;
    public Button Rules;
    public Button Lend;
    public Button TalkTo;
    public Button Calendar;
    public Button Items;
    public Button Equipment;
    public Button Crafting;
    public Button Budget;
    public Button Travel;
    public Button Main;

    private void Awake()
    {
        Rules.onClick.AddListener(
            ()=>UIElementsHouse.instance.menuRules
                .SetActive(!UIElementsHouse.instance.menuRules.activeSelf));
    }
}

