using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SM4PrefabButtonSimple01 : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI label;
    public Image image;

    public void SetButtonImage(string path)
    {
        image.sprite = Resources.Load<Sprite>(path);
    }
    
}
