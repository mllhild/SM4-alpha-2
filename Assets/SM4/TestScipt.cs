using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestScipt : MonoBehaviour
{
    private void Start()
    {
        

    }
    
    
    
    


    public void TestEventParsing()
    {
        var slave = LinqLoader.instance.GetSlaveContainer(
            FindObjectOfType<SlaveFilesController>().listOfSlaves,
            "Lolinew");
        if (slave == null)
            return;
        var eventList = LinqLoader.instance.GetEventList(slave, "Midday");
        if (eventList == null)
            return;
        var validEvents = LinqLoader.instance.GetAllValidEvents(eventList);
        if (validEvents == null)
            return;
        LinqLoader.instance.ReadEventList(validEvents);
    }


    public void AddTextToTextfield()
    {
        var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
        SM4UIMainTextfield.instance.AddText(text);
    }


    
}
