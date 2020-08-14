using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SM4HouseFloor : MonoBehaviour
{
    public List<SM4HouseRoom> rooms = new List<SM4HouseRoom>();
    public List<SM4HouseStairs> stairs = new List<SM4HouseStairs>();
    public List<SM4HouseDoor> doors = new List<SM4HouseDoor>();
    public int floorNumber = 0;
    public string floorName = "floorName";
    
    public RectTransform rectTransform;
    public Image image;
    public Outline outline;
    public SM4House house;
    
    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        image = gameObject.GetComponent<Image>();
        outline = gameObject.GetComponent<Outline>();
        floorName = gameObject.name;
        house = gameObject.GetComponentInParent<SM4House>();
        house.floors.Add(this);
    }

    public void EnterFloor(string entranceName)
    {
        foreach (var stair in stairs)
            if(stair.stairsName == entranceName)
                foreach (var room in rooms)
                    if(stair.adjacentRoomName == room.roomName)
                    {
                        room.EnterThisRoom();
                        return;
                    }

        foreach (var room in rooms)
            if(entranceName == room.roomName)
                room.EnterThisRoom();
        
            
    }
}
