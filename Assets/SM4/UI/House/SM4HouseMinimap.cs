using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM4HouseMinimap : MonoBehaviour
{
    
    List<SM4HouseMinimapInteractable> areas = new List<SM4HouseMinimapInteractable>();
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLocation(SM4HouseMinimapInteractable sm4HouseMinimapInteractable)
    {
        areas.Add(sm4HouseMinimapInteractable);
    }
}
