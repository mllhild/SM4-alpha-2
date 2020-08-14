using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugGridButton : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI buttonText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButton(string label)
    {
        buttonText.text = label;
    }
    public string ReturnLabel()
    {
        return buttonText.text;
    }
    public void ClickMe()
    {
        /*
        string parentNode = ReturnLabel();
        //this.gameObject.SetActive(false);
        Destroy(this);
        string path = FindObjectOfType<mllhildTestController>().path;
        Debug.Log(path);

        FindObjectOfType<mllhildTestController>().DidYouFindMe(buttonText.text);
        
        FindObjectOfType<mllhildTestController>().Load(path, parentNode);
        FindObjectOfType<mllhildTestController>().AddText(parentNode+"\n");

        //string path = this.GetComponentInParent<mllhildTestController>().path;
        //this.GetComponentInParent<mllhildTestController>().Clear();
        //this.GetComponentInParent<mllhildTestController>().Load(path, parentNode);
        */
    }
}
