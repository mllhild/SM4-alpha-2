using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SM4PrefabPlanningButton : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI label;
    public Button button;
    public string eventName;


    private void Awake()
    {
        button.onClick.AddListener(() => Debug.Log(label.text));
    }

    private void TestFunction()
    {
        
    }
}
