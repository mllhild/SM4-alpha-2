using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DebugGridImputfield : MonoBehaviour
{
    public TextMeshProUGUI varName;
    public TMP_InputField input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUp(string label, string inputfield)
    {
        varName.text = label;
        input.text = inputfield;
    }
    public void SetUpEmpty(string label)
    {
        varName.text = label;
        input.text = null;
    }
}
