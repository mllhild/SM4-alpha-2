using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    public void FindEvents(int eventNumber)
    {
        World.instance.hour = World.instance.turn / 10;
        World.instance.didAEvent = false;
        if (eventNumber != 0) // we know what a event is to be done, so this goes somewhere else
        {
            if (eventNumber > 0)
            {
                DoEspecificEvent(eventNumber);
                return;
            }
                
        }

        int stop = World.instance.turn % 10; // to reduce load since I dont really need it at the moment, maybe later I find a use
        if (stop != 0)
        {
            World.instance.Turn();
            return;
        }
        //if(World.instance.thing == 0)
        //{
        //    Debug.LogFormat("Turn {0}, by thing {1}, eventnumber {2}", World.instance.turn, World.instance.thing ,eventNumber);
        //}
        
        World.instance.hour = World.instance.turn / 10;
        //World.instance.gameUI.UpdateClock(World.instance.turn);
        World.instance.didAEvent = false;



        // maybe it can be indexed with the ID as part of the location path
        // then we dont event need the switchs

        // very inefficient seachr for events in the time slot
        if (World.instance.turn == 240)
        {
            Debug.Log("its turn 240");
            World.instance.thing = 0; //start next event check as slave
            World.instance.NewDay();
            if (World.instance.didAEvent) { return; }
        }
        
        
        if (World.instance.turn >= 60 && World.instance.turn <= 79)
        {
            Debug.Log("Its morning, press next to continue");
            World.instance.didAEvent = true;
            UIControler.instance.ShowUiHouse();
            UIElementsGeneral.instance.utilityDisplays.gameObject.SetActive(true);
            UIElementsGeneral.instance.uiCharacters.gameObject.SetActive(true);
            UIElementsGeneral.instance.mainImageField.SetActive(true);
            UIElementsGeneral.instance.buttonNext.SetActive(true);
            
            
            World.instance.thing = 0; //start next event check as slave
            World.instance.turn++; World.instance.time++; // only needs to be checked once each day
            if (World.instance.didAEvent) { return; }
        }
        /*
        if (World.instance.didMorningPlanning == false && World.instance.turn >= 80)
        {
            World.instance.thing = 0; //start next event check as slave
            World.instance.turn++; World.instance.time++; // only needs to be checked once each day
            if (World.instance.didAEvent) { return; }
        }
        if (World.instance.turn >= 120 && World.instance.turn <= 139)
        {
            World.instance.thing = 0; //start next event check as slave
            World.instance.turn++; World.instance.time++; // only needs to be checked once each day
            if (World.instance.didAEvent) { return; }
        }
        if (World.instance.turn >= 180 && World.instance.turn <= 199)
        {
            World.instance.thing = 0; //start next event check as slave
            World.instance.turn++; World.instance.time++; // only needs to be checked once each day
            if (World.instance.didAEvent) { return; }
        }
        */
        
        // No night planning done yet
        //if (World.instance.didEveningPlanning == false && World.instance.turn >= 180)
        //{
        //    eventsHouse.Events();
        //    World.instance.thing = 0; //start next event check as slave
        //    World.instance.turn++; World.instance.time++; // only needs to be checked once each day
        //    if (World.instance.didAEvent) { return; }
        //}
        
        /*

        if (World.instance.didGoSleep == false && World.instance.turn >= 230)
        {
            World.instance.thing = 0; //start next event check as slave
            World.instance.turn++; World.instance.time++; // only needs to be checked once each day
            if (World.instance.didAEvent) { return; }
        }
        */

        //if (World.instance.turn == 80 || World.instance.turn == 180)
        //{
        //    eventsTown.Events();
        //    World.instance.thing = 0; //start next event check as slave
        //    World.instance.turn++; World.instance.time++; // only needs to be checked once each day
        //    if (World.instance.didAEvent) { return; }
        //}

        // empty
        if (eventNumber == 0)
        {
            World.instance.Turn();
            return;
        }
        // previous field occupied due to planning
        if (eventNumber < 0)
        {
            World.instance.Turn();
            return;
        }


    }




    public void DoEspecificEvent(int eventNumber)
    {
        World.instance.hour = World.instance.turn / 10;
        World.instance.didAEvent = false;

        //for specific event numbers

        int id = eventNumber / 10000;  // eventnumber  = id*10000 + index  234.000 + 452 = 234.452
        int index = eventNumber % 10000;

        if (id == 0 && index < 1000)
        {
            //eventsPlanningActs.Events(eventNumber);
            if (World.instance.didAEvent) { return; }
        }

        // maybe it can be indexed with the ID as part of the location path
        // then we dont event need the switchs

        if (id < 100)// check if its a location ID
        {
            switch (id)
            {
                case 1: // town
                    break;
                case 2: // beach
                    break;
                case 3: // slums
                    break;
                case 4: // farm
                    break;
                case 5: // forest
                    break;
                case 6: // palast
                    break;
                case 7: // slave market
                    break;
                case 8: // docks
                    break;
                case 9: // mountain
                    break;
            }
            return;
        }


        if (id >= 1000 && id < 2000) // check the game files (questlines, houses, npcs )
        {
            switch (id)
            {
                case 1000: // test
                    //testEvents.Events(index);
                    break;
                case 1001: // SMEncounter
                    break;
                case 1002: // BEN...
                    break;
                case 1003: // ....
                    break;
                case 1004: // 
                    break;
                case 1005: // 
                    break;
                case 1006: // 
                    break;
                case 1007: //  
                    break;
                case 1008: // 
                    break;
                case 1009: // 
                    break;
            }
            return;
        }


        if (id >= 2000 && id < 3000) // check the slaves
        {
            switch (id)
            {
                case 2001: // slave 1
                    break;
                case 2002: // slave 2
                    break;
                case 2003: // ....
                    break;
                case 2004: // 
                    break;
                case 2005: // 
                    break;
                case 2006: // 
                    break;
                case 2007: //  
                    break;
                case 2008: // 
                    break;
                case 2009: // 
                    break;
            }
            return;
        }


        // for lost cases to continue the code
        // empty
        Debug.LogFormat("DoEspecificEvent was called with EventNumber = {0} , but no related event could be found",eventNumber);
        World.instance.Turn();
        return;


    }









}
