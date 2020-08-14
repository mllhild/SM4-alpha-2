using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using System.IO;
using System.Net.Mime;
using System.Xml.XPath;
using TMPro;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;

public class LinqLoader : MonoBehaviour
{
    public SM4SlaveMaker slaveMaker;
    
    
    
    public static LinqLoader instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            ErrorLogger.LogErrorInFile("Error in LinqLoader");
            Destroy(gameObject);   
        }
    }

    public SlaveContainer GetSlaveContainer(List<SlaveContainer> listOfSlaveContainers, string slaveName)
    {
        foreach (var slaveContainer in listOfSlaveContainers)
        {
            if (slaveContainer.sm4Slave.slaveName == slaveName)
            {
                return slaveContainer;
            }
        }
        return null;
    }
    
    public SM4EventList GetEventList(SlaveContainer slaveContainer, string eventListName)
    {
        try
        {
            foreach (var sm4EventList in slaveContainer.eventLists.sm4EventLists)
            {
                if (sm4EventList.listName == eventListName)
                {
                    return sm4EventList;
                }
            }
        }
        catch
        {
            return null;    
        }
        return null;
    }
    
    public List<SM4Event> GetAllValidEvents(SM4EventList eventList)
    {
        List<SM4Event> listOfValidEvents = new List<SM4Event>();
        try
        {
            foreach (var sm4Event in eventList.eventList)
            {
                // check for valid attributes
                
                // then add it to the list
                listOfValidEvents.Add(sm4Event);
            }
        }
        catch
        {
            listOfValidEvents = null;
        }
        return listOfValidEvents;
    }
    
    

    public void ReadEventList(List<SM4Event> eventList)
    {
        if(eventList == null)
            return;
        
        foreach (var sm4Event in eventList)
        {
            ReadSubTree(sm4Event.xElement);
        }
        //SM4UIMainTextfield.instance.ResizeTextField();
    }
 
     public void ReadSubTree(XElement xElement)
     {
         var xElementSubtree = XElement.Load(xElement.CreateNavigator().ReadSubtree());
         InterateTheSubTree(xElementSubtree);
     }

     public string lastPersonspeak = "1";

     public void InterateTheSubTree(XElement xElement)
     {
         Debug.Log(" sdasaaasaa");
         
         string nodeName = xElement.Name.ToString();
         
         switch (nodeName)
         {
             case "NextEvent":
                 Debug.Log(" sdasaa");
                 NextButtonInjector(xElement);
                 break;
             case "LineBreak":
                 SM4UIMainTextfield.instance.LineBreak();
                 break;
             case "ClearTextField":
                 Debug.Log("test");
                 SM4UIMainTextfield.instance.ClearText();
                 break;
             case "BlankLine":
                 SM4UIMainTextfield.instance.BlankLine();
                 break;
             case "HideImages":
                 SM4ImageLoader.instance.ClearIntanciatedImages();
                 SM4ImageLoader.instance.ClearLayerImages();
                 break;
             case "SetImage":
                 SM4ImageLoader.instance.InstanciateRawImage(GetImageAttributes(xElement));
                 break;
             case "SetImageLayer":
                 SM4ImageLoader.instance.AddLayerImage(GetImageAttributes(xElement));
                 break;
             case "Points":
                 Debug.Log(nodeName);
                 break;
             default:
                 
                 break;
         }
         
         foreach (var node in xElement.Nodes())
         {
             if (node.NodeType == XmlNodeType.Text)
             {
                 if (xElement.Name == "AddText")
                 {
                     var formatAttributes = GetTextFormatAttributes(xElement);
                     SM4UIMainTextfield.instance.AddText(formatAttributes[0] + node.ToString() + formatAttributes[1]);
                 }
                 if (xElement.Name == "SetText")
                 {
                     SM4UIMainTextfield.instance.AddText(node.ToString());
                 }

                 if (xElement.Name == "PersonSpeak")
                 {
                     if (lastPersonspeak == node.Parent.ToString())
                     {
                         var formatAttributes = GetTextFormatAttributes(xElement);
                         SM4UIMainTextfield.instance.AddText(formatAttributes[0] + node.ToString() + formatAttributes[1]);
                     }
                     else
                     {
                         var personSpeak = new PersonSpeakAttributes();
                         var formatAttributes = GetTextFormatAttributes(xElement);
                         GetPersonSpeakAttributes(
                             personSpeak, 
                             xElement, 
                             formatAttributes[0] + node.ToString() + formatAttributes[1]);
                         SM4UIMainTextfield.instance.PersonSpeak(personSpeak);
                         lastPersonspeak = node.Parent.ToString();
                     }
                     
                 }
                 
                 
             }

             if (xElement.Name == "if")
             {
                 Debug.Log("If node always returns true");
                 // uncomment the part below to actually chec
                 // if (!CheckAttributeList(GetAttributeList(xElement)))
                 // {
                 //     continue;
                 // }
                 if (node.NodeType == XmlNodeType.Text)
                 {
                     var formatAttributes = GetTextFormatAttributes(xElement);
                     SM4UIMainTextfield.instance.AddText(formatAttributes[0] + node.ToString() + formatAttributes[1]);
                 }
             }
             
             if (node.NodeType == XmlNodeType.Element)
             {
                 ReadSubTree(XElement.Load(node.CreateNavigator().ReadSubtree()));
             }
         }
         
        
     }

     private void NextButtonInjector(XElement xElement)
     {
         Debug.Log("hell?");
         if (!xElement.HasAttributes)
         {
             Debug.Log(xElement.FirstAttribute.Value);
             SM4NextEventButton.instance.sm4Event = null;
         }
         else
         {
             SM4NextEventButton.instance.sm4Event =
                 SM4FindEvent.instance.FindEventByName(xElement.FirstAttribute.Value);
             Debug.Log(xElement.FirstAttribute.Value);
         }
     }

     public string[] GetTextFormatAttributes(XElement xElement)
     {
         string formattingCommandsStart = "<color=#000000>";
         string formattingCommandsEnd = "</color>";
         foreach (var attribute in xElement.Attributes())
         {
             switch (attribute.Name.ToString())
             {
                 case "color":
                     formattingCommandsStart += "<color=#" + attribute.Value + ">";
                     formattingCommandsEnd = "</color>" + formattingCommandsEnd;
                     break;
                 case "alpha":
                     formattingCommandsStart += "<alpha=#" + attribute.Value + ">";
                     formattingCommandsEnd = "<alpha=#FF>" + formattingCommandsEnd;
                     break;
                 case "font":
                     Debug.Log(attribute.Value);
                     SM4UIMainTextfield.instance.textfield.font = Resources.Load<TMP_FontAsset>(attribute.Value);
                     break;
                 case "italic":
                     formattingCommandsStart += "<i>";
                     formattingCommandsEnd = "</i>" + formattingCommandsEnd;
                     break;
                 case "bold":
                     formattingCommandsStart += "<b>";
                     formattingCommandsEnd = "</b>" + formattingCommandsEnd;
                     break;
                 case "relativeFontSize":
                     formattingCommandsStart += "<size=" + attribute.Value + ">";
                     formattingCommandsEnd = "<size=100%>" + formattingCommandsEnd;
                     break;
                 case "indent":
                     formattingCommandsStart += "<indent=" + attribute.Value + ">";
                     formattingCommandsEnd = "</indent>" + formattingCommandsEnd;
                     break;
                 case "characterSpacing":
                     formattingCommandsStart += "<cspace=" + attribute.Value + ">";
                     formattingCommandsEnd = "</cspace>" + formattingCommandsEnd;
                     break;
                 case "mark":
                     formattingCommandsStart += "<mark=#" + attribute.Value + ">";
                     formattingCommandsEnd = "</mark>" + formattingCommandsEnd;
                     break;
                 case "capitalization":
                     formattingCommandsStart += "<" + attribute.Value + ">";
                     formattingCommandsEnd = "</" + attribute.Value + ">" + formattingCommandsEnd;
                     break;
                 case "subscript":
                     formattingCommandsStart += "<sub>";
                     formattingCommandsEnd = "</sub>" + formattingCommandsEnd;
                     break;
                 case "supscript":
                     formattingCommandsStart += "<sup>";
                     formattingCommandsEnd = "</sup>" + formattingCommandsEnd;
                     break;
                 case "verticalOffset":
                     formattingCommandsStart += "<voffset=" + attribute.Value + ">";
                     formattingCommandsEnd = "</voffset>" + formattingCommandsEnd;
                     break;
                 case "strikethrough":
                     formattingCommandsStart += "<s>";
                     formattingCommandsEnd = "</s>" + formattingCommandsEnd;
                     break;
                 case "underline":
                     formattingCommandsStart += "<u>";
                     formattingCommandsEnd = "</u>" + formattingCommandsEnd;
                     break;
                 case "horizontalPosition":
                     formattingCommandsStart += "<pos=" + attribute.Value + ">";
                     //formattingCommandsEnd = "</>" + formattingCommandsEnd;
                     break;
                 case "lineHeight":
                     formattingCommandsStart += "<line-height=" + attribute.Value + ">";
                     formattingCommandsEnd = "</line-height>" + formattingCommandsEnd;
                     break;
                 case "align":
                     formattingCommandsStart += "<align=" + attribute.Value + ">";
                     formattingCommandsEnd = "</align>" + formattingCommandsEnd;
                     break;
             } 
         }

         string[] formats = new string[2];
         formats[0] = formattingCommandsStart;
         formats[1] = formattingCommandsEnd;

         return formats;
     }

     public void GetPersonSpeakAttributes(PersonSpeakAttributes personSpeak, XElement xElement, string text)
     {
         personSpeak.text = text;
         foreach (var attribute in xElement.Attributes())
         {
             switch (attribute.Name.ToString())
             {
                case "person":
                    personSpeak.personName = attribute.Value;
                    break;
                case "person-ID":
                    personSpeak.personID = Int32.Parse(attribute.Value);
                    break; 
                case "colorName":
                    personSpeak.color = attribute.Value;
                    break;
                case "boldName":
                    personSpeak.bold = Convert.ToBoolean(attribute.Value);
                    break;
                case "italicName":
                    personSpeak.italic = Convert.ToBoolean(attribute.Value);
                    break;
             }
         }
         
         
     }


     public ImageAttributes GetImageAttributes(XElement xElement)
     {
         ImageAttributes imageAttributes = new ImageAttributes();
         foreach (var attribute in xElement.Attributes())
         {
             switch (attribute.Name.ToString())
             {
                 case "path":
                     imageAttributes.path = Application.streamingAssetsPath + attribute.Value;
                     break;
                 case "layer":
                     imageAttributes.layer = Int32.Parse(attribute.Value); 
                     break;
                 case "scaleX":
                     imageAttributes.scale.x = float.Parse(attribute.Value, CultureInfo.InvariantCulture); 
                     break;
                 case "scaleY":
                     imageAttributes.scale.y = float.Parse(attribute.Value, CultureInfo.InvariantCulture); 
                     break;
                 case "positionX":
                     imageAttributes.position.x = float.Parse(attribute.Value, CultureInfo.InvariantCulture); 
                     break;
                 case "positionY":
                     imageAttributes.position.y = float.Parse(attribute.Value, CultureInfo.InvariantCulture); 
                     break;
                 case "rotationX":
                     imageAttributes.rotation.x = float.Parse(attribute.Value, CultureInfo.InvariantCulture); 
                     break;
                 case "rotationY":
                     imageAttributes.rotation.y = float.Parse(attribute.Value, CultureInfo.InvariantCulture); 
                     break;
                 case "rotationZ":
                     imageAttributes.rotation.z = float.Parse(attribute.Value, CultureInfo.InvariantCulture); 
                     break;
                 case "colorR":
                     imageAttributes.color.r = float.Parse(attribute.Value, CultureInfo.InvariantCulture); 
                     break;
                 case "colorG":
                     imageAttributes.color.g = float.Parse(attribute.Value, CultureInfo.InvariantCulture); 
                     break;
                 case "colorB":
                     imageAttributes.color.b = float.Parse(attribute.Value, CultureInfo.InvariantCulture); 
                     break;
                 case "alpha":
                     imageAttributes.color.a = float.Parse(attribute.Value, CultureInfo.InvariantCulture); 
                     break;
             }
         }

         return imageAttributes;
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
         bool checkIsTrue = true;

         string[] keyParts = key.Split('-');
         //bool greaterThan = value.EndsWith("+");
         //bool lesserThan = value.EndsWith("-");
         
         
         switch (keyParts[0])
         {
             case "sm":
                 CheckAttributeSM(keyParts, value, checkIsTrue);
                 break;
             case "slave":
                 //CheckAttributeSlave(keyParts, value, checkIsTrue);
                 break;
             case "npc":
                 //CheckAttributeNPC(keyParts, value, checkIsTrue);
                 break;
             case "event":
                 //CheckAttributeEvent(keyParts, value, checkIsTrue);
                 break;
             case "item":
                 //CheckAttributeItem(keyParts, value, checkIsTrue);
                 break;
             default:
                 ErrorLogger.LogErrorInFile("Key not recognized: " + key);
                 break;
         }
         
         
         return checkIsTrue;
     }

     private void CheckAttributeSM(string[] keyParts, string value, bool checkIsTrue)
     {
         switch (keyParts[1])
         {
             case "supervise":
                 checkIsTrue = slaveMaker.generalSM.supervise == true;
                 break;
             case "stats":
                 CheckAttributeSMstats(keyParts, value, checkIsTrue);
                 break;
             default:
                 ErrorLogger.LogErrorInFile("Key not recognized: " + keyParts.ToString());
                 break;
         }
         
     }

     private void CheckAttributeSMstats(string[] keyParts, string value, bool checkIsTrue)
     {
         
         switch (keyParts[3])
         {
             case "agility":
                 CheckAttributeSMstatsAgility(keyParts, value, checkIsTrue);
                 break;

             default:
                 ErrorLogger.LogErrorInFile("Key not recognized: " + keyParts.ToString());
                 break;
         }
     }

     private void CheckAttributeSMstatsAgility(string[] keyParts, string value, bool checkIsTrue)
     {
         bool greaterThan = value.EndsWith("+");
         bool lesserThan = value.EndsWith("-");
         int numValue = Int32.Parse(value.Remove(value.Length - 1, 1));
         switch (keyParts[4])
         {
             case "current":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.agility.current >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.agility.current <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.agility.current == numValue;
                 break;
             case "last":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.agility.last >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.agility.last <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.agility.last == numValue;
                 break;
             case "max":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.agility.max >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.agility.max <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.agility.max == numValue;
                 break;
             case "min":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.agility.min >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.agility.min <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.agility.min == numValue;
                 break;
             case "start":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.agility.start >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.agility.start <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.agility.start == numValue;
                 break;
             case "modifier":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.agility.modifier >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.agility.modifier <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.agility.modifier == numValue;
                 break;
             default:
                 ErrorLogger.LogErrorInFile("Key not recognized: " + keyParts.ToString());
                 break;
         }
     }
     
     private void CheckAttributeSMstatsblowjob(string[] keyParts, string value, bool checkIsTrue)
     {
         bool greaterThan = value.EndsWith("+");
         bool lesserThan = value.EndsWith("-");
         int numValue = Int32.Parse(value.Remove(value.Length - 1, 1));
         switch (keyParts[4])
         {
             case "current":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.blowjob.current >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.blowjob.current <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.blowjob.current == numValue;
                 break;
             case "last":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.blowjob.last >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.blowjob.last <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.blowjob.last == numValue;
                 break;
             case "max":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.blowjob.max >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.blowjob.max <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.blowjob.max == numValue;
                 break;
             case "min":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.blowjob.min >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.blowjob.min <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.blowjob.min == numValue;
                 break;
             case "start":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.blowjob.start >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.blowjob.start <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.blowjob.start == numValue;
                 break;
             case "modifier":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.blowjob.modifier >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.blowjob.modifier <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.blowjob.modifier == numValue;
                 break;
             default:
                 ErrorLogger.LogErrorInFile("Key not recognized: " + keyParts.ToString());
                 break;
         }
     }
}

