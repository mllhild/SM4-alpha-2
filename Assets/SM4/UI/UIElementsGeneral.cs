using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIElementsGeneral : MonoBehaviour
{
    
    public static UIElementsGeneral instance = null;
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

    public Image background;
    public GameObject textFieldContainer;
    public TextMeshProUGUI textfield;
    public GameObject mainImageField;
    public GameObject uiTopbar;
    public GameObject blackBorder;
    public UIutitlityDisplays utilityDisplays;
    public UICharactersDisplays uiCharacters;
    public GameObject systemButton;
    public GameObject buttonNext;
    public GameObject buttonPlanning;
    
    
    public void SetUtilityDisplay(bool show) => utilityDisplays.gameObject.SetActive(show);
    public void SetCharacterPortraits(bool show) => uiCharacters.gameObject.SetActive(show);
    public void SetButtonNext(bool show) => buttonNext.gameObject.SetActive(show);
    public void SetButtonPlanning(bool show) => buttonPlanning.gameObject.SetActive(show);
    
    public void HideUI()
    {
        textFieldContainer.SetActive(false);
        mainImageField.SetActive(false);
        uiTopbar.SetActive(false);
        blackBorder.SetActive(false);
        utilityDisplays.gameObject.SetActive(false);
        uiCharacters.gameObject.SetActive(false);
        buttonNext.SetActive(false);
    }
    public void ShowBaseUI()
    {
        textFieldContainer.SetActive(true);
        mainImageField.SetActive(true);
        uiTopbar.SetActive(true);
        utilityDisplays.gameObject.SetActive(true);
        uiCharacters.gameObject.SetActive(true);
        buttonNext.SetActive(true);
    }
    

    

    


}
