using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SM4UIGold : MonoBehaviour
{
    public TextMeshProUGUI gold;
    public void GetCurrentGoldValue()
    {
        gold.text = SM4SlaveMakerControler.instance.slaveMaker.general.goldOwned.ToString();
    }
}
