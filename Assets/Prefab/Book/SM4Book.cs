using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SM4Book : MonoBehaviour
{
    public string bookName = "";
    public int currentPage = 0;
    public GameObject pageTemplate;
    public GameObject bookCoverFrontOutside;
    public GameObject bookCoverFrontInside;
    public GameObject bookCoverBackOutside;
    public GameObject bookCoverBackInside;
    public GameObject bookBack;
    
    public List<SM4BookPage> pages = new List<SM4BookPage>();

    public void AddPage(string pathImage)
    {
        var page = new SM4BookPage();
        pages.Add(page);
        page.pageNumber = pages.Count;
        page.pathImage = pathImage;
        page.pageGameObject = Instantiate(pageTemplate, transform);
        var imageAttributes = new ImageAttributes();
        SM4ImageLoader.instance.UWBeasy(imageAttributes, page.rawImage);
    }

    public void RemovePage(string pathImage)
    {
        foreach (var page in pages)
        {
            if (page.pathImage == pathImage)
            {
                Destroy(page.rawImage.texture);
                Destroy(page.pageGameObject);
                pages.Remove(page);
            }
        }
    }

    public void RemoveBook()
    {
        foreach (var page in pages)
        {
            Destroy(page.rawImage.texture);
            Destroy(page.pageGameObject);
        }
        pages.Clear();
    }

    public void ShowBook()
    {
        
    }

    public void HideBook()
    {
        
    }

}

public class SM4BookPage
{
    public GameObject pageGameObject;
    public string pathImage;
    public RawImage rawImage;
    public int pageNumber = 0;
}

