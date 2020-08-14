using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SM4PlanningFieldBoxes : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI label;
    public Image image;
    public string eventName;
    public int timeslot;
    public int characterCode; // 0 Slave, 1 Sm , 2 Assistant
    public int participant01;
    public int participant02;
    public int durationTotal;
    public int durationRemaining;
    

    public void Awake()
    {
        //button.onClick.AddListener(() => SM4PlanningScreen.instance.RemoveSelectedTrainingField(this));
    }
}
