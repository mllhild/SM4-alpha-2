using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using TMPro;
using UnityEngine;

public class LinqXMLtoCsharp : MonoBehaviour
{
    public TextMeshProUGUI textfield;
    public void ReadSubTree(XElement xElement)
    {
        var xElementSubtree = XElement.Load(xElement.CreateNavigator().ReadSubtree());
        InterateTheSubTree(xElementSubtree);
    }
    
    public void InterateTheSubTree(XElement xElement)
    {
        if (xElement.Name == "ClearTextField")
            textfield.text = "";

        if (xElement.Name == "Points")
        {
            //FunctionPoints(xElement);
        }
            
         
        foreach (var node in xElement.Nodes())
        {
            if (node.NodeType == XmlNodeType.Text)
            {
                if (xElement.Name == "AddText")
                {
                    textfield.text += "AddText: ";
                    textfield.text += node.ToString() + "\n";
                    // <color=#000000> but im going to put the standard as black</font>
                }
                if (xElement.Name == "SetText")
                {
                    textfield.text += "<color=#000000>";
                    textfield.text += "SetText: ";
                    textfield.text += node.ToString() + "\n";
                    textfield.text += "</color>";
                }
                 
            }

            if (xElement.Name == "if")
            {
                textfield.text += "if statement with attributes: " + "\n";
                 
                if (!CheckAttributeList(GetAttributeList(xElement)))
                {
                    continue;
                }
            }
             
            if (node.NodeType == XmlNodeType.Element)
            {
                ReadSubTree(XElement.Load(node.CreateNavigator().ReadSubtree()));
            }
             
        }
    }
    
    public bool CheckAttributeList(List<KeyValuePair<string, string>> attributes)
    {
        bool allAttributesAreTrue = true;
        foreach (var attribute in attributes)
        { 
            allAttributesAreTrue = CheckAttribute(attribute.Key, attribute.Value);
            if(!allAttributesAreTrue)
                return allAttributesAreTrue;       
        }
        return allAttributesAreTrue;
    }
    
    public bool CheckAttribute(string key, string value)
    {
        int var01 = 1;
        int var02 = 2;
        int var03 = 3;
        int var04 = 4;
         
         
        bool checkIsTrue = true;

        switch (key)
        {
            case "var01":
                checkIsTrue = (var01 == int.Parse(value));
                break;
            case "var02":
                checkIsTrue = (var02 == int.Parse(value));
                break;
            case "var03":
                checkIsTrue = (var03 == int.Parse(value));
                break;
            case "var04":
                checkIsTrue = (var04 == int.Parse(value));
                break;
            default:
                checkIsTrue = false;
                break;
        }
        return checkIsTrue;
    }
    
    public List<KeyValuePair<string, string>> GetAttributeList(XElement xElement)
    {
        List<KeyValuePair<string, string>> attributes = new List<KeyValuePair<string, string>>();
        foreach (var attribute in xElement.Attributes())
        {
            attributes.Add(new KeyValuePair<string, string>
                (attribute.Name.ToString(), attribute.Value.ToString()));
        }

        return attributes;
    }
}
