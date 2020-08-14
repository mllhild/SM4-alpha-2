using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RulesMenu : MonoBehaviour
{
    public GameObject rulesScreen;
    public Toggle[] rules = new Toggle[11];

    private void Start()
    { 
     SetRulesDisplay();
    }

    public void SetRulesDisplay()
    {
     for (int i = 0; i < 11; i++)
     {
         string ruleText = null;
         rules[i].isOn = SM4SlaveMakerControler.instance.slaveMaker.rulesAreOn[i];
         if (rules[i].isOn)
         {
          ruleText = SM4SlaveMakerControler.instance.slaveMaker.rulesTextOn[i];
         }
         else
         {
          ruleText = SM4SlaveMakerControler.instance.slaveMaker.rulesTextOff[i];
         }

         if (ruleText == null)
         {
          ruleText = FindRuleText(i);
         }

         if (ruleText != "")
         {
          rules[i].gameObject.SetActive(true);
          rules[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = ruleText;
         }
         else
         {
          rules[i].gameObject.SetActive(false);
         }
     }
    }

    public void SwitchOnOff(int x)
    {
        string ruleText;
        ruleText = FindRuleText(x);
        rules[x].GetComponentInChildren<TextMeshProUGUI>().text = ruleText;
    }
    public string FindRuleText(int x)
    {
        switch (x)
        {
            case 0:
                if (rules[x].isOn)
                 return "May talk anytime and express their opinions";
                else
                 return "Only permitted to talk when spoken to";
            case 1:
                if (rules[x].isOn)
                 return "May pray to the gods and study scripture";
                else
                 return "Cannot pray. You are all the guidance your slaves need!";
            case 2:
                if (rules[x].isOn)
                 return "May go out unsupervised, even visiting friends alone";
                else
                 return "Will be supervised at all times when leaving your home";
            case 3:
                if (rules[x].isOn)
                 return "Fuck anyone, anytime";
                else
                 return "May only fuck when and with whom you so order";
            case 4:
                if (rules[x].isOn)
                 return "May masturbate anytime they desire";
                else
                 return "Can only masturbate when you so order it";
            case 5:
                if (rules[x].isOn)
                 return "May write letters to their family & friends";
                else
                 return "Cannot write or receive letters to their family & friends";
            case 6:
                if (rules[x].isOn)
                 return "Will have a little pocket money to spend as they like";
                else
                 return "Will have no money to spend";
            case 7:
                if (rules[x].isOn)
                 return "";
                else
                 return "";
            case 8:
                if (rules[x].isOn)
                 return "";
                else
                 return "";
            case 9:
                if (rules[x].isOn)
                 return "";
                else
                 return "";
            case 10:
                if (rules[x].isOn)
                 return "";
                else
                 return "";
            default:
                    return "error";
        }
    }
}
