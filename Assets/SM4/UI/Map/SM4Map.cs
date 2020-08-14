using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class SM4Map : MonoBehaviour
{
    public string mapName;
    public string path;
    public List<SM4MapLocation> locations = new List<SM4MapLocation>();
    public List<SM4MapLocation> houses = new List<SM4MapLocation>();
    public Image background;


    private void Start()
    {
        
    }

    public void SendReferenceToUIElementsMap()
    {
        UIElementsMap.instance.maps.Add(this);
    }

    public void AddSM4MapBackground()
    {
        background = this.gameObject.AddComponent<Image>();
        background.raycastTarget = true;
        background.preserveAspect = true;
        background.useSpriteMesh = false;
        background.type = Image.Type.Simple;
        //background.sprite = Resources.Load<Sprite>("mllhild/Kuro/01");
        var pathImage = path + "/Map/Image.jpg";
        Debug.Log(pathImage);
        SM4MapImageLoader.instance.LoadMapImage(pathImage, background);
        
        
    }

    public void AddSM4MapLocation(SM4MapLocation sm4MapLocation)
    {
        var newGO = new GameObject();
        var locationGameObject = Instantiate(newGO, transform);
        Destroy(newGO);
        var location = locationGameObject.AddComponent<SM4MapLocation>();
        var image = locationGameObject.AddComponent<Image>();
        locationGameObject.AddComponent<Button>();
        locationGameObject.AddComponent<SM4MapInteractable>();

        location.locationVisible = sm4MapLocation.locationVisible;
        location.locationDisplayName = sm4MapLocation.locationDisplayName;
        location.locationName = sm4MapLocation.locationName;
        location.path = sm4MapLocation.path;
        location.keyshortcut = sm4MapLocation.keyshortcut;
        location.locationPosition = sm4MapLocation.locationPosition;
        location.typeOfLocation = sm4MapLocation.typeOfLocation;
        
        location.locationName = sm4MapLocation.locationName;
        location.path = sm4MapLocation.path;
        location.CreateLocation();

        locationGameObject.name = location.locationName;
        locations.Add(location);
    }
}
