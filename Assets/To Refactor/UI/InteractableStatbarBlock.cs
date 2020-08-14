using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractableStatbarBlock : MonoBehaviour
{
    public SMCreator smCreator;


    public Slider slider;
    public Image Background;
    public Image fill;
    public TextMeshProUGUI statName;
    public TextMeshProUGUI value;
    public Button plus;
    public Button minus;
    public Slider slideroverlay;
    public Image filloverlay;
    public int valueOfPoint = 1;
    public int valueOfPlus = 1;
    public int valueOfMinus = 1;

    private void Start()
    {
        updateValueText();
    }
    public void updateValueText()
    {
        //value.text = slider.value.ToString() + "/" + valueMax.ToString();
        value.text = slider.value.ToString();
    }
    public void updateMaxValue(int newMaxValue)
    {
        slider.maxValue = newMaxValue;
    }
    public void updateMinValue(int newMinValue)
    {
        slider.minValue = newMinValue;
    }
    public void PressMinus()
    {
        bool noLimitReached = true;
        float x = slider.value - valueOfPlus;
        if (x < slideroverlay.value)
        {
            slider.value = slideroverlay.value;
            minus.interactable = false;
            noLimitReached = false;
        }
        if (x < slider.minValue)
        {
            slider.value = slider.minValue;
            noLimitReached = false;
            
        }
        updateValueText();
        if (noLimitReached)
        {
            plus.interactable = true;
            slider.value = x;
            //give points
            smCreator.statsPoints -= valueOfPoint * valueOfMinus;
            smCreator.updatePoints();
        }
        updateValueText();
    }
    public void PresPlus()
    {
        bool noLimitReached = true;
        float x = slider.value + valueOfPlus;

        // check if player has points
        if(smCreator.points < valueOfPoint)
        {
            // return error message
            Debug.Log("Too few points");
            // play error sound
            Debug.Log("Implements sound");
            return;
        }

        if (x > slider.maxValue)
        {
            slider.value = slider.maxValue;
            noLimitReached = false;
        }
        updateValueText();
        if (noLimitReached)
        {
            minus.interactable = true;
            slider.value = x;
            //subtract points points
            smCreator.statsPoints += valueOfPoint * valueOfPlus;
            smCreator.updatePoints();
        }
        updateValueText();
    }
    public void updateValueOfPoint(int newValueOfPoint)
    {
        valueOfPoint = newValueOfPoint;
    }

}
