using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingMenu : MonoBehaviour
{
    public GameObject craftingScreen;
    public List<Item> ingredients = new List<Item>();
    public Item result;
    public Button craft;
    public Button cancel;
}
