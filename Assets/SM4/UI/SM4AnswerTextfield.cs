using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class SM4AnswerTextfield : MonoBehaviour
{
    public TextMeshProUGUI question;
    public TextMeshProUGUI questionDisplay;
    public TextMeshProUGUI keyshortcutDisplay;
    public SM4Event nextEvent;
    public Button button;
    public Image image;
    public string keyshortcut = "0";
        
    
    private void Start()
    {
        question.raycastTarget = false;
        questionDisplay.raycastTarget = false;
        keyshortcutDisplay.raycastTarget = false;
        button.onClick.AddListener(DoEventOnClick);
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyshortcut)) { DoEventOnClick(); }
    }

    public void SetEvent(SM4Event sm4Event) { nextEvent = sm4Event; }
    

    public void SetKeyshortcut(string key)
    {
        keyshortcut = key;
        keyshortcutDisplay.text = keyshortcut + ".";
    }
    
    public void SetQuestion(string text)
    {
        question.text = text;
        questionDisplay.text = text;
    }
    
    public void DoEventOnClick()
    {
        SM4UIMainTextfield.instance.askQuestionTextfield.EndQuestion(nextEvent);
        Debug.Log("Presseed");
        
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
