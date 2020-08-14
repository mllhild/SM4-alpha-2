
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

public class SM4EventLists
{
    public SM4Event sm4Event = new SM4Event();
    public SM4EventLoader sm4EventLoader = new SM4EventLoader();
    public List<SM4EventList> sm4EventLists = new List<SM4EventList>();
    public List<string> parentNodes = new List<string>();

    public void GetParentNodes(string path)
    {
        XElement xElement = null;
        try
        {
            XDocument doc = XDocument.Load(path);
            xElement = doc.Descendants("Events").First();
        }
        catch
        {
            xElement = null;
            ErrorLogger.LogErrorInFile("Error in SM4EventLists.cs in GetParentNodes");
        }
        
        foreach (var element in xElement.Elements())
        {
            if(element.NodeType != XmlNodeType.Comment)
                parentNodes.Add(element.Name.ToString());
        }
    }

    public void LoadEventLists(string path)
    {
        foreach (var parentNode in parentNodes)
        {
            List<SM4Event> eventList = new List<SM4Event>();
            
            sm4EventLoader.LoadEventsFromXmlFile(path, parentNode,eventList);
            
            SM4EventList listEventsWithName = new SM4EventList();
            
            listEventsWithName.eventList = eventList;
            listEventsWithName.listName = parentNode;
            
            sm4EventLists.Add(listEventsWithName);
        }
    }
    
    
}
