using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SM4NewGame : MonoBehaviour
{
    public Image overlay;
    public SM4CharacterPortrait portrait;
    public SM4PrefabButtonSimple01 buttonSimple;
    void Start()
    {
        
        SM4SlaveMakerControler.instance.AutoSaveLoad();
        SM4SlaveMakerControler.instance.slaveMaker.nameChar.first = "firstName";
        SM4SlaveMakerControler.instance.slaveMaker.nameChar.last = "lastName";
        SM4SlaveMakerControler.instance.slaveMaker.nameChar.middle = "middle";
        SM4SlaveMakerControler.instance.slaveMaker.nameChar.nickname = "nickName";
        SM4SlaveMakerControler.instance.slaveMaker.nameChar.prefix = "Prefix";
        SM4SlaveMakerControler.instance.slaveMaker.nameChar.title = "title";
        SM4SlaveMakerControler.instance.slaveMaker.nameChar.nameBorn = "nameBorn";
        SM4SlaveMakerControler.instance.slaveMaker.nameChar.slavename = "slaveName";
        SM4SlaveMakerControler.instance.AutoSaveSave();
        
        Debug.Log(SM4SlaveMakerControler.instance.slaveMaker.stats.agility.max.ToString());
        StartATestGamePart1();


    }

    public void StartATestGamePart1()
    {
        UIElementsMap.instance.LoadMapsFromXml();
        // start the world
        World.instance.BigBang(117822000 + 60);
        
        // Load Eventfiles
        FindObjectOfType<SM4XMLintoGame>().GetXMLEventFiles("Events");
        // Load HouseEvents
        FindObjectOfType<SM4XMLintoGame>().GetXMLEventFiles("World/Mioya/Mardukane/Houses");
        
        SM4EventListsContainer.instance.MergeLists();
        
        UIControler.instance.ShowMap();
        //UIControler.instance.HideAllUi();
        
        foreach (var region in SM4EventListsContainer.instance.regions)
            foreach (var area in region.areas)
                foreach (var location in area.locations)
                {
                    /*if (location.eventList.eventList.Count > 0)
                    {
                        Debug.Log(location.locationName + "  " + location.eventList.eventList.Count.ToString());
                        if(location.locationName=="Keep")
                            foreach (var sm4Event in location.eventList.eventList)
                                Debug.Log(sm4Event.eventName);
                    }*/
                    
                    
                    foreach (var map in UIElementsMap.instance.maps)
                    {
                        //Debug.Log(map.houses.Count.ToString());
                        //Debug.Log(map.locations.Count.ToString());
                        //if (map.houses.Count > 0 || map.locations.Count > 0)
                        //    Debug.Log(location.locationName);

                        foreach (var houseOnMap in map.houses)
                        {
                            Debug.Log(location.locationName + "  " + houseOnMap.locationName);
                            if (houseOnMap.locationName == location.locationName)
                                houseOnMap.locationEvents = location.eventList;
                        }

                        foreach (var locationOnMap in map.locations)
                            if (locationOnMap.locationName == location.locationName)
                                locationOnMap.locationEvents = location.eventList;
                    }
                }
        
        
        StartATestGamePart2();
    }

    public void StartATestGamePart2()
    {
        
        UIControler.instance.HideAllUi();
        UIControler.instance.ShowUiHouse();
       
        SM4SlaveMakerControler.instance.slaveMaker.nameChar.first = "Kuro";
        SM4SlaveMakerControler.instance.slaveMaker.nameChar.middle = "von";
        SM4SlaveMakerControler.instance.slaveMaker.nameChar.last = "Einzbern";
        SM4SlaveMakerControler.instance.slaveMaker.skills.leadership.current = 1;
        SM4SlaveMakerControler.instance.slaveMaker.stats.dominance.current = 50;
        SM4SlaveMakerControler.instance.slaveMaker.locationCurrent = "house";
        SM4SlaveMakerControler.instance.slaveMaker.locationLast = "home";
        SM4SlaveMakerControler.instance.slaveMaker.stats.libido.current = 25.3f;
        
        World.instance.UpdateDate();
        UIElementsGeneral.instance.buttonNext.SetActive(true);
        UIElementsGeneral.instance.buttonPlanning.SetActive(false);
        var events = SM4FindEvent.instance.FindValidEventByLocation("Mioya", "Mardukane", "TestEvents");
        foreach (var sm4Event in events)
        {
            if (sm4Event.eventName == "Test01")
                SM4NextEventButton.instance.sm4Event = sm4Event;

        }
         
        
        SM4UIMainTextfield.instance.AddText("Welcome to SlaveMaker 4 Testing!");
        
        var imageBG = new ImageAttributes();
        imageBG.path = Path.Combine(Application.streamingAssetsPath, @"Events\mllhildEvents\Images");
        imageBG.path = Path.Combine(imageBG.path, "testBG (2).jpg");
        imageBG.fit = true;
        //imageBG.scale = new Vector2(2,1);
        SM4ImageLoader.instance.InstanciateRawImage(imageBG);
        
        
        var image = new ImageAttributes();
        image.path = Path.Combine(Application.streamingAssetsPath, @"Events\mllhildEvents\Images");
        image.path = Path.Combine(image.path, "testImage (14).png");
        image.fit = true;
        image.position = new Vector2(0,-100);
        SM4ImageLoader.instance.InstanciateRawImage(image);
        
        
        
        
        
        
        
        
            

        StartATestGamePart3();
    }

    public void StartATestGamePart3()
    {
        // Load Slaves
        StartATestGamePart4();
    }
    
    public void StartATestGamePart4()
    {
        
        
        /*
        foreach (var region in SM4EventListsContainer.instance.regions)
        {
            Debug.Log(region.regionName);
            foreach (var area in region.areas)
            {
                Debug.Log(area.areaName);
                foreach (var location in area.locations)
                {
                    Debug.Log(location.locationName);
                    foreach (var sm4Event in location.eventList.eventList)
                    {
                        Debug.Log(sm4Event.eventName);
                    }
                }
            }
        }
        
        Debug.Log("---------------------------------");

        Debug.Log(SM4FindEvent.instance.FindEventByName("NoLolsGiven").eventName);
        SM4EventExecute.instance.ExecuteEvent(SM4FindEvent.instance.FindEventByName("NoLolsGiven"));
        */
        
        
        
        
        
        
        StartATestGamePart5();
    }

    public void StartATestGamePart5()
    {
        
        
        //World.instance.Turn();
        
        
    }
}
