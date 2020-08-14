using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SM4HouseMinimapInteractable : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public string areaName = "";

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Enter " + this.gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Exit " + this.gameObject.name);
    }

    private void Start()
    {
        //gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
        areaName = gameObject.name;
        gameObject.GetComponentInParent<SM4HouseMinimap>().AddLocation(this);
        
    }
    

    public void PrintName()
    {
        Debug.Log(this.gameObject.name);
    }

    public string ReturnMapElementName()
    {
        return this.gameObject.name;
    }

    public void SetSlaveMakerLocation()
    {
        SM4SlaveMakerControler.instance.slaveMaker.UpdateLocation(this.gameObject.name);
    }
}
