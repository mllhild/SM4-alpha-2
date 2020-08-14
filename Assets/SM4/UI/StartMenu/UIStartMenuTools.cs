using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIStartMenuTools : MonoBehaviour
{
    public static UIStartMenuTools instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            ErrorLogger.LogErrorInFile("Error in UIStartMenuTools " + this.name);
            Destroy(gameObject);   
        }
    }

    public void AddButtonToScreen(
        GameObject bReference, 
        GameObject bParent,
        Vector2 position,
        Vector2 sizeDelta,
        string label
        )
    {
        bReference = Instantiate(new GameObject(), bParent.transform);
        bReference.AddComponent<Button>();
        bReference.AddComponent<RectTransform>();
        bReference.AddComponent<Image>();
        bReference.GetComponent<RectTransform>().sizeDelta = sizeDelta;
        bReference.GetComponent<RectTransform>().localPosition = position;
        var textfield = Instantiate(gameObject, bReference.transform);
        textfield.AddComponent<TextMeshProUGUI>();
        textfield.GetComponent<TextMeshProUGUI>().text = label;

    }
    
    
    public void LoadImageUnityWebRequestv2(string path, RawImage rawImage)
    {
        
        ImageAttributes imageAttributes = new ImageAttributes();
        imageAttributes.path = path;
        StartCoroutine(LoadImageUnityWebRequestv2Coroutine(imageAttributes, rawImage));
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
            
            var imageContainerSizeDelta = rawImage.GetComponentInParent<RectTransform>().sizeDelta;
            imageContainerSizeDelta.x = rawImage.mainTexture.width / imageContainerSizeDelta.x;
            imageContainerSizeDelta.y = rawImage.mainTexture.height / imageContainerSizeDelta.y;
            
            var largerRatio = imageContainerSizeDelta.x;
            if (imageContainerSizeDelta.x < imageContainerSizeDelta.y)
                largerRatio = imageContainerSizeDelta.y;

            rawImage.rectTransform.sizeDelta = new Vector2(
                rawImage.mainTexture.width * imageAttributes.scale.x / largerRatio ,
                rawImage.mainTexture.height* imageAttributes.scale.y / largerRatio
            );

            rawImage.rectTransform.localPosition = imageAttributes.position;
            
            if(imageAttributes.rotation != new Vector3(0,0,0 ))
                rawImage.rectTransform.Rotate(imageAttributes.rotation);

            if (imageAttributes.color != new Color(1, 1, 1, 1))
                rawImage.color = imageAttributes.color;
                
            
            rawImage.gameObject.SetActive(true);
            
        }
    }
    
    
}
