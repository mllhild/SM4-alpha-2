using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.WSA;
using Application = UnityEngine.Application;

public class SM4MapFromXml : MonoBehaviour
{
    public SM4MapWorldMap worldMap;
    public List<SM4Map> listOfMaps = new List<SM4Map>();
    
    private void Start()
    {
        
    }

    public void GetWorld(string parentFolder)
    {
        
        worldMap = new SM4MapWorldMap();
        string pathRegions;
        pathRegions = Path.Combine(Application.streamingAssetsPath, parentFolder);
        string[] regionsDirectories = Directory.GetDirectories(pathRegions);
        foreach (var regionsDirectory in regionsDirectories)
        {
            SM4MapRegionMap region = new SM4MapRegionMap();
            region.objectName = Path.GetFileName(regionsDirectory);
            region.path = regionsDirectory;
            worldMap.regionMaps.Add(GetRegions(regionsDirectory,region));
        }

        foreach (var region in worldMap.regionMaps)
        {
            //Debug.Log("Region: "+region.objectName);
            foreach (var area in region.areaMaps)
            {
                //Debug.Log("  Area: "+area.objectName);
                var newGO = new GameObject();
                var map = Instantiate(newGO, transform);
                Destroy(newGO);
                map.name = area.objectName;
                var mapScript = map.AddComponent<SM4Map>();
                mapScript.SendReferenceToUIElementsMap();
                mapScript.mapName = area.objectName;
                mapScript.path = area.path;
                mapScript.AddSM4MapBackground();
                listOfMaps.Add(mapScript);
                foreach (var areaSubDirectory in area.locationMaps)
                {
                    //Debug.Log("     AreaSubFolders: "+areaSubDirectory.objectName);
                    foreach (var location in areaSubDirectory.locations)
                    {
                        //Debug.Log("        Location: "+location.locationName);
                        mapScript.AddSM4MapLocation(location);
                    }
                }
            }
        }
    }

    private SM4MapRegionMap GetRegions(string regionsDirectory, SM4MapRegionMap region)
    {
        string[] areaDirectories = Directory.GetDirectories(regionsDirectory);
        foreach (var areaDirectory in areaDirectories)
        {
            SM4MapAreaMap area = new SM4MapAreaMap();
            area.objectName = Path.GetFileName(areaDirectory);
            area.path = areaDirectory;
            region.areaMaps.Add(GetAreas(areaDirectory, area));
        }

        return region;
    }

    private SM4MapAreaMap GetAreas(string areaDirectory, SM4MapAreaMap area)
    {
        string[] areaSubDirectories = Directory.GetDirectories(areaDirectory);
        foreach (var areaSubDirectory in areaSubDirectories)
        {
            SM4MapLocationMap areaSub = new SM4MapLocationMap();
            areaSub.objectName = Path.GetFileName(areaSubDirectory);
            areaSub.path = areaSubDirectory;
            if(areaSub.objectName == "Locations")
                GetLocations(areaSubDirectory, areaSub);
            area.locationMaps.Add(areaSub);
        }

        return area;

    }
    private void GetLocations(string locationDirectory, SM4MapLocationMap areaSub)
    {
        string[] locationSubDirectories = Directory.GetDirectories(locationDirectory);
        foreach (var locationSubDirectory in locationSubDirectories)
        {
            areaSub.locations.Add(GetLocationFromXml(locationSubDirectory));
        }
    }

    public SM4MapLocation GetLocationFromXml(string locationSubDirectory)
    {
        SM4MapLocation location = new SM4MapLocation();
        location.locationName = Path.GetFileName(locationSubDirectory);
        location.path = locationSubDirectory;

        var locationXMLPath = locationSubDirectory + "/Location.xml";
        XDocument doc;
        try
        { doc = XDocument.Load(@locationXMLPath); }
        catch
        { doc = null; }
        XElement xElements = null;
        try
        { xElements = doc.Descendants("Location").First();  }
        catch
        { xElements = null; }
        if (xElements == null)
        {
            ErrorLogger.LogErrorInFile("In " + this.name + "Region was null");
            return location;
        }

        try { location.locationDisplayName = xElements.Element("Name").FirstAttribute.Value; }
        catch {  }
        try { location.keyshortcut = xElements.Element("Key").FirstAttribute.Value; }
        catch {  }
        try { if(xElements.Element("Type").FirstAttribute.Value == "area")
                location.typeOfLocation = SM4MapLocation.TypeOfLocation.Area;
            else
                location.typeOfLocation = SM4MapLocation.TypeOfLocation.House; }
        catch { location.typeOfLocation = SM4MapLocation.TypeOfLocation.Area; }
        
        try { location.locationPosition = new Vector2(
            Int32.Parse(xElements.Element("ScreenLocation").FirstAttribute.Value),
            Int32.Parse(xElements.Element("ScreenLocation").LastAttribute.Value)); }
        catch {  }
        try { location.locationVisible = bool.Parse(xElements.Element("Type").FirstAttribute.Value); }
        catch { location.locationVisible = true; }

        return location;
    }
}









public class SM4MapWorldMap
{
    public string objectName;
    public string path;
    public List<SM4MapRegionMap> regionMaps = new List<SM4MapRegionMap>(); 
}
public class SM4MapRegionMap
{
    public string objectName;
    public string path;
    public List<SM4MapAreaMap> areaMaps = new List<SM4MapAreaMap>(); 
}
public class SM4MapAreaMap
{
    public string objectName;
    public string path;
    public List<SM4MapLocationMap> locationMaps = new List<SM4MapLocationMap>(); 
}
public class SM4MapLocationMap
{
    public string objectName;
    public string path;
    public List<SM4MapLocation> locations = new List<SM4MapLocation>();
    public List<SM4MapHouse> houses = new List<SM4MapHouse>(); 
}


