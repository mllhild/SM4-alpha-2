using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FloatingTextBox : MonoBehaviour
{
    public TextMeshProUGUI message;
    public Image panel;
    // Start is called before the first frame update


    public void DestroyOnClick()
    {
        Destroy(gameObject);
    }

}
