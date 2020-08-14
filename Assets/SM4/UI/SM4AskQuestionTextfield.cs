using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SM4AskQuestionTextfield : MonoBehaviour
{
    public TextMeshProUGUI question;
    public TextMeshProUGUI questionDisplay;
    public VerticalLayoutGroup verticalLayoutGroup;
    public List<SM4AnswerTextfield> answers = new List<SM4AnswerTextfield>();
    

    public void SetQuestion(string text)
    {
        question.text = text;
        questionDisplay.text = text;
    }

    
    public GameObject questionTemplate;
    public void AddAnswer(string text, string eventName)
    {
        var newQuestion = Instantiate(questionTemplate, questionTemplate.transform.parent);
        newQuestion.SetActive(true);
        var answer = newQuestion.GetComponent<SM4AnswerTextfield>();
        answers.Add(answer);
        answer.SetQuestion(text);
        answer.SetKeyshortcut(answers.Count.ToString());
        //SM4FindEvent.instance.FindEventByNameViaCouroutine(eventName, answer.nextEvent);
        answer.SetEvent(SM4FindEvent.instance.FindEventByName(eventName));
        
        this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }

    public void EndQuestion(SM4Event sm4Event)
    {
        SM4Event sm4EventBU = new SM4Event();
        sm4EventBU = sm4Event;
        foreach (var answer in answers)
            Destroy(answer.gameObject);
        answers.Clear();
        this.gameObject.SetActive(false);
        SM4UIMainTextfield.instance.activeQuestion = false;
        SM4EventExecute.instance.ExecuteEvent(sm4EventBU);
    }
    public void AbortQuestion()
    {
        foreach (var answer in answers)
            Destroy(answer.gameObject);
        answers.Clear();
        this.gameObject.SetActive(false);
        SM4UIMainTextfield.instance.activeQuestion = false;
    }
    
}
