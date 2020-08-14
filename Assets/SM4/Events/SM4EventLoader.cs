
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using UnityEngine;

public class SM4EventLoader
{
    private SM4Event sm4Event;

    public void LoadEventsFromXmlFile(string path, string parentNode, List<SM4Event> listEvents)
    {
        if (File.Exists(path))
        {
            LoadFileWithEvents(path, parentNode, listEvents);
        }
        else
        {
            ErrorLogger.LogErrorInFile("xml file does not exist at " + path);
        }
    }

    private void LoadFileWithEvents(string path, string parentNode, List<SM4Event> listEvents)
    {
        XElement xElement = null;
        try
        {
            XDocument doc = XDocument.Load(path);
            xElement = doc.Descendants(parentNode).First();
        }
        catch
        {
            xElement = null;
            ErrorLogger.LogErrorInFile("Error in SM4EventLoader.cs in LoadFileWithEvents");
        }
        AddEventsToList(path, parentNode, listEvents, xElement);
    }

    private List<SM4Event> AddEventsToList(string path, string parentNode,List<SM4Event> listEvents, XElement xElement)
    {
        if (listEvents == null)
        {
            listEvents = new List<SM4Event>();
        }
        if (xElement != null)
        {
            foreach (XElement element in xElement.Elements())
            {
                if (element.NodeType != XmlNodeType.Comment)
                {
                    SM4Event node = new SM4Event();
                    listEvents.Add(node);
                    node.eventName = element.Name.ToString();
                    foreach (var attribute in element.Attributes())
                    {
                        node.attributes.Add(new KeyValuePair<string, string>
                            (attribute.Name.ToString(), attribute.Value.ToString()));
                    }
                    node.xElement = element;
                }
            }
        }
        else
        {
            ErrorLogger.LogErrorInFile("Error due to null in WriteEventsToList in Sm4EventLoader.cs");
        }
        return listEvents;
    }
}
