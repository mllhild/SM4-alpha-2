using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SM4MapInteractable : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
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
        // All are valid  :D
        
        //this.gameObject.GetComponent<Button>().onClick.AddListener(SetSlaveMakerLocation);
        //this.gameObject.GetComponent<Button>().onClick.AddListener(() => ReturnMapElementName());
        //this.gameObject.GetComponent<Button>().onClick.AddListener(delegate { ReturnMapElementName(); });
        //this.gameObject.GetComponent<Button>().onClick.AddListener(delegate { SM4SlaveMakerControler.instance.slaveMaker.UpdateLocation(this.gameObject.name); });
        //this.gameObject.GetComponent<Button>().onClick.AddListener(() => SM4SlaveMakerControler.instance.slaveMaker.UpdateLocation(this.gameObject.name) );
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => TakeAWalk());
        this.gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
        
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

    public void TakeAWalk()
    {
        string location = this.gameObject.name;
        location = location.Replace(" ", "");
        Debug.Log(location);
        //var sm4Events = SM4FindEvent.instance.FindValidEventByLocation("Mioya", "Mardukane", location);
        var sm4Events =
            SM4FindEvent.instance.FindValidEventsInList
                (gameObject.GetComponent<SM4MapLocation>().locationEvents.eventList);
        foreach (var VARIABLE in gameObject.GetComponent<SM4MapLocation>().locationEvents.eventList)
        {
            Debug.Log(VARIABLE.eventName);
        }
        if (sm4Events != null && sm4Events.Count > 0)
        {
            SM4EventExecute.instance.ExecuteEvent(sm4Events.First());
            UIControler.instance.ShowUiGeneralEvent();
        }
            
        
    }
    
    
}
