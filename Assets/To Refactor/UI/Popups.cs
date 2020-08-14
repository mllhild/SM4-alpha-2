using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Popups : MonoBehaviour
{
    public GameObject errorMessage;
    

    

   
    //public void Error(string message, float positionX, float positionY)
    //{
    //    if(positionY > Screen.currentResolution.height -100 || positionY < 0)
    //    {
    //        positionY = Screen.currentResolution.height -100;
    //    }
    //    if (positionX > Screen.currentResolution.width / 2 || positionX < 200)
    //    {
    //        positionX = 200;
    //    }
    //    messages.Add(Instantiate(errorMessage, transform.gameObject.transform);)
    //    errorMessage.transform.position = new Vector2(positionX, positionY);
    //    errorMessage.GetComponentInChildren<TextMeshProUGUI>().text = message;

    //}
    public void Error(string message)
    {
        //float positionY = 200*(messages.Count);//Screen.currentResolution.height - 100;
        //float positionX = 200;
        Instantiate(errorMessage, transform.gameObject.transform);
        //Debug.LogFormat("{0}  {1}", errorMessage.transform.position.x, errorMessage.transform.position.y);
        //errorMessage.transform.position = new Vector2(positionX, positionY);
        //messages.Add(errorMessage);
        

        //for (int i = messages.Count - 1; i >= 0; i--)
        //{
        //    messages[i].gameObject.transform.position = new Vector2(positionX, positionY);
        //    transform.position = new Vector2(positionX, positionY);
        //    Debug.LogFormat("{0}  {1}", i, positionY);
        //    //errorMessage.transform.position = new Vector2(positionX, positionY);
        //    positionY += 200;
        //}
        errorMessage.GetComponentInChildren<TextMeshProUGUI>().text = message;
    }
    public void UpdateMessages()
    {

    }
}
