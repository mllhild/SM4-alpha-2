using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM4House : MonoBehaviour
{
    public List<SM4HouseFloor> floors = new List<SM4HouseFloor>();
    public int numberOfFloors = 0;
    public string houseName = "houseName";
    public SM4HouseFloor currentfloor;
    public SM4HouseRoom currentRoom;

    private void Start()
    {
        houseName = gameObject.name;
        //SetStartingRoom("dinner");

    }
    

    public void SetStartingRoom(string roomName)
    {
        foreach (var floor in floors)
            foreach (var room in floor.rooms)
                if (room.roomName == roomName)
                    ShowFloor(floor.floorName, room.roomName);
    } 

    public void HideAllFloors()
    {
        foreach (var floor in floors)
            floor.gameObject.SetActive(false);
    }

    public void ShowFloor(string floorName,string entrance)
    {
        HideAllFloors();
        foreach (var floor in floors)
            if (floor.floorName == floorName)
                floor.EnterFloor(entrance);
    }
}
