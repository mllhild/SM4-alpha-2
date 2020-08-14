using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class SM4PlanningXMLReader : MonoBehaviour
{
    // this code is not used
    void Start()
    {
        GetXMLPlanningDirectories("Events");
    }
    public void GetXMLPlanningDirectories(string parentFolder)
    {
        string planningEvents;
        planningEvents = Path.Combine(Application.streamingAssetsPath, parentFolder);
        string[] planningDirectories = Directory.GetDirectories(planningEvents);
        foreach (var planningDirectory in planningDirectories)
            GetXMLPlanningFile(Path.Combine(planningDirectory, "PlanningActs.xml"));
    }

    public void GetXMLPlanningFile(string planningDirectory)
    {
        XDocument doc;
        try { doc = XDocument.Load(planningDirectory); }
        catch { doc = null; }
        XElement xElement = null;
        try { xElement = doc.Descendants("Planning").First();  }
        catch { xElement = null; }

        if (xElement == null) { ErrorLogger.LogErrorInFile("In " + this.name + "planning was null"); return; }
        
        
    }

}
