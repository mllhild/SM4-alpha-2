using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SM4HouseDoor : MonoBehaviour
{
    public string doorName = "roomName";
    public string doorRoom1 = "roomName";
    public string doorRoom2 = "roomName";
    public bool locked = false;
    public RectTransform rectTransform;
    public Image image;
    public SM4HouseFloor floor;

    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        image = gameObject.GetComponent<Image>();
        //image.alphaHitTestMinimumThreshold = 0.5f;
        var doorNameParts = gameObject.name.Split(' ');
        doorRoom1  = doorNameParts[2];
        doorRoom2  = doorNameParts[1];
        doorName = doorNameParts[0];
        
        floor = gameObject.GetComponentInParent<SM4HouseFloor>();
        floor.doors.Add(this);
    }

    public void DoorCheck(SM4HouseRoom roomOut,SM4HouseRoom roomInto )
    {
        if(roomOut.ExitThisRoom())
            roomInto.EnterThisRoom();
        // add any checks if desired
    }
}
