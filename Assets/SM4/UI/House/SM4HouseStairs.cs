using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SM4HouseStairs : MonoBehaviour
{
    public string stairsName = "stairsName";
    public RectTransform rectTransform;
    public Image image;
    public Button button;
    public string destinationFloorName = "floor";
    public string destinationStairName = "floor";
    public SM4HouseFloor floor;
    public SM4House house;
    public string adjacentRoomName = "room";

    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        image = gameObject.GetComponent<Image>();
        //image.alphaHitTestMinimumThreshold = 0.5f;
        var stairsNameParts = gameObject.name.Split(' ');
        destinationFloorName  = stairsNameParts[2];
        adjacentRoomName  = stairsNameParts[1];
        stairsName = stairsNameParts[0];
        button = gameObject.GetComponent<Button>();
        floor = gameObject.GetComponentInParent<SM4HouseFloor>();
        floor.stairs.Add(this);
        //house = floor.house;
        house = GetComponentInParent<SM4House>();
        button.onClick.AddListener(UseStairs);
    }
    

    public void UseStairs()
    {
        if(house.currentRoom.roomName == adjacentRoomName)
            house.ShowFloor(destinationFloorName,destinationStairName);
    }
    
}
