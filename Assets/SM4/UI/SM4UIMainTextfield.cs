using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SM4UIMainTextfield : MonoBehaviour
{
    public GameObject textfieldBox;
    public TextMeshProUGUI textfield;
    public Scrollbar scrollbar;

    public static SM4UIMainTextfield instance = null;
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

  

    private void Start()
    {
        //SetTextBoxToDefaultPosition();
    }

    public void SetTextBoxToDefaultPosition()
    {
        var canvasSize = SM4Canvas.instance.canvasSize;
        var textboxSize = textfieldBox.GetComponent<RectTransform>().sizeDelta;
        var textboxSizeNew = new Vector2(800 * canvasSize.x /1920,300*canvasSize.y /1080);
        textfieldBox.GetComponent<RectTransform>().sizeDelta = textboxSizeNew;
        var textboxPositionNew = new Vector3((960 *canvasSize.x / 1920),20 * canvasSize.y / 1080 + textboxSizeNew.y / 2,0 );
        textfieldBox.GetComponent<RectTransform>().anchoredPosition = textboxPositionNew;
    }

    private void Update()
    {
        //ResizeContentField();
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scrollbar.value -= scrollbar.size;
            if (scrollbar.value < 0)
                scrollbar.value = 0;
        }*/
    }
    
    
    public void ClearText()
    {
        textfield.text = "";
        textfield.rectTransform.sizeDelta = new Vector2(textfield.rectTransform.sizeDelta.x, textfield.GetComponentInParent<RectTransform>().sizeDelta.y);
        //textfield.fontSize = default from options
    }
    public void AddText(string text)
    {
        textfield.text += text;
        //ResizeTextField();
        
    }
    
    public void BlankLine()
    {
        textfield.text += "\n\n";
    }
    public void LineBreak()
    {
        textfield.text += "\n";
    }

    public void PersonSpeak(PersonSpeakAttributes attributes)
    {
        if(textfield.text != "")
            AddText("\n");
        var nameOfSM = SM4SlaveMakerControler.instance.slaveMaker.nameChar.first;
        if (nameOfSM == null)
            nameOfSM = "SlaveMaker";

        switch (attributes.personName)
        {
            case "sm":
                AddText("<color=#660000><b><i>");
                AddText(nameOfSM);
                AddText(" :</i></b></color>   ");
                AddText("<color=#000000>");
                AddText(attributes.text);
                AddText("</color>");
                break;
            case "smcustom":
                AddText("<color=#"+attributes.color+">");
                if(attributes.bold)
                    AddText("<b>");
                if(attributes.italic)
                    AddText("<i>");
                AddText(nameOfSM);
                if(attributes.italic)
                    AddText("</i>");
                if(attributes.bold)
                    AddText("</b>");
                AddText(" :</color>   ");
                AddText(attributes.text);
                break;
            default:
                AddText("<color=#"+attributes.color+">");
                if(attributes.bold)
                    AddText("<b>");
                if(attributes.italic)
                    AddText("<i>");
                AddText(attributes.personName);
                if(attributes.italic)
                    AddText("</i>");
                if(attributes.bold)
                    AddText("</b>");
                AddText(" :</color>   ");
                AddText(attributes.text);
                break;
        }
    }

    public void ResizeTextField()
    {
        return;
        float textboxlegth = 50; 
        foreach (var character in textfield.text)
            if (character == '\n')
                textboxlegth += textfield.fontSize;
        float numberOfCharactersPerLine = textfield.rectTransform.sizeDelta.x / (textfield.fontSize / 2 * 1.3f);
        textboxlegth += (float)textfield.text.Length / numberOfCharactersPerLine * textfield.fontSize;
        textfield.rectTransform.sizeDelta = new Vector2(textfield.rectTransform.sizeDelta.x, textboxlegth);
    }
    
    
    public SM4AskQuestionTextfield askQuestionTextfield;

    public void HideQuestionTextField()
    {
        askQuestionTextfield.gameObject.SetActive(false);
    }
    public void ShowQuestionTextField()
    { askQuestionTextfield.gameObject.SetActive(true); }

    public void UpdateQuestionTextField()
    {
        HideQuestionTextField();
        ShowQuestionTextField();
    }

    public bool activeQuestion;
    public void AskQuestion(XElement xElement)
    {
        activeQuestion = true;
        string question = "";
        question += xElement.FirstAttribute.Value;
        if(xElement.FirstAttribute.Name == "person")
            question += ":  " + xElement.FirstAttribute.NextAttribute.Value;
 
        askQuestionTextfield.SetQuestion(question);
    }

    public void AddAnswer(XElement xElement)
    {
        askQuestionTextfield.AddAnswer(xElement.FirstAttribute.Value,xElement.LastAttribute.Value);
    }

    
    

    
}
