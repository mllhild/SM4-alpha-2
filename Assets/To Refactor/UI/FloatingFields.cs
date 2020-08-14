using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FloatingFields : MonoBehaviour
{
    public FloatingTextBox textfieldPrefab;
    public List<FloatingTextBox> messages = new List<FloatingTextBox>();

    public void SpeechBubble(string message, string path, float positionX, float positionY, float angleDegrees, float height, float width,float textX, float textY, float textSize)
    {
        //if (positionY > Screen.currentResolution.height || positionY < 0)
        //{
        //    positionY = Screen.currentResolution.height / 2;
        //}
        //if (positionX > Screen.currentResolution.width || positionX < 0)
        //{
        //    positionX = Screen.currentResolution.width / 2;
        //}
         
        Vector3 pos = new Vector3(0, 0, 0);
        Quaternion rot = Quaternion.Euler(0, 0, 0);
        FloatingTextBox textfield = Instantiate(textfieldPrefab, pos, rot, transform.gameObject.transform) as FloatingTextBox;
        //Debug.LogFormat("{0} {1}", textfield.transform.position.x, textfield.transform.position.x);
        //messages.Add();
        height = height / 100;
        width = width / 100;

        textfield.panel.sprite = Resources.Load<Sprite>(path);
        textfield.panel.transform.localScale = new Vector3(height , width , 0);
        textfield.panel.transform.localPosition = new Vector3(positionX, positionY, 0);
        
        textfield.message.transform.localScale = new Vector3(1/height, 1/width, 0);
        textfield.message.transform.localPosition = new Vector3(textX, textY, 0);
        textfield.message.fontSize = textSize;
        


        //textfield.transform.localScale = new Vector3(height/100, width/100, 1);
        //textfield.transform.position = new Vector3(positionX, positionY, 0);
        textfield.GetComponentInChildren<TextMeshProUGUI>().text = message;

    }
}
