using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using UnityEngine;


public class SlaveContainer : MonoBehaviour
{
    // this file gets instanciated and contains a slaves
    // - variables
    // - override acts
    // - events
    // - dresses
    // - endings?
    
    
    
    public SM4Slave sm4Slave = new SM4Slave();
    public SM4EventLists eventLists = new SM4EventLists();
    public SM4EventLoader sm4EventLoader = new SM4EventLoader();

    private void Start()
    {
        
        GetComponentInParent<SlaveFilesController>().listOfSlaves.Add(this);
        LoadSlave( Application.streamingAssetsPath + @"\Slaves\Blondie", "Blondie");
        this.gameObject.name = sm4Slave.slaveName;
    }

    public void InstanciateSlave(string path, string slaveName)
    {
        LoadSlave(path, slaveName);
        eventLists.LoadEventLists(path);
        
    }
    public void SaveSlave(string path)
    {
        FileStream stream = new FileStream(Path.Combine(path, sm4Slave.slaveName + ".xml"), FileMode.Create);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SM4Slave));
        xmlSerializer.Serialize(stream, sm4Slave);
        stream.Close();
    }
    public void LoadSlave(string path, string slaveName)
    {
        
        try
        {
            FileStream stream = new FileStream(Path.Combine(path, slaveName + ".xml"), FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SM4Slave));
            sm4Slave = xmlSerializer.Deserialize(stream) as SM4Slave;
            stream.Close();
        }
        catch
        {
            Debug.Log("Error in SlaveContainer Load with " + path.ToString() + "/" + slaveName.ToString() + ".xml");
            // SM4Slave sm4Slave = new SM4Slave();
            // sm4Slave.slaveName = slaveName + "new";
            // SaveSlave(sm4Slave, path);
        }

        LoadSlaveEvents(path);
    }

    public void LoadSlaveEvents(string path)
    {
        path = Path.Combine(path, "Events.xml");
        try
        {
            eventLists.GetParentNodes(path);
            eventLists.LoadEventLists(path);
        }
        catch
        {
            Debug.Log("Error in SlaveContainer LoadSlaveEvents with " + path.ToString() + "/" + "Events.xml");
        }

    }

    private void PrintEventListToCheck()
    {
        foreach (var sm4EventList in eventLists.sm4EventLists)
        {
            if (sm4EventList.eventList.Count > 0)
            {
                //Debug.Log(sm4EventList.listName);
                foreach (var sm4Event in sm4EventList.eventList)
                {
                    if (sm4Event.xElement != null)
                    {
                        //Debug.Log(sm4Event.eventName);
                        foreach (var node in sm4Event.xElement.Nodes())
                        {
                            Debug.Log(node.ToString());
                        }
                    }
                        
                }
            }

        }
    }

}
