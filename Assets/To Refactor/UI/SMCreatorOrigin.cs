using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SMCreatorOrigin : MonoBehaviour
{
    public Toggle toggle;
    public TextMeshProUGUI shortcut;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI pointsText;
    public int points;
    public bool male;
    public bool female;
    public bool futa;
    public void Start()
    {
        pointsText.text = points.ToString() + " Points";
    }

}