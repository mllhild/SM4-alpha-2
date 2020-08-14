using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM4FindEvent : MonoBehaviour
{
    public static SM4FindEvent instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            ErrorLogger.LogErrorInFile("Error in " + this.name);
            Destroy(gameObject);   
        }
    }

    public void FindEventByNameViaCouroutine(string eventName, SM4Event sm4Event)
    {
        StartCoroutine(FindEventByNameCouroutine(eventName, sm4Event));
    }

    IEnumerator FindEventByNameCouroutine(string eventName, SM4Event sm4Event)
    {
        foreach (var region in SM4EventListsContainer.instance.regions)
            foreach (var area in region.areas)
                foreach (var location in area.locations)
                    foreach (var eventInList in location.eventList.eventList)
                        if (eventInList.eventName == eventName)
                            yield return eventInList;
                            
        yield return null;
    }

    public SM4Event FindEventByName(string eventName)
    {
        foreach (var region in SM4EventListsContainer.instance.regions)
            foreach (var area in region.areas)
                foreach (var location in area.locations)
                    foreach (var eventInList in location.eventList.eventList)
                        if (eventInList.eventName == eventName)
                            return eventInList;
                            
        return null;
    }
    public SM4Event FindEventByName(string regionName, string areaName, string locationName, string eventName)
    {
        return  FindEventInLocation(eventName, 
                    FindLocationInArea(locationName,
                    FindAreaInRegion(areaName,
                    FindRegionInWolrd(regionName))));
    }
    public List<SM4Event> FindValidEventByLocation(string regionName, string areaName, string locationName)
    {
        return  FindValidEventsInLocation( 
                    FindLocationInArea(locationName,
                    FindAreaInRegion(areaName,
                    FindRegionInWolrd(regionName))));
    }
    
    
    public SM4Region FindRegionInWolrd(string regionName)
    {
        foreach (var region in SM4EventListsContainer.instance.regions)
            if (region.regionName == regionName)
                return region;
        return null;
    }
    public SM4Area FindAreaInRegion(string areaName, SM4Region region)
    {
        foreach (var area in region.areas)
            if (area.areaName == areaName)
                return area;
        return null;
    }
    public SM4Location FindLocationInArea(string locationName, SM4Area area)
    {
        foreach (var location in area.locations)
            if (location.locationName == locationName)
                return location;
        return null;
    }
    public SM4Event FindEventInLocation(string eventName, SM4Location location)
    {
        foreach (var sm4Event in location.eventList.eventList)
            if (sm4Event.eventName == eventName)
                return sm4Event;
        return null;
    }
    public SM4Event FindEventInList(string eventName, List<SM4Event> eventList)
    {
        foreach (var sm4Event in eventList)
            if (sm4Event.eventName == eventName)
                return sm4Event;
        return null;
    }
    
    public List<SM4Event> FindValidEventsInLocation(SM4Location location)
    {
        return FindValidEventsInList(location.eventList.eventList);
    }
    
    public List<SM4Event> FindValidEventsInList(List<SM4Event> eventList)
    {
        List<SM4Event> validEvents = new List<SM4Event>();
        foreach (var sm4Event in eventList)
            if (SM4CheckIfEventValid.instance.CheckIfEventValid(sm4Event))
                validEvents.Add(sm4Event);
        return validEvents;
    }

    
    
    
}
