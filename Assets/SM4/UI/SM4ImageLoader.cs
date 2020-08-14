using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SM4ImageLoader : MonoBehaviour
{
    public RawImage[] arrayOfLayersOfRawImages = new RawImage[11];
    public List<RawImage> listOfInstanciatedRawImages = new List<RawImage>();
    public RawImage templateRawImage;
    public RectTransform imageWindow;
    

    public static SM4ImageLoader instance = null;
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
        arrayOfLayersOfRawImages = SM4UIMainImageField.instance.arrayOfLayersOfRawImages;
        listOfInstanciatedRawImages = SM4UIMainImageField.instance.listOfInstanciatedRawImages;
        templateRawImage = SM4UIMainImageField.instance.templateRawImage;
        imageWindow = SM4UIMainImageField.instance.imageWindow;
        
        

    }


    public void InstanciateRawImage(ImageAttributes imageAttributes)
    {
        var rawImage = Instantiate(templateRawImage, templateRawImage.transform.parent);
        rawImage.name = Path.GetFileName(imageAttributes.path);
        LoadImageUnityWebRequestv2(imageAttributes, rawImage);
    }

    public void ClearIntanciatedImages()
    {
        foreach (var rawImage in listOfInstanciatedRawImages)
        {
            Destroy(rawImage.texture);
            Destroy(rawImage.mainTexture);
            Destroy(rawImage.gameObject);
        }
        listOfInstanciatedRawImages.Clear();
    }
    
    
    public void AddLayerImage(ImageAttributes imageAttributes)
    {
        arrayOfLayersOfRawImages[imageAttributes.layer].gameObject.SetActive(true);
        LoadImageUnityWebRequestv2(imageAttributes, arrayOfLayersOfRawImages[imageAttributes.layer]);
    }
    
    public void ClearLayerImages()
    {
        foreach (var rawImage in arrayOfLayersOfRawImages)
        {
            Destroy(rawImage.texture);
            rawImage.gameObject.SetActive(false);
        }
    }

    
    public void LoadImageUnityWebRequestv2(ImageAttributes imageAttributes, RawImage rawImage)
    {
        StartCoroutine(LoadImageUnityWebRequestv2Coroutine(imageAttributes, rawImage));
        
    }
    IEnumerator LoadImageUnityWebRequestv2Coroutine(ImageAttributes imageAttributes, RawImage rawImage) 
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(@imageAttributes.path);
        yield return request.SendWebRequest();
        
        if (request.isNetworkError || request.isHttpError)
        {
            ErrorLogger.LogErrorInFile(request.error);
        }
        else
        {
            rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            float ratio = 1;
            if (imageAttributes.fit || imageAttributes.fill)
            {
                var imageContainerSizeDelta = imageWindow.sizeDelta;
                imageContainerSizeDelta.x = rawImage.mainTexture.width / imageContainerSizeDelta.x;
                imageContainerSizeDelta.y = rawImage.mainTexture.height / imageContainerSizeDelta.y;
                if(imageAttributes.fit)
                    ratio = Math.Max(imageContainerSizeDelta.x, imageContainerSizeDelta.y);
                if(imageAttributes.fill)
                    ratio = Math.Min(imageContainerSizeDelta.x, imageContainerSizeDelta.y);
            }
            rawImage.rectTransform.sizeDelta = new Vector2(
                rawImage.mainTexture.width * imageAttributes.scale.x / ratio ,
                rawImage.mainTexture.height* imageAttributes.scale.y / ratio );
            
            rawImage.rectTransform.localPosition = imageAttributes.position;
            
            if(imageAttributes.rotation != new Vector3(0,0,0 ))
                rawImage.rectTransform.Rotate(imageAttributes.rotation);

            if (imageAttributes.color != new Color(1, 1, 1, 1))
                rawImage.color = imageAttributes.color;
                
            rawImage.gameObject.SetActive(true);
            
            listOfInstanciatedRawImages.Add(rawImage);
            
        }
    }


    public void LoadRawImage(string path, RawImage rawImage, bool fit, bool fill)
    {
       ImageAttributes imageAttributes = new ImageAttributes();
       imageAttributes.fit = fit;
       imageAttributes.fill = fill;
       StartCoroutine(LoadImageUnityWebRequestv2Coroutine(imageAttributes, rawImage));
    }
    
    
    public void UWBeasy(ImageAttributes imageAttributes, RawImage rawImage)
    { StartCoroutine(UWBeasyCoroutine(imageAttributes, rawImage)); }
    
    IEnumerator UWBeasyCoroutine(ImageAttributes imageAttributes, RawImage rawImage)
    {
        
        rawImage.gameObject.SetActive(false);
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(@imageAttributes.path);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError) { ErrorLogger.LogErrorInFile(request.error); }
        else
        {
            var containerSizeDelta = rawImage.rectTransform.sizeDelta;
            rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            float ratio = 1;
            
            containerSizeDelta.x = rawImage.mainTexture.width / containerSizeDelta.x;
            containerSizeDelta.y = rawImage.mainTexture.height / containerSizeDelta.y;
            ratio = Math.Max(containerSizeDelta.x, containerSizeDelta.y);
            rawImage.rectTransform.sizeDelta = new Vector2(
                rawImage.mainTexture.width * imageAttributes.scale.x / ratio ,
                rawImage.mainTexture.height* imageAttributes.scale.y / ratio );
        }
        rawImage.gameObject.SetActive(true);
    }
    
    
    
    
    
    
}
