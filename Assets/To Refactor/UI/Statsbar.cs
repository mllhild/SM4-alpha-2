using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Statsbar : MonoBehaviour
{
    public Slider slider;
    public Image Background;
    public Image icon;
    public Image fill;
    public TextMeshProUGUI statName;
    public TextMeshProUGUI value;


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
    public void updatePlusMinusIcon(float change)
    {
        if(change == 0)
        {
            icon.gameObject.SetActive(false);
            return;
        }
        if(change > 0)
        {
            icon.gameObject.SetActive(true);
            icon.sprite = Resources.Load<Sprite>("UI/Icons/Plus");
            return;
        }
        else
        {
            icon.gameObject.SetActive(true);
            icon.sprite = Resources.Load<Sprite>("UI/Icons/Minus");
            return;
        }
    }
}
