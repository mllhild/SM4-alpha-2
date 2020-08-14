using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SM4MapHouse : MonoBehaviour
{
    public string houseName = "house";
    public string houseDisplayName = "houseDisplayName";
    public string houseLocation = "mardukane";
    public RectTransform houseRect = new RectTransform();
    public Vector2 housePosition = Vector2.zero;
    public Vector2 houseScale = Vector2.one;
    public Vector2 houseSizeDelta = Vector2.one;
    public Vector3 houseRotation = Vector3.zero;
    public bool houseVisible = true;
    public int houseMapImageIndex = 0;
    public Sprite[] houseMapImage = new Sprite[10];
    public Image standardBackground;

    public float upkeep = 0;
    public int capacityCurrent = 5;
    public int capacityMax = 5;
    public bool isOwned = false;
    public bool isRented = false;
    public bool canBuy = false;
    public float priceBuy;

    public bool craftingExpansionPossible = false;
    public bool combatTrainingPossible = false;
    
    
    public SM4EventList houseEvents = new SM4EventList();

    private void Start()
    {
        //GetComponentInParent<SM4Map>().houses.Add(this);
    }
}
