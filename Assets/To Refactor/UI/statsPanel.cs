using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class statsPanel : MonoBehaviour
{
    public Image panelBG;
    public Image gender;
    public Image love;
    public Image gag;
    public Image analToy;
    public Image nameBG;
    public TextMeshProUGUI nameField;
    public Button statsButton;
    public Button skillsButton;
    public Button perksButton;
    public statColumn stats;
    public statColumn skills;
    public statColumn perks;


    public void PointsStats(float statChange, int whichStat)
    {
        stats.stats[whichStat].slider.value += statChange;
        stats.stats[whichStat].updatePlusMinusIcon(statChange);
        stats.stats[whichStat].updateValueText();
    }
    public void PointsSkills(float statChange, int whichStat)
    {
        skills.stats[whichStat].slider.value += statChange;
        skills.stats[whichStat].updatePlusMinusIcon(statChange);
        skills.stats[whichStat].updateValueText();
    }
    public void PointsPerks(float statChange, int whichStat)
    {
        perks.stats[whichStat].slider.value += statChange;
        perks.stats[whichStat].updatePlusMinusIcon(statChange);
        perks.stats[whichStat].updateValueText();
    }
    public void SetStat(float newValue, int whichStat)
    {
        stats.stats[whichStat].slider.value = newValue;
        stats.stats[whichStat].updateValueText();
    }
    public void HidePlusMinusIcons()
    {
        for (int i = 0; i < 21; i++)
        {
            stats.stats[i].icon.gameObject.SetActive(false);
            skills.stats[i].icon.gameObject.SetActive(false);
            perks.stats[i].icon.gameObject.SetActive(false);
        }
    }
}
