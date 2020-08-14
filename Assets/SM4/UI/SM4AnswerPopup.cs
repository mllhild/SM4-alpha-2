using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SM4AnswerPopup : MonoBehaviour
{
    public TextMeshProUGUI question;
    public TextMeshProUGUI questionDisplay;
    public SM4Event nextEvent;
    public Button button;
    public Image image;
    public string keyshortcut = "0";
    public TextMeshProUGUI keyshortcutDisplay;

    private void Start()
    {
        button.onClick.AddListener(DoEventOnClick); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(keyshortcut)) { DoEventOnClick(); }
    }

    public void SetEvent(SM4Event sm4Event) { nextEvent = sm4Event; }

    public void SetAnswer(string text)
    {
        question.text = text;
        questionDisplay.text = text;
    }
    
    

    public void DoEventOnClick()
    {
        SM4AskquestionPopUp.instance.EndQuestion(nextEvent);
    }
    
    public void SetKeyshortcut(string key)
    {
        keyshortcut = key;
        keyshortcutDisplay.text = keyshortcut + ".";
    }

    public void SetTextFormat(float red, float green, float blue, bool italic, bool bold, bool underlined, bool strikeThrough, float size, bool autosize, float sizeMax, float sizeMin)
    {
        question.color = new Color(red, green, blue);
        if(bold)
            question.fontStyle = FontStyles.Bold;
        if (italic)
            question.fontStyle = FontStyles.Italic;
        if (underlined)
            question.fontStyle = FontStyles.Underline;
        if(strikeThrough)
            question.fontStyle = FontStyles.Strikethrough;
        
        question.enableAutoSizing = autosize;
        if (autosize)
        {
            question.fontSizeMax = sizeMax;
            question.fontSizeMin = sizeMin;
        }
        question.fontSize = size;
    }

    
}
