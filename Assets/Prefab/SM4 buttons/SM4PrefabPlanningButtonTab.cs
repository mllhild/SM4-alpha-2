using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SM4PrefabPlanningButtonTab : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI label;
    public Button button;
    public string eventName;
    public string hintCode;
    public int durationInHours;
    public int participant01;
    private int participant02;
    


    private void Awake()
    {
        button.onClick.AddListener(() => AddPlanningActToDailyPlan());
    }

    private void OnMouseEnter()
    {
        if(!SM4UIMainTextfield.instance.activeQuestion)
            SM4PlanningScreen.instance.ShowHintOnHover(hintCode);
    }

    private void AddPlanningActToDailyPlan()
    {
        SM4UIMainTextfield.instance.askQuestionTextfield.AbortQuestion();
        SM4PlanningScreen.instance.FindPlanningEventAssosciatedToButton(eventName);
    }
    
}
