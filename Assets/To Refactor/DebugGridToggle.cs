using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugGridToggle : MonoBehaviour
{
    public Toggle toggle;
    public TextMeshProUGUI toggleText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetToggle(string label, bool state)
    {
        toggleText.text = label;
        toggle.isOn = state;
    }
}
