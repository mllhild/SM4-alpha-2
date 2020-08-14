using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementsHouse : MonoBehaviour
{
    public static UIElementsHouse instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            ErrorLogger.LogErrorInFile("Error in " + this.name);
            Destroy(gameObject);   
        }
    }

    public GameObject menuRules;
    public GameObject menuHouseMenubar;
    public GameObject menuItems;
    public GameObject menuCrafting;
    public GameObject menuEquipment;

    public void HideUi()
    {
        menuRules.SetActive(false);
        menuHouseMenubar.SetActive(false);
        menuItems.SetActive(false);
        menuCrafting.SetActive(false);
        menuEquipment.SetActive(false);
    }
    
    public void ShowBaseUi()
    {
        menuHouseMenubar.SetActive(true);
        UIElementsGeneral.instance.textFieldContainer.SetActive(true);
        SM4UIMainTextfield.instance.ClearText();
    }
    
}
