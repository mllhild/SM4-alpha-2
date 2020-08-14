using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SM4MapImageLoader : MonoBehaviour
{
    public static SM4MapImageLoader instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            ErrorLogger.LogErrorInFile("Error in SM4MapImageLoader");
            Destroy(gameObject);   
        }
    }
    
    public void LoadMapImage(string path, Image image)
    {
        StartCoroutine(LoadImageUnityWebRequestv2Coroutine(path, image));
    }
    IEnumerator LoadImageUnityWebRequestv2Coroutine(string path, Image image) 
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(@path);
        yield return request.SendWebRequest();
        
        if (request.isNetworkError || request.isHttpError)
        {
            ErrorLogger.LogErrorInFile(request.error);
        }
        else
        {
            var texture2D = ((DownloadHandlerTexture) request.downloadHandler).texture as Texture2D;
            image.sprite = Sprite.Create(
                texture2D,
                new Rect(new Vector2(0,0),new Vector2(texture2D.width,texture2D.height)),
                Vector2.zero
            );
            image.SetNativeSize();
            image.rectTransform.pivot = Vector2.zero;
            image.rectTransform.anchorMax = Vector2.zero;
            image.rectTransform.anchorMin = Vector2.zero;
        }
    }
}
