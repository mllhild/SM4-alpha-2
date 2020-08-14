using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SM4EventExecute : MonoBehaviour
{
    public static SM4EventExecute instance = null;
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

    public bool ExecuteEvent(SM4Event sm4Event)
    {
        try
        {
            ReadSubTree(sm4Event.xElement);
            return true;
        }
        catch 
        {
            ErrorLogger.LogErrorInFile("Error when Executing event" + sm4Event.eventName);
            return false;
        }
    }
    
     public void ReadSubTree(XElement xElement)
     {
         var xElementSubtree = XElement.Load(xElement.CreateNavigator().ReadSubtree());
         InterateTheSubTree(xElementSubtree);
     }

     public string lastPersonspeak = "1";

     public void InterateTheSubTree(XElement xElement)
     {
         
         
         string nodeName = xElement.Name.ToString();
         
         switch (nodeName)
         {
             case "NextEvent":
                 NextButtonInjector(xElement);
                 break;
             case "LineBreak":
                 SM4UIMainTextfield.instance.LineBreak();
                 break;
             case "ClearTextField":
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
                 var currentImageAttributes = GetImageAttributes(xElement);
                 switch (xElement.LastAttribute.Value)
                 {
                     case "Layer":
                         SM4ImageLoader.instance.AddLayerImage(currentImageAttributes);
                         break;
                     case "PortraitRight":
                         SM4AskquestionPopUp.instance.ShowPortrait(currentImageAttributes,"right");
                         break;
                     case "PortraitLeft":
                         SM4AskquestionPopUp.instance.ShowPortrait(currentImageAttributes,"left");
                         break;
                     default:
                         SM4ImageLoader.instance.InstanciateRawImage(currentImageAttributes);
                         break;
                 }
                 break;
             case "SetImageLayer":
                 
                 break;
             
             case "Points":
                 Debug.Log(nodeName);
                 break;
             case "ShowHouse":
                 UIControler.instance.ShowUiHouse();
                 break;
             case "AskQuestion":
                 if(xElement.LastAttribute.Name == "pop")
                     SM4AskquestionPopUp.instance.AskQuestion(xElement);
                 else 
                    SM4UIMainTextfield.instance.AskQuestion(xElement);
                 break;
             case "Answer":
                 if(xElement.LastAttribute.Name == "pop")
                     SM4AskquestionPopUp.instance.AddAnswer(xElement);
                 else
                     SM4UIMainTextfield.instance.AddAnswer(xElement);
                 break;
             case "SetPlanningEvent":
                 SM4PlanningScreen.instance.AddPlanningActToDailyPlanPart1(xElement);
                 break;
             case "SetVariable":
                 SetVariable(xElement);
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

     public string[] GetTextFormatAttributes(XElement xElement)
     {
         string formattingCommandsStart = "<color=#FFFFFF>";
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
                 case "fit":
                     imageAttributes.fit = bool.Parse(attribute.Value); 
                     break;
                 case "fill":
                     imageAttributes.fill = bool.Parse(attribute.Value); 
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
                 case "misc":
                     imageAttributes.misc = attribute.Value; 
                     break;
             }
         }

         return imageAttributes;
     }
     private void NextButtonInjector(XElement xElement)
     {
         
         SM4NextEventButton.instance.ShowButton();
         if (!xElement.HasAttributes)
         {
             SM4NextEventButton.instance.sm4Event = null;
             Debug.Log("If events dont trigger anymore correctly look here");
         }
         else
         {
             SM4NextEventButton.instance.sm4Event =
                 SM4FindEvent.instance.FindEventByName(xElement.FirstAttribute.Value);
             if(xElement.LastAttribute.Value == "true")
                 SM4NextEventButton.instance.DoStoredEvent();
             Debug.Log(xElement.FirstAttribute.Value);
             Debug.Log(SM4NextEventButton.instance.sm4Event.eventName);
         }
         
     }


     private void SetVariable(XElement xElement)
     {
         // <SetVariable slave-ID-5-Stats-Obedience-current ='50' operation='set'/>
         // <SetVariable slave-ID-5-Stats-Obedience-current ='50' operation='add'/>
         // <SetVariable slave-ID-5-Stats-Obedience-current ='50' operation='subtract'/>
         // <SetVariable slave-ID-5-Stats-Obedience-current ='50' operation='multiply'/>
         // <SetVariable slave-ID-5-Stats-Obedience-current ='50' operation='divide'/>
         // <SetVariable slave-ID-5-Stats-Obedience-current = 'slave-ID-6-Stats-Obedience-current' operation='equal'/>
         //
         // grab both sides
         // look up the left one and save the result
         // look what type of variable this is
         // check operation
         // based on that parse the one on the right
         
         // other option
         // <SetVariable slave-ID-5-Stats-Obedience-current = 'slave-ID-6-Stats-Obedience-current * 50'/>
         // grab both sides
         // look up the left one and save the result
         // look what type of variable this is
         // process a split() command on the right side
         // check if for variables and return them as numbers => [23][*][50]
         // now process field by field
     }

     private void FindVariableByNameStart(XElement xElement)
     {
         VariablePasser variablePasser = new VariablePasser();
         variablePasser.name01 = xElement.FirstAttribute.Name.ToString().Split('-');
         variablePasser.value01 = xElement.FirstAttribute.Value.ToString().Split('_');
         variablePasser.value02 = xElement.LastAttribute.Value.ToString();
         FindVariableByNamePart0(variablePasser);
         
         print(variablePasser.boolValue.ToString());
         print(variablePasser.intValue.ToString());
         print(variablePasser.floatValue.ToString("F"));
         print(variablePasser.intValue.ToString());
         print(variablePasser.stringValue.ToString());
         print(variablePasser.generalValue.ToString());
         
     }

     private void FindVariableByNamePart0(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[0])
         {
             case "sm":
                 FindVariableByNamePart1SM(variablePasser);
                 break;
             case "slave":
                 switch (variablePasser.name01[1])
                 {
                     case "current":
                         variablePasser.iD = SM4SlaveMakerControler.instance.slaveMaker.currentSlaveID;
                         break;
                     case "ID":
                         variablePasser.iD = Int32.Parse(variablePasser.name01[2]);
                         break;
                 }
                 FindVariableByNamePart1Slave(variablePasser);
                 break;
             case "npc":
                 FindVariableByNamePart1Npc(variablePasser);
                 break;
             case "world":
                 FindVariableByNamePart1World(variablePasser);
                 break;
             default:
                 return;
                 break;
         }
     }

     private void FindVariableByNamePart1World(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[1])
         {
             case "location":
                 FindVariableByNamePart2WorldLocation(variablePasser);
                 break;
             case "time":
                 FindVariableByNamePart2WorldTime(variablePasser);
                 break;
             case "flags":
                 FindVariableByNamePart2WorldFlags(variablePasser);
                 break;
             default:
                 break;
         }
     }

     private void FindVariableByNamePart2WorldFlags(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[2])
         {
             case "didAEvent":
                 variablePasser.boolValue = World.instance.didMorningPlanning;
                 break;
             case "didMorningPlanning":
                 variablePasser.boolValue = World.instance.didAEvent;
                 break;
             case "didEveningPlanning":
                 variablePasser.boolValue = World.instance.didEveningPlanning;
                 break;
             case "didGoSleep":
                 variablePasser.boolValue = World.instance.didGoSleep;
                 break;
             default:
                 break;
         }
     }

     private void FindVariableByNamePart2WorldTime(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[2])
         {
             case "time":
                 variablePasser.intValue = World.instance.time;
                 break;
             case "hour":
                 variablePasser.intValue = World.instance.hour;
                 break;
             case "day":
                 variablePasser.intValue = World.instance.day;
                 break;
             case "weekday":
                 variablePasser.intValue = World.instance.weekday;
                 break;
             case "week":
                 variablePasser.intValue = World.instance.week;
                 break;
             case "month":
                 variablePasser.intValue = World.instance.month;
                 break;
             case "year":
                 variablePasser.intValue = World.instance.year;
                 break;
             default:
                 break;
         }
         
     }

     private void FindVariableByNamePart2WorldLocation(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[2])
         {
             case "locationCurrent":
                 variablePasser.stringValue = World.instance.locationCurrent;
                 break;
             default:
                 break;
         }
     }

     
     
     private void FindVariableByNamePart1SM(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[1])
         {
             case "slave":
                 FindVariableByNamePart2SMSlave(variablePasser);
                 break;
             case "character":
                 FindVariableByNamePart2SMCharacter(variablePasser);
                 break;
             case "race":
                 FindVariableByNamePart2SMRace(variablePasser);
                 break;
             case "products":
                 FindVariableByNamePart2SMProducts(variablePasser);
                 break;
             case "generalSM":
                 FindVariableByNamePart2SMgeneralSM(variablePasser);
                 break;
             case "currentSlaveID":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.currentSlaveID;
                 break;
             case "rulesAreOn":
                 variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.rulesAreOn[Int32.Parse(variablePasser.name01[2])];
                 break;
             default:
                 break;
         }
     }

     
     private void FindVariableByNamePart2SMProducts(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[2])
         {
             case "trained":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.products.trained;
                 break;
             case "sold":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.products.sold;
                 break;
             case "kept":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.products.kept;
                 break;
             case "bought":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.products.bought;
                 break;
             case "lost":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.products.lost;
                 break;
             case "escaped":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.products.escaped;
                 break;
             case "kidnapped":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.products.kidnapped;
                 break;
             case "died":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.products.died;
                 break;
             default:
                 break;
         }
     }
     private void FindVariableByNamePart2SMgeneralSM(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[2])
         {
             case "masterMistress":
                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.generalSM.masterMistress;
                 break;
             case "supervise":
                 variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.generalSM.supervise;
                 break;
             default:
                 break;
         }
     }
    
     
     private void FindVariableByNamePart2SMSlave(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[2])
         {
             case "slaveID":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.slaveID;
                 break;
             case "slaveName":
                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.slaveName;
                 break;
             case "trainingStartDate":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.trainingStartDate;
                 break;
             case "trainingTime":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.trainingTime;
                 break;
             case "astrid":
                 switch (variablePasser.name01[3])
                 {
                     case "chanceToMeet":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.astrid.chanceToMeet;
                         break;
                     case "futaAstrid":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.astrid.futaAstrid;
                         break;
                     case "futaChance":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.astrid.futaChance;
                         break;
                     default:
                         break;
                 }
                 break;
             case "generalSlave":
                 switch (variablePasser.name01[3])
                 {
                     case "prostituteParty":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.generalSlave.prostituteParty;
                         break;
                     case "highclassParty":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.generalSlave.highclassParty;
                         break;
                     case "callsYouMaster":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.generalSlave.callsYouMaster;
                         break;
                     default:
                         break;
                 }
                 break;
             case "dating":
                 switch (variablePasser.name01[3])
                 {
                     case "dating":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.dating.dating;
                         break;
                     case "loverGender":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.dating.loverGender;
                         break;
                     case "loverRelativeAge":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.dating.loverRelativeAge;
                         break;
                     default:
                         break;
                 }
                 break;
             case "noble":
                 switch (variablePasser.name01[3])
                 {
                     case "nobleID":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.noble.nobleID;
                         break;
                     case "nobleLove":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.noble.nobleLove;
                         break;
                     case "state":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.noble.state;
                         break;
                     default:
                         break;
                 }
                 break;
             case "slaveCategory":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.slaveCategory;
                 break;
             case "minReputation":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.minReputation;
                 break;
             case "showInSlaveMarket":
                 variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.showInSlaveMarket;
                 break;
             case "canBeBought":
                 variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.canBeBought;
                 break;
             case "slavePrice":
                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.slavePrice;
                 break;
             case "aviableForTraining":
                 variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.aviableForTraining;
                 break;
             case "contractOnly":
                 variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.contractOnly;
                 break;
             case "visits":
                 var visits = SM4SlaveMakerControler.instance.slaveMaker.visits;
                 foreach (var visit in visits)
                     return;
                 break;
             case "jobs":
                 var jobs = SM4SlaveMakerControler.instance.slaveMaker.jobs;
                 foreach (var job in jobs)
                     return;
                 break;
             case "chores":
                 var chores = SM4SlaveMakerControler.instance.slaveMaker.chores;
                 foreach (var chore in chores)
                     return;
                 break;
             case "schools":
                 var schools = SM4SlaveMakerControler.instance.slaveMaker.schools;
                 foreach (var school in schools)
                     return;
                 break;
             case "misc":
                 var miscs = SM4SlaveMakerControler.instance.slaveMaker.misc;
                 foreach (var misc in miscs)
                     return;
                 break;
             case "sexNormal":
                 var sexNormals = SM4SlaveMakerControler.instance.slaveMaker.sexNormal;
                 foreach (var sexNormal in sexNormals)
                     return;
                 break;
             case "sexExtreme":
                 var sexExtremes = SM4SlaveMakerControler.instance.slaveMaker.sexExtreme;
                 foreach (var sexExtreme in sexExtremes)
                     return;
                 break;
             
             default:
                 break;
         }
     }

     

     private void FindVariableByNamePart2SMCharacter(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[2])
         {
             case "ID":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.ID;
                 break;
             case "path":
                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.path;
                 break;
             case "regionCurrent":
                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.regionCurrent;
                 break;
             case "regionLast":
                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.regionLast;
                 break;
             case "areaCurrent":
                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.areaCurrent;
                 break;
             case "areaLast":
                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.areaLast;
                 break;
             case "locationCurrent":
                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.locationCurrent;
                 break;
             case "locationLast":
                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.locationLast;
                 break;
             case "nameChar":
                 switch (variablePasser.name01[3])
                 {
                     case "first":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.nameChar.first;
                         break;
                     case "middle":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.nameChar.middle;
                         break;
                     case "last":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.nameChar.last;
                         break;
                     case "prefix":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.nameChar.prefix;
                         break;
                     case "title":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.nameChar.title;
                         break;
                     case "nickname":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.nameChar.nickname;
                         break;
                     case "slavename":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.nameChar.slavename;
                         break;
                     case "nameBorn":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.nameChar.nameBorn;
                         break;
                 }
                 break;
             case "characterPronouns":
                 switch (variablePasser.name01[3])
                 {
                     case "I":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.characterPronouns.I;
                         break;
                     case "heSheIt":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.characterPronouns.heSheIt;
                         break;
                     case "hisherits":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.characterPronouns.hisherits;
                         break;
                     case "himherit":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.characterPronouns.himherit;
                         break;
                     case "gender":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.characterPronouns.gender;
                         break;
                 }
                 break;
             case "general":
                 switch (variablePasser.name01[3])
                 {
                     case "sexActsOK":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.general.sexActsOK;
                         break;
                     case "birthday":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.general.birthday;
                         break;
                     case "age":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.general.age;
                         break;
                     case "description":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.general.description;
                         break;
                     case "goldEarned":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.general.goldEarned;
                         break;
                     case "goldOwned":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.general.goldOwned;
                         break;
                     case "badGirl":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.general.badGirl;
                         break;
                     case "behaving":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.general.behaving;
                         break;
                     case "loyalty":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.general.loyalty;
                         break;
                     case "attitude":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.general.attitude;
                         break;
                     case "loveAccepted":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.general.loveAccepted;
                         break;
                     case "isNaked":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.general.isNaked;
                         break;
                     case "loli":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.general.loli;
                         break;
                     case "noble":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.general.noble;
                         break;
                 }
                 break;
             case "gender":
                 switch (variablePasser.name01[3])
                 {
                     case "current":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.gender.current;
                         break;
                     case "last":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.gender.last;
                         break;
                     case "born":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.gender.born;
                         break;
                 }
                 break;
             case "vitals":
                 FindVariableByNamePart3SMCharacterVitals(variablePasser);
                 break;
             case "text":
                 switch (variablePasser.name01[3])
                 {
                     case "itHeShe":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.text.itHeShe;
                         break;
                     case "itHimHer":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.text.itHimHer;
                         break;
                     case "itsHisHer":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.text.itsHisHer;
                         break;
                 }
                 break;
             case "stats":
                 FindVariableByNamePart3SMCharacterStats(variablePasser);
                 break;
             case "sexSkills":
                 FindVariableByNamePart3SMCharacterSexSkills(variablePasser);
                 break;
             case "skills":
                 FindVariableByNamePart3SMCharacterSkills(variablePasser);
                 break;
             case "virginity":
                 switch (variablePasser.name01[3])
                 {
                     case "vaginal":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.virginity.vaginal;
                         break;
                     case "oral":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.virginity.oral;
                         break;
                     case "anal":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.virginity.anal;
                         break;
                     case "cock":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.virginity.cock;
                         break;
                 }
                 break;
             case "training":
                 FindVariableByNamePart3SMCharacterTrainingTypes(variablePasser);
                 break;
             case "owner":
                 switch (variablePasser.name01[3])
                 {
                     case "isOwned":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.owner.isOwned;
                         break;
                     case "testing":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.owner.testing;
                         break;
                     case "testingUrgent":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.owner.testingUrgent;
                         break;
                     case "ownerIDcurrent":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.owner.ownerIDcurrent;
                         break;
                     case "ownerIDprevious":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.owner.ownerIDprevious;
                         break;
                     case "ownerName":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.owner.ownerName;
                         break;
                     case "ownerPath":
                         variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.owner.ownerPath;
                         break;
                 }
                 break;
             case "father":
                 switch (variablePasser.name01[3])
                 {
                     case "ID":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.father.ID;
                         break;
                     case "raceID":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.father.raceID;
                         break;
                     case "nameOf":
                         switch (variablePasser.name01[4])
                         {
                             case "first":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.father.nameOf.first;
                                 break;
                             case "middle":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.father.nameOf.middle;
                                 break;
                             case "last":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.father.nameOf.last;
                                 break;
                             case "prefix":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.father.nameOf.prefix;
                                 break;
                             case "title":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.father.nameOf.title;
                                 break;
                             case "nickname":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.father.nameOf.nickname;
                                 break;
                             case "slavename":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.father.nameOf.slavename;
                                 break;
                             case "nameBorn":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.father.nameOf.nameBorn;
                                 break;
                         }
                         break;
                 }
                 break;
             case "mother":
                 switch (variablePasser.name01[3])
                 {
                     case "ID":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.mother.ID;
                         break;
                     case "raceID":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.mother.raceID;
                         break;
                     case "nameOf":
                         switch (variablePasser.name01[4])
                         {
                             case "first":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.mother.nameOf.first;
                                 break;
                             case "middle":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.mother.nameOf.middle;
                                 break;
                             case "last":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.mother.nameOf.last;
                                 break;
                             case "prefix":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.mother.nameOf.prefix;
                                 break;
                             case "title":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.mother.nameOf.title;
                                 break;
                             case "nickname":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.mother.nameOf.nickname;
                                 break;
                             case "slavename":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.mother.nameOf.slavename;
                                 break;
                             case "nameBorn":
                                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.mother.nameOf.nameBorn;
                                 break;
                         }
                         break;
                 }
                 break;
             case "varInt":
                 variablePasser.intValue =
                     SM4SlaveMakerControler.instance.slaveMaker.varInt[Int32.Parse(variablePasser.name01[3])];
                 break;
             case "varString":
                 variablePasser.stringValue =
                     SM4SlaveMakerControler.instance.slaveMaker.varString[Int32.Parse(variablePasser.name01[3])];
                 break;
             case "varBool":
                 variablePasser.boolValue =
                     SM4SlaveMakerControler.instance.slaveMaker.varBool[Int32.Parse(variablePasser.name01[3])];
                 break;
             default:
                 break;
         }
     }
     
     private void FindVariableByNamePart3SMCharacterVitals(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[3])
         {
             case "height":
                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.height;
                 break;
             case "weight":
                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.weight;
                 break;
             case "bust":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.bust.current;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.bust.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.bust.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.bust.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.bust.min;
                         break;
                 }
                 break;
             case "underBustSize":
                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.underBustSize;
                 break;
             case "aurola":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.aurola.current;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.aurola.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.aurola.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.aurola.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.aurola.min;
                         break;
                 }
                 break;
             case "cupSize":
                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cupSize;
                 break;
             case "cock":
                 switch (variablePasser.name01[4])
                 {
                     case "hasCock":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.hasCock;
                         break;
                     case "size":
                         switch (variablePasser.name01[5])
                         {
          case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.size.current;
                                 break;
          case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.size.last;
                                 break;
          case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.size.start;
                                 break;
          case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.size.max;
                                 break;
          case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.size.min;
                                 break;
                         }
                         break;
                     case "grid":
                         switch (variablePasser.name01[5])
                         {
          case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.grid.current;
                                 break;
          case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.grid.last;
                                 break;
          case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.grid.start;
                                 break;
          case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.grid.max;
                                 break;
          case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.grid.min;
                                 break;
                         }
                         break;
                     case "type":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.type;
                         break;
                     case "typeVar":
                         switch (variablePasser.name01[5])
                         {
          case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.typeVar.current;
                                 break;
          case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.typeVar.last;
                                 break;
          case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.typeVar.start;
                                 break;
          case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.typeVar.max;
                                 break;
          case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cock.typeVar.min;
                                 break;
                         }
                         break;
                 }
                 break;
             case "testicles":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.testicles.current;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.testicles.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.testicles.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.testicles.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.testicles.min;
                         break;
                 }
                 break;
             case "cum":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cum.volume.current;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cum.volume.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cum.volume.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cum.volume.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cum.volume.min;
                         break;
                     case "fertility":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.cum.fertility;
                         break;
                 }
                 break;
             case "clit":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.clit.current;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.clit.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.clit.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.clit.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.clit.min;
                         break;
                 }
                 break;
             case "hasPussy":
                 variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.hasPussy;
                 break;
             case "pussy":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.pussy.current;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.pussy.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.pussy.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.pussy.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.pussy.min;
                         break;
                 }
                 break;
             case "pussyGrid":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.pussyGrid.current;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.pussyGrid.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.pussyGrid.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.pussyGrid.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.pussyGrid.min;
                         break;
                 }
                 break;
             case "waist":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.waist.current;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.waist.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.waist.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.waist.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.waist.min;
                         break;
                 }
                 break;
             case "throat":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.throat.current;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.throat.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.throat.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.throat.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.throat.min;
                         break;
                 }
                 break;
             case "bloodType":
                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.vitals.bloodType;
                 break;
         }
     }

     private void FindVariableByNamePart3SMCharacterStats(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[3])
         {
             case "agility":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.agility.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.agility.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.agility.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.agility.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.agility.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.agility.min;
                         break;
                 }
             break;
             case "blowjob":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.blowjob.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.blowjob.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.blowjob.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.blowjob.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.blowjob.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.blowjob.min;
                         break;
                 }
                 break;
             case "charisma":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.charisma.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.charisma.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.charisma.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.charisma.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.charisma.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.charisma.min;
                         break;
                 }
                 break;
             case "corruption":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.corruption.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.corruption.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.corruption.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.corruption.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.corruption.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.corruption.min;
                         break;
                 }
                 break;
             case "constitution":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.constitution.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.constitution.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.constitution.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.constitution.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.constitution.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.constitution.min;
                         break;
                 }
                 break;
             case "cooking":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.cooking.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.cooking.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.cooking.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.cooking.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.cooking.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.cooking.min;
                         break;
                 }
                 break;
             case "cleaning":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.cleaning.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.cleaning.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.cleaning.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.cleaning.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.cleaning.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.cleaning.min;
                         break;
                 }
                 break;
             case "conversation":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.conversation.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.conversation.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.conversation.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.conversation.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.conversation.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.conversation.min;
                         break;
                 }
                 break;
             case "dominance":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.dominance.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.dominance.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.dominance.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.dominance.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.dominance.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.dominance.min;
                         break;
                 }
                 break;
             case "dexterity":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.dexterity.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.dexterity.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.dexterity.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.dexterity.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.dexterity.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.dexterity.min;
                         break;
                 }
                 break;
             case "fuck":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.fuck.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.fuck.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.fuck.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.fuck.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.fuck.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.fuck.min;
                         break;
                 }
                 break;
             case "intelligence":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.intelligence.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.intelligence.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.intelligence.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.intelligence.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.intelligence.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.intelligence.min;
                         break;
                 }
                 break;
             case "joy":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.joy.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.joy.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.joy.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.joy.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.joy.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.joy.min;
                         break;
                 }
                 break;
             case "libido":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.libido.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.libido.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.libido.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.libido.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.libido.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.libido.min;
                         break;
                 }
                 break;
             case "love":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.love.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.love.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.love.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.love.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.love.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.love.min;
                         break;
                 }
                 break;
             case "mind":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.mind.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.mind.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.mind.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.mind.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.mind.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.mind.min;
                         break;
                 }
                 break;
             case "morality":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.morality.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.morality.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.morality.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.morality.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.morality.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.morality.min;
                         break;
                 }
                 break;
             case "nymphomania":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.nymphomania.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.nymphomania.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.nymphomania.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.nymphomania.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.nymphomania.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.nymphomania.min;
                         break;
                 }
                 break;
             case "obedience":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.obedience.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.obedience.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.obedience.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.obedience.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.obedience.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.obedience.min;
                         break;
                 }
                 break;
             case "refinement":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.refinement.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.refinement.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.refinement.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.refinement.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.refinement.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.refinement.min;
                         break;
                 }
                 break;
             case "reputation":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.reputation.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.reputation.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.reputation.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.reputation.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.reputation.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.reputation.min;
                         break;
                 }
                 break;
             case "sensibility":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.sensibility.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.sensibility.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.sensibility.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.sensibility.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.sensibility.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.sensibility.min;
                         break;
                 }
                 break;
             case "strenght":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.strenght.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.strenght.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.strenght.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.strenght.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.strenght.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.strenght.min;
                         break;
                 }
                 break;
             case "submission":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.submission.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.submission.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.submission.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.submission.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.submission.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.submission.min;
                         break;
                 }
                 break;
             case "temperament":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.temperament.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.temperament.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.temperament.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.temperament.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.temperament.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.temperament.min;
                         break;
                 }
                 break;
             case "tiredness":
                 switch (variablePasser.name01[4])
                 {
                     case "current":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.tiredness.current;
                         break;
                     case "modifier":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.tiredness.modifier;
                         break;
                     case "last":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.tiredness.last;
                         break;
                     case "start":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.tiredness.start;
                         break;
                     case "max":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.tiredness.max;
                         break;
                     case "min":
                         variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.stats.tiredness.min;
                         break;
                 }
                 break;
         }
         
     }
     
     private void FindVariableByNamePart3SMCharacterSexSkills(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[3])
         {
              case "anal":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.anal.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.anal.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.anal.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.anal.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.anal.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.anal.min;
                        break;
                }
                        break;
                    case "blowjob":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.blowjob.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.blowjob.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.blowjob.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.blowjob.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.blowjob.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.blowjob.min;
                        break;
                }
                        break;
                    case "bondage":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.bondage.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.bondage.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.bondage.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.bondage.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.bondage.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.bondage.min;
                        break;
                }
                        break;
                    case "cumBath":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.cumBath.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.cumBath.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.cumBath.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.cumBath.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.cumBath.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.cumBath.min;
                        break;
                }
                        break;
                    case "dildo":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.dildo.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.dildo.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.dildo.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.dildo.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.dildo.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.dildo.min;
                        break;
                }
                        break;
                    case "fuck":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.fuck.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.fuck.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.fuck.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.fuck.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.fuck.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.fuck.min;
                        break;
                }
                        break;
                    case "gangBang":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.gangBang.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.gangBang.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.gangBang.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.gangBang.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.gangBang.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.gangBang.min;
                        break;
                }
                        break;
                    case "group":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.group.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.group.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.group.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.group.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.group.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.group.min;
                        break;
                }
                        break;
                    case "kiss":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.kiss.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.kiss.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.kiss.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.kiss.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.kiss.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.kiss.min;
                        break;
                }
                        break;
                    case "lendHer":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lendHer.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lendHer.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lendHer.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lendHer.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lendHer.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lendHer.min;
                        break;
                }
                        break;
                    case "lesbian":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lesbian.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lesbian.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lesbian.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lesbian.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lesbian.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lesbian.min;
                        break;
                }
                        break;
                    case "lick":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lick.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lick.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lick.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lick.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lick.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.lick.min;
                        break;
                }
                        break;
                    case "masturbate":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.masturbate.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.masturbate.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.masturbate.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.masturbate.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.masturbate.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.masturbate.min;
                        break;
                }
                        break;
                    case "naked":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.naked.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.naked.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.naked.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.naked.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.naked.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.naked.min;
                        break;
                }
                        break;
                    case "plug":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.plug.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.plug.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.plug.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.plug.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.plug.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.plug.min;
                        break;
                }
                        break;
                    case "spank":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.spank.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.spank.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.spank.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.spank.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.spank.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.spank.min;
                        break;
                }
                        break;
                    case "stripTease":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.stripTease.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.stripTease.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.stripTease.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.stripTease.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.stripTease.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.stripTease.min;
                        break;
                }
                        break;
                    case "threesome":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.threesome.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.threesome.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.threesome.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.threesome.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.threesome.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.threesome.min;
                        break;
                }
                        break;
                    case "titsFuck":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.titsFuck.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.titsFuck.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.titsFuck.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.titsFuck.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.titsFuck.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.titsFuck.min;
                        break;
                }
                        break;
                    case "touch":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.touch.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.touch.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.touch.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.touch.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.touch.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.touch.min;
                        break;
                }
                        break;
                    case "act69":
                switch (        variablePasser.name01[4])
                {
                    case "current":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.act69.current;
                        break;
                    case "modifier":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.act69.modifier;
                        break;
                    case "last":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.act69.last;
                        break;
                    case "start":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.act69.start;
                        break;
                    case "max":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.act69.max;
                        break;
                    case "min":
                        variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.sexSkills.act69.min;
                        break;
                }
                    break;

         }
     }
     
     private void FindVariableByNamePart3SMCharacterSkills(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[3])
         {
                 case "dancing":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.dancing.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.dancing.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.dancing.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.dancing.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.dancing.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.dancing.min;
                            break;
                    }
                            break;
                        case "singing":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.singing.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.singing.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.singing.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.singing.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.singing.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.singing.min;
                            break;
                    }
                            break;
                        case "swimming":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.swimming.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.swimming.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.swimming.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.swimming.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.swimming.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.swimming.min;
                            break;
                    }
                            break;
                        case "slaveTrainer":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.slaveTrainer.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.slaveTrainer.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.slaveTrainer.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.slaveTrainer.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.slaveTrainer.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.slaveTrainer.min;
                            break;
                    }
                            break;
                        case "likesFemaleTrainer":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesFemaleTrainer.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesFemaleTrainer.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesFemaleTrainer.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesFemaleTrainer.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesFemaleTrainer.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesFemaleTrainer.min;
                            break;
                    }
                            break;
                        case "likesMaleTrainer":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesMaleTrainer.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesMaleTrainer.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesMaleTrainer.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesMaleTrainer.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesMaleTrainer.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesMaleTrainer.min;
                            break;
                    }
                            break;
                        case "likesFutaTrainer":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesFutaTrainer.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesFutaTrainer.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesFutaTrainer.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesFutaTrainer.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesFutaTrainer.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.likesFutaTrainer.min;
                            break;
                    }
                            break;
                        case "ponySlaveTrainer":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.ponySlaveTrainer.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.ponySlaveTrainer.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.ponySlaveTrainer.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.ponySlaveTrainer.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.ponySlaveTrainer.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.ponySlaveTrainer.min;
                            break;
                    }
                            break;
                        case "catSlaveTrainer":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.catSlaveTrainer.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.catSlaveTrainer.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.catSlaveTrainer.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.catSlaveTrainer.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.catSlaveTrainer.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.catSlaveTrainer.min;
                            break;
                    }
                            break;
                        case "dogSlaveTrainer":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.dogSlaveTrainer.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.dogSlaveTrainer.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.dogSlaveTrainer.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.dogSlaveTrainer.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.dogSlaveTrainer.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.dogSlaveTrainer.min;
                            break;
                    }
                            break;
                        case "cowSlaveTrainer":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.cowSlaveTrainer.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.cowSlaveTrainer.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.cowSlaveTrainer.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.cowSlaveTrainer.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.cowSlaveTrainer.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.cowSlaveTrainer.min;
                            break;
                    }
                            break;
                        case "succubusTrainer":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.succubusTrainer.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.succubusTrainer.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.succubusTrainer.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.succubusTrainer.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.succubusTrainer.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.succubusTrainer.min;
                            break;
                    }
                            break;
                        case "slutTrainer":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.slutTrainer.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.slutTrainer.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.slutTrainer.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.slutTrainer.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.slutTrainer.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.slutTrainer.min;
                            break;
                    }
                            break;
                        case "fairyTrainer":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.fairyTrainer.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.fairyTrainer.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.fairyTrainer.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.fairyTrainer.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.fairyTrainer.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.fairyTrainer.min;
                            break;
                    }
                            break;
                        case "leadership":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.leadership.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.leadership.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.leadership.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.leadership.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.leadership.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.leadership.min;
                            break;
                    }
                            break;
                        case "trader":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.trader.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.trader.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.trader.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.trader.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.trader.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.trader.min;
                            break;
                    }
                            break;
                        case "alchemy":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.alchemy.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.alchemy.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.alchemy.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.alchemy.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.alchemy.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.alchemy.min;
                            break;
                    }
                            break;
                        case "mage":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.mage.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.mage.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.mage.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.mage.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.mage.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.mage.min;
                            break;
                    }
                            break;
                        case "refined":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.refined.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.refined.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.refined.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.refined.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.refined.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.refined.min;
                            break;
                    }
                            break;
                        case "noble":
                    switch (        variablePasser.name01[4])
                    {
                        case "current":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.noble.current;
                            break;
                        case "modifier":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.noble.modifier;
                            break;
                        case "last":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.noble.last;
                            break;
                        case "start":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.noble.start;
                            break;
                        case "max":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.noble.max;
                            break;
                        case "min":
                            variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.skills.noble.min;
                            break;
                    }
                            break;

         }
     }

     private void FindVariableByNamePart3SMCharacterTrainingTypes(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[3])
         {
             case "likesFemale":
                 switch (variablePasser.name01[4])
                 {
                     case "trainable":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .likesFemale.trainable;
                         break;
                     case "isBeingTrained":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .likesFemale.isBeingTrained;
                         break;
                     case "resistance":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .likesFemale.resistance;
                         break;
                     case "completion":
                         switch (variablePasser.name01[5])
                         {
                             case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesFemale.completion.min;
                                 break;
                             case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesFemale.completion.max;
                                 break;
                             case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesFemale.completion.start;
                                 break;
                             case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesFemale.completion.last;
                                 break;
                             case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesFemale.completion.current;
                                 break;
                             case "modifier":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesFemale.completion.modifier;
                                 break;
                         }
                         break;
                 }
                 
                 break;
             case "likesMale":
                 switch (variablePasser.name01[4])
                 {
                     case "trainable":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .likesMale.trainable;
                         break;
                     case "isBeingTrained":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .likesMale.isBeingTrained;
                         break;
                     case "resistance":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .likesMale.resistance;
                         break;
                     case "completion":
                         switch (variablePasser.name01[5])
                         {
                             case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesMale.completion.min;
                                 break;
                             case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesMale.completion.max;
                                 break;
                             case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesMale.completion.start;
                                 break;
                             case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesMale.completion.last;
                                 break;
                             case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesMale.completion.current;
                                 break;
                             case "modifier":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesMale.completion.modifier;
                                 break;
                         }
                         break;
                 }
                 
                 break;
             case "likesFuta":
                 switch (variablePasser.name01[4])
                 {
                     case "trainable":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .likesFuta.trainable;
                         break;
                     case "isBeingTrained":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .likesFuta.isBeingTrained;
                         break;
                     case "resistance":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .likesFuta.resistance;
                         break;
                     case "completion":
                         switch (variablePasser.name01[5])
                         {
                             case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesFuta.completion.min;
                                 break;
                             case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesFuta.completion.max;
                                 break;
                             case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesFuta.completion.start;
                                 break;
                             case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesFuta.completion.last;
                                 break;
                             case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesFuta.completion.current;
                                 break;
                             case "modifier":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .likesFuta.completion.modifier;
                                 break;
                         }
                         break;
                 }
                 
                 break;
             case "ponySlave":
                 switch (variablePasser.name01[4])
                 {
                     case "trainable":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .ponySlave.trainable;
                         break;
                     case "isBeingTrained":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .ponySlave.isBeingTrained;
                         break;
                     case "resistance":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .ponySlave.resistance;
                         break;
                     case "completion":
                         switch (variablePasser.name01[5])
                         {
                             case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .ponySlave.completion.min;
                                 break;
                             case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .ponySlave.completion.max;
                                 break;
                             case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .ponySlave.completion.start;
                                 break;
                             case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .ponySlave.completion.last;
                                 break;
                             case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .ponySlave.completion.current;
                                 break;
                             case "modifier":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .ponySlave.completion.modifier;
                                 break;
                         }
                         break;
                 }
                 
                 break;
             case "catSlave":
                 switch (variablePasser.name01[4])
                 {
                     case "trainable":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .catSlave.trainable;
                         break;
                     case "isBeingTrained":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .catSlave.isBeingTrained;
                         break;
                     case "resistance":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .catSlave.resistance;
                         break;
                     case "completion":
                         switch (variablePasser.name01[5])
                         {
                             case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .catSlave.completion.min;
                                 break;
                             case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .catSlave.completion.max;
                                 break;
                             case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .catSlave.completion.start;
                                 break;
                             case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .catSlave.completion.last;
                                 break;
                             case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .catSlave.completion.current;
                                 break;
                             case "modifier":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .catSlave.completion.modifier;
                                 break;
                         }
                         break;
                 }
                 
                 break;
             case "dogSlave":
                 switch (variablePasser.name01[4])
                 {
                     case "trainable":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .dogSlave.trainable;
                         break;
                     case "isBeingTrained":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .dogSlave.isBeingTrained;
                         break;
                     case "resistance":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .dogSlave.resistance;
                         break;
                     case "completion":
                         switch (variablePasser.name01[5])
                         {
                             case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .dogSlave.completion.min;
                                 break;
                             case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .dogSlave.completion.max;
                                 break;
                             case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .dogSlave.completion.start;
                                 break;
                             case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .dogSlave.completion.last;
                                 break;
                             case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .dogSlave.completion.current;
                                 break;
                             case "modifier":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .dogSlave.completion.modifier;
                                 break;
                         }
                         break;
                 }
                 
                 break;
             case "cowSlave":
                 switch (variablePasser.name01[4])
                 {
                     case "trainable":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .cowSlave.trainable;
                         break;
                     case "isBeingTrained":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .cowSlave.isBeingTrained;
                         break;
                     case "resistance":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .cowSlave.resistance;
                         break;
                     case "completion":
                         switch (variablePasser.name01[5])
                         {
                             case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .cowSlave.completion.min;
                                 break;
                             case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .cowSlave.completion.max;
                                 break;
                             case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .cowSlave.completion.start;
                                 break;
                             case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .cowSlave.completion.last;
                                 break;
                             case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .cowSlave.completion.current;
                                 break;
                             case "modifier":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .cowSlave.completion.modifier;
                                 break;
                         }
                         break;
                 }
                 
                 break;
             case "succubus":
                 switch (variablePasser.name01[4])
                 {
                     case "trainable":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .succubus.trainable;
                         break;
                     case "isBeingTrained":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .succubus.isBeingTrained;
                         break;
                     case "resistance":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .succubus.resistance;
                         break;
                     case "completion":
                         switch (variablePasser.name01[5])
                         {
                             case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .succubus.completion.min;
                                 break;
                             case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .succubus.completion.max;
                                 break;
                             case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .succubus.completion.start;
                                 break;
                             case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .succubus.completion.last;
                                 break;
                             case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .succubus.completion.current;
                                 break;
                             case "modifier":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .succubus.completion.modifier;
                                 break;
                         }
                         break;
                 }
                 
                 break;
             case "slut":
                 switch (variablePasser.name01[4])
                 {
                     case "trainable":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .slut.trainable;
                         break;
                     case "isBeingTrained":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .slut.isBeingTrained;
                         break;
                     case "resistance":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .slut.resistance;
                         break;
                     case "completion":
                         switch (variablePasser.name01[5])
                         {
                             case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .slut.completion.min;
                                 break;
                             case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .slut.completion.max;
                                 break;
                             case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .slut.completion.start;
                                 break;
                             case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .slut.completion.last;
                                 break;
                             case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .slut.completion.current;
                                 break;
                             case "modifier":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .slut.completion.modifier;
                                 break;
                         }
                         break;
                 }
                 
                 break;
             case "fairy":
                 switch (variablePasser.name01[4])
                 {
                     case "trainable":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .fairy.trainable;
                         break;
                     case "isBeingTrained":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .fairy.isBeingTrained;
                         break;
                     case "resistance":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .fairy.resistance;
                         break;
                     case "completion":
                         switch (variablePasser.name01[5])
                         {
                             case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .fairy.completion.min;
                                 break;
                             case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .fairy.completion.max;
                                 break;
                             case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .fairy.completion.start;
                                 break;
                             case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .fairy.completion.last;
                                 break;
                             case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .fairy.completion.current;
                                 break;
                             case "modifier":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .fairy.completion.modifier;
                                 break;
                         }
                         break;
                 }
                 
                 break;
             case "courtesan":
                 switch (variablePasser.name01[4])
                 {
                     case "trainable":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .courtesan.trainable;
                         break;
                     case "isBeingTrained":
                         variablePasser.boolValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .courtesan.isBeingTrained;
                         break;
                     case "resistance":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.training
                             .courtesan.resistance;
                         break;
                     case "completion":
                         switch (variablePasser.name01[5])
                         {
                             case "min":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .courtesan.completion.min;
                                 break;
                             case "max":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .courtesan.completion.max;
                                 break;
                             case "start":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .courtesan.completion.start;
                                 break;
                             case "last":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .courtesan.completion.last;
                                 break;
                             case "current":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .courtesan.completion.current;
                                 break;
                             case "modifier":
                                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.training
                                     .courtesan.completion.modifier;
                                 break;
                         }
                         break;
                 }
                 
                 break;
             
             
         }
     }
     
     
     private void FindVariableByNamePart2SMRace(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[2])
         {
             case "fertility":
                 variablePasser.floatValue = SM4SlaveMakerControler.instance.slaveMaker.fertility;
                 break;
             case "raceName":
                 variablePasser.stringValue = SM4SlaveMakerControler.instance.slaveMaker.raceName;
                 break;
             case "raceID":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.raceID;
                 break;
             case "averageBodySize":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.averageBodySize;
                 break;
             case "ears":
                 switch (variablePasser.name01[3])
                 {
                     case "shape":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.ears.shape;
                         break;
                     case "lenght":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.ears.lenght;
                         break;
                     case "size":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.ears.size;
                         break;
                     case "texture":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.ears.texture;
                         break;
                 }
                 break;
             case "eyes":
                 switch (variablePasser.name01[3])
                 {
                     case "number":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.eyes.number;
                         break;
                     case "lenght":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.eyes.type;
                         break;
                     case "thickness":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.eyes.pupilForm;
                         break;
                     case "texture":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.eyes.nightVision;
                         break;
                 }
                 break;
             case "legs":
                 switch (variablePasser.name01[3])
                 {
                     case "number":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.legs.number;
                         break;
                     case "lenght":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.legs.lenght;
                         break;
                     case "thickness":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.legs.thickness;
                         break;
                     case "texture":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.legs.texture;
                         break;
                 }
                 break;
             case "arms":
                 switch (variablePasser.name01[3])
                 {
                     case "number":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.arms.number;
                         break;
                     case "lenght":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.arms.lenght;
                         break;
                     case "thickness":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.arms.thickness;
                         break;
                     case "texture":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.arms.texture;
                         break;
                 }
                 break;
             case "wings":
                 switch (variablePasser.name01[3])
                 {
                     case "number":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.wings.number;
                         break;
                     case "lenght":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.wings.lenght;
                         break;
                     case "thickness":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.wings.thickness;
                         break;
                     case "texture":
                         variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.wings.texture;
                         break;
                 }
                 break;
             case "raceType":
                 variablePasser.intValue = SM4SlaveMakerControler.instance.slaveMaker.raceType;
                 break;
             
         }
     }
     
     
     private void FindVariableByNamePart1Npc(VariablePasser variablePasser)
     {
         switch (variablePasser.name01[1])
         {
             case "a":
                 break;
             default:
                 break;
         }
     }
     private void FindVariableByNamePart1Slave(VariablePasser variablePasser)
     {
         
     }
}

public class VariablePasser
{
    public string[] name01;
    public string[] value01;
    public string value02;

    public string stringValue;
    public int intValue;
    public float floatValue;
    public bool boolValue;
    public string generalValue;

    public int iD;
}
