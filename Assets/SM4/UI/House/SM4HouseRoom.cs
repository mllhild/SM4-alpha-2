using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SM4HouseRoom : MonoBehaviour
{
    public string roomName = "roomName";
    public string roomNumber = "";
    public RectTransform rectTransform;
    public Image image;
    public Button button;
    public TextMeshProUGUI label;
    public SM4HouseFloor floor;
    public SM4House house;
    public bool visited = false;
    

    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        image = gameObject.GetComponent<Image>();
        
        //image.alphaHitTestMinimumThreshold = 0.5f;
        label = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        var roomNameParts = gameObject.name.Split(' ');
        roomName = roomNameParts[0];
        //label.text = roomNameParts[1];
        
        button = gameObject.GetComponent<Button>();
        floor = gameObject.GetComponentInParent<SM4HouseFloor>();
        floor.rooms.Add(this);
        
        //house = floor.house;
        house = GetComponentInParent<SM4House>();
        button.onClick.AddListener(TryToEnterRoom);
    }

    public void TryToEnterRoom()
    {
        SM4HouseDoor door = DoesDoorExist();
        if (door == null)
            Debug.Log("No door between "+house.currentRoom.roomName+" and "+roomName);
        else if (door.locked)
            Debug.Log("Door is locked");
        else
            door.DoorCheck(house.currentRoom,this);           
    }

    public void EnterThisRoom()
    {
        image.color = Color.green;
        house.currentRoom = this;
        house.currentfloor = floor;
        floor.gameObject.SetActive(true);
        visited = true;
    }

    public bool ExitThisRoom()
    {
        image.color = new Color(111,97,73);
        // return false to pervent leaving the room
        return true;
    }
    

    public SM4HouseDoor DoesDoorExist()
    {
        foreach (var door in floor.doors)
            if(roomName == door.doorRoom1 || roomName == door.doorRoom2)
                if (house.currentRoom.roomName == door.doorRoom1 || house.currentRoom.roomName == door.doorRoom2)
                    return door;
        return null;
    }
}
