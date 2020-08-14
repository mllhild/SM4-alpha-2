using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using UnityEngine;

public class SM4XMLintoGame : MonoBehaviour
{
    
    public void GetXMLEventFiles(string parentFolder)
    {
        string pathEvents;
        pathEvents = Path.Combine(Application.streamingAssetsPath, parentFolder);
        Debug.Log(pathEvents);
        string[] eventDirectories = Directory.GetDirectories(pathEvents);
        foreach (var eventDirectory in eventDirectories)
        {
            SM4EventListsContainer.instance.regions.AddRange(LoadEventsIntoEventList(Path.Combine(eventDirectory, "Events.xml")));
        }
        //Debug.Log("Event Directories " + eventDirectories.Length.ToString() + " in " + parentFolder);
    }
    
    

    public List<SM4Region> LoadEventsIntoEventList(string eventXmlFilePath)
    {
        XDocument doc;
        try
        { doc = XDocument.Load(eventXmlFilePath); }
        catch
        { doc = null; }
        XElement xElement = null;
        try
        { xElement = doc.Descendants("Region").First();  }
        catch
        { xElement = null; }

        if (xElement == null)
        {
            ErrorLogger.LogErrorInFile("In " + this.name + "Region was null");
            return new List<SM4Region>();
        }
            
        List<SM4Region> regions = new List<SM4Region>();

        foreach (var xRegion in xElement.Elements())
        {
            if (xRegion.NodeType != XmlNodeType.Comment)
            {
                var region = new SM4Region();
                region.regionName = xRegion.Name.ToString();
                regions.Add(region);
                //Debug.Log("Region: " + region.regionName);
            }
        }

        

        foreach (var region in regions)
        {

            XElement xAreas = null;
            try
            { xAreas = doc.Descendants(region.regionName).First();  }
            catch
            { xAreas = null; }
            
            foreach (var xArea in xAreas.Elements())
            {
                if (xArea.NodeType != XmlNodeType.Comment)
                {
                    SM4Area area = new SM4Area();
                    area.areaName = xArea.Name.LocalName;
                    region.areas.Add(area);
                    //Debug.Log("Area: " + area.areaName);
                }
            }
            
            foreach (var area in region.areas)
            {
                XElement xLocations = null;
                try
                { xLocations = doc.Descendants(area.areaName).First(); }
                catch
                { xLocations = null; }

                
                foreach (var xLocation in xLocations.Elements())
                {
                    if (xLocation.NodeType != XmlNodeType.Comment)
                    {
                        SM4Location location = new SM4Location();
                        location.locationName = xLocation.Name.LocalName;
                        location.eventList.listName = location.locationName;
                        area.locations.Add(location);
                    }
                }

                foreach (var location in area.locations)
                {
                    
                    try
                    {
                        XElement xLocationSubArea = doc.Descendants(location.locationName).First();
                        XElement xLocationSubtree = XElement.Load(xLocationSubArea.CreateNavigator().ReadSubtree());
                        XElement xEvents = xLocationSubtree.Descendants("Events").First();
                        foreach (var xEvent in xEvents.Elements())
                        {
                            if (xEvent.NodeType != XmlNodeType.Comment)
                            {
                                SM4Event sm4Event = new SM4Event();
                                sm4Event.xElement = xEvent;
                                foreach (var xAttribute in xEvent.Attributes())
                                {
                                    sm4Event.attributes.Add(
                                        new KeyValuePair<string, string>
                                            (xAttribute.Name.ToString(), xAttribute.Value.ToString())
                                    );
                                }
                                sm4Event.eventName = xEvent.Name.LocalName;
                            
                                location.eventList.eventList.Add(sm4Event);
                                //Debug.Log(sm4Event.eventName);
                            }
                        }
                    }
                    catch
                    {
                                                
                    }
                }
            }
        }

        return regions;
    }
}
