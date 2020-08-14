using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public TextMeshProUGUI nameItem;
    public int value;
    public TextMeshProUGUI valueTMP;
    public TextMeshProUGUI loreTMP;
    public int quantity;
    public TextMeshProUGUI quantityTMP;

    public bool craftingIngredient;

    public bool equippable;     // can it be equipped?
    public bool consumable;     // can it be consumed
    public int ID;              // ID number of the object
    public string itemName;     // Name of item
    public string path;         // path to image file
    public string loreShort;    // flavor text
    public string loreLong;     // detailed Lore
    public int valueBase;		// base value of the object. Value in market is derived from this

}

