using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM4Canvas : MonoBehaviour
{
    public static SM4Canvas instance = null;
    public Canvas canvas;
    public Vector2 canvasSize;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);   
            Debug.Log("Error in SM4Canvas");
        }
            
        canvas = this.gameObject.GetComponent<Canvas>();
        canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;
    }

    public void SetMainCanvasResolution(Vector2 resolution)
    {
        canvasSize = resolution;
        canvas.GetComponent<RectTransform>().sizeDelta = resolution;
    }
}
