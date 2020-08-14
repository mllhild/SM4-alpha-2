using System.Collections.Generic;
using System.Xml.Linq;

public class SM4Event
{
    public string eventName = "error";
    public int eventID = 0;
    public bool eventGlobal = false;
    public XElement xElement = null;
    public List<KeyValuePair<string, string>> attributes = new List<KeyValuePair<string, string>>();
}


