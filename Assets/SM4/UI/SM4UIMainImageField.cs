using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SM4UIMainImageField : MonoBehaviour
{

    public RawImage[] arrayOfLayersOfRawImages = new RawImage[11];
    public List<RawImage> listOfInstanciatedRawImages = new List<RawImage>();
    public RawImage templateRawImage;
    public RectTransform imageWindow;
    

    public static SM4UIMainImageField instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            ErrorLogger.LogErrorInFile("Error in " + this.name);
            Destroy(gameObject);   
        }
    }

    private void Start()
    {
        SetImageBoxToDefaultPosition();
    }

    public RectTransform imageContainerTransform;

    public void SetImageBoxToDefaultPosition()
    {
        var canvasSize = SM4Canvas.instance.canvasSize;
        var textboxSize = this.GetComponent<RectTransform>().sizeDelta;
        var textboxSizeNew = new Vector2(1245 * canvasSize.x /1920,700*canvasSize.y /1080);
        this.GetComponent<RectTransform>().sizeDelta = textboxSizeNew;
        imageContainerTransform.sizeDelta = textboxSizeNew;
        var textboxPositionNew = new Vector3((960 *canvasSize.x / 1920),330 * canvasSize.y / 1080 + textboxSizeNew.y / 2,0 );
        imageContainerTransform.anchoredPosition = textboxPositionNew;
    }

    
    
}

