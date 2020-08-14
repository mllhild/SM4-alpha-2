using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class SM4AskquestionPopUp : MonoBehaviour
{
    
    public static SM4AskquestionPopUp instance = null;
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
    
    
    public TextMeshProUGUI askQuestionTextfield;
    public GameObject popup;
    public GameObject questionTemplate;
    public List<SM4AnswerPopup> answers = new List<SM4AnswerPopup>();
    public SM4CharacterPortrait portraitLeft;
    public SM4CharacterPortrait portraitRight;
    public SM4CharacterPortrait portraitBackup;


    public void AskQuestion(XElement xElement)
    {
        SM4UIMainTextfield.instance.activeQuestion = true;
        askQuestionTextfield.text = "";
        askQuestionTextfield.text += xElement.FirstAttribute.Value;
        if(xElement.FirstAttribute.Name == "person")
            askQuestionTextfield.text += ":  " + xElement.FirstAttribute.NextAttribute.Value;
    }

    public void ShowPopup() { popup.SetActive(true); }

    public void HidePopup()
    {
        popup.SetActive(false);
        portraitLeft.gameObject.SetActive(false);
        portraitRight.gameObject.SetActive(false);
    }

    public void ShowPortrait(ImageAttributes imageAttributes, string position)
    {
        if(position == "left")
        {
            SM4ImageLoader.instance.UWBeasy(imageAttributes, portraitLeft.portrait);
            portraitLeft.nameOfCharacter.text = imageAttributes.misc;
            portraitLeft.gameObject.SetActive(true);
            
        }
        else
        {
            SM4ImageLoader.instance.UWBeasy(imageAttributes, portraitRight.portrait);
            portraitRight.nameOfCharacter.text = imageAttributes.misc;
            portraitRight.gameObject.SetActive(true);
        }
    }

    public void AddAnswer(XElement xElement)
    {
        var newQuestion = Instantiate(questionTemplate, questionTemplate.transform.parent);
        newQuestion.SetActive(true);
        var newAnswer = newQuestion.GetComponent<SM4AnswerPopup>();
        answers.Add(newAnswer);
        newAnswer.SetAnswer(xElement.FirstAttribute.Value);
        newAnswer.SetKeyshortcut(answers.Count.ToString());
        newAnswer.SetEvent(SM4FindEvent.instance.FindEventByName(xElement.FirstAttribute.NextAttribute.Value));
        ShowPopup();
    }

    public void EndQuestion(SM4Event sm4Event)
    {
        SM4Event sm4EventBU = new SM4Event();
        sm4EventBU = sm4Event;
        foreach (var answer in answers)
            Destroy(answer.gameObject);
        answers.Clear();
        HidePopup();
        ResetPortraits();
        SM4UIMainTextfield.instance.activeQuestion = false;
        SM4EventExecute.instance.ExecuteEvent(sm4EventBU);
    }
    public void AbortQuestion()
    {
        foreach (var answer in answers)
            Destroy(answer.gameObject);
        answers.Clear();
        HidePopup();
        ResetPortraits();
        SM4UIMainTextfield.instance.activeQuestion = false;
    }

    public void ResetPortraits()
    {
        portraitLeft.portrait.rectTransform.sizeDelta = portraitBackup.portrait.rectTransform.sizeDelta;
        portraitRight.portrait.rectTransform.sizeDelta = portraitBackup.portrait.rectTransform.sizeDelta;
        Destroy(portraitLeft.portrait.texture);
        Destroy(portraitRight.portrait.texture);
    }
    
    


    private void Start()
    {
        //AddAnswer("Hello0", new SM4Event());
        
    }
}
