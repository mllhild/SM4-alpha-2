using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM4EventListsContainer : MonoBehaviour
{
    public static SM4EventListsContainer instance = null;
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
    
    public List<SM4Region> regions = new List<SM4Region>();
    
    // need to merge the resulting multiple from several files? 
    public void MergeLists()
    {
        regions.Sort((SM4Region x, SM4Region y)=> 
            {return String.Compare(x.regionName, y.regionName, StringComparison.Ordinal);});

        int imax = regions.Count;
        for (int i = 1; i < imax; i++)
        {
            if (regions[i].regionName == regions[i - 1].regionName)
            {
                regions[i-1].areas.AddRange(regions[i].areas);
                regions[i].areas.Clear();
                regions.Remove(regions[i]);
                i--;
                imax--;
            }
        }

        foreach (var region in regions)
        {
            region.areas.Sort((SM4Area x, SM4Area y)=> 
                {return String.Compare(x.areaName, y.areaName, StringComparison.Ordinal);});
            imax = region.areas.Count;
            for (int i = 1; i < imax; i++)
            {
                if (region.areas[i].areaName == region.areas[i - 1].areaName)
                {
                    region.areas[i-1].locations.AddRange(region.areas[i].locations);
                    region.areas[i].locations.Clear();
                    region.areas.Remove(region.areas[i]);
                    i--;
                    imax--;
                }
            }

            foreach (var area in region.areas)
            {
                area.locations.Sort((SM4Location x, SM4Location y)=> 
                    {return String.Compare(x.locationName, y.locationName, StringComparison.Ordinal);});
                imax = area.locations.Count;
                for (int i = 1; i < imax; i++)
                {
                    if (area.locations[i].locationName == area.locations[i - 1].locationName)
                    {
                        area.locations[i-1].eventList.eventList.AddRange(area.locations[i].eventList.eventList);
                        area.locations[i].eventList.eventList.Clear();
                        area.locations.Remove(area.locations[i]);
                        i--;
                        imax--;
                    }
                }
            }
        }
        
    }
}

public class SM4Region // Ex: 
{
    public string regionName = "error";
    public List<SM4Area> areas = new List<SM4Area>();
}
public class SM4Area // Ex: Mardukane
{
    public string areaName = "error";
    public List<SM4Location> locations = new List<SM4Location>();
}
public class SM4Location // Ex: Palace
{
    public string locationName = "error";
    public SM4EventList eventList = new SM4EventList();
}
