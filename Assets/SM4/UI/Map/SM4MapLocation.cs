using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SM4MapLocation : MonoBehaviour
{
    public string path = "error";
    public string locationName = "location";
    public string locationDisplayName = "locationDisplayName";
    public string keyshortcut = "empty";
    public string mapLocationWorld = "mardukane";
    public string mapLocationRegion = "mardukane";
    public string mapLocationArea = "mardukane";

    public RectTransform locationRect;
    public Vector2 locationPosition = Vector2.zero;
    public Vector2 locationScale = Vector2.one;
    public Vector2 locationSizeDelta = Vector2.one;
    public Quaternion locationRotation = new Quaternion(0,0,0,0);
    public bool locationVisible = true;
    public Image locationImage;
    public Button button;
    public TextMeshProUGUI label;
    public TypeOfLocation typeOfLocation = TypeOfLocation.Area;
    
    
    public enum TypeOfLocation
    {
        Area = 1,
        House = 2
    }
    
    // At some point the events should be moved from the EventListContainer to this list for each location
    // Hence making 
    public SM4EventList locationEvents = new SM4EventList();

    private void Awake()
    {
        
    }

    private void Start()
    {
        
        
    }

    public void CreateLocation()
    {
        locationImage = gameObject.GetComponent<Image>();
        locationImage.raycastTarget = true;
        locationImage.preserveAspect = true;
        locationImage.useSpriteMesh = false;
        locationImage.type = Image.Type.Simple;
        locationRect = gameObject.GetComponent<RectTransform>();
        button = gameObject.GetComponent<Button>();
        label = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        //label.text = locationDisplayName;
        
        /*
        switch (typeOfLocation)
        {
            case TypeOfLocation.Area:
                GetComponentInParent<SM4Map>().locations.Add(this);
                
                break;
            case TypeOfLocation.House:
                GetComponentInParent<SM4Map>().houses.Add(this);
                break;
            default:
                Debug.Log("Error in LocationsAssignment");
                break;
            
        }*/
        //Debug.Log("Added this "+gameObject.name);
        SM4MapImageLoader.instance.LoadMapImage(path + "/Image.png", locationImage);
        ApplyConfig();
    }

    public void ApplyConfig()
    {
        //locationRect.anchorMax = Vector2.zero;
        //locationRect.anchorMin = Vector2.zero;
        //locationRect.sizeDelta = locationSizeDelta;
        locationRect.localPosition = locationPosition;
        locationRect.localScale = locationScale*((float)Screen.currentResolution.height/1080);
        
        locationRect.localRotation = locationRotation;
        gameObject.SetActive(locationVisible);
    }
    

    public void HideLocationWithoutDisabling()
    {
        
    }

    public void ShowLocationAgain()
    {
        
    }
    
    
}
