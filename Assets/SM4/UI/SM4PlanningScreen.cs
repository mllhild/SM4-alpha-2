using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SM4PlanningScreen : MonoBehaviour
{
    public static SM4PlanningScreen instance = null;
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

    private void Start()
    {
        GetXMLPlanningDirectories("Events");
        StartPlanning();
        tabHeader.SetActive(true);
        characterHeader.SetActive(true);
        tabContainer.SetActive(true);
        background.gameObject.SetActive(true);
    }
    // eventname gets loaded into button
    // event gets called on click
    // event adds entry to daily planning
    // all events are in a list


    public Image background;
    public GameObject characterHeader;
    public SM4PrefabPlanningButton headerSlaveMaker;
    public SM4PrefabPlanningButton headerSlave;
    public SM4PrefabPlanningButton headerAssistant;
    
    
    public GameObject tabHeader;
    
    public SM4PrefabPlanningButton sexNormal;
    public SM4PrefabPlanningButton sexExtreme;
    public SM4PrefabPlanningButton jobs;
    public SM4PrefabPlanningButton chores;
    public SM4PrefabPlanningButton schoolShop;
    public SM4PrefabPlanningButton misc;
    
    
    public GameObject tabContainer;
    public SM4PrefabPlanningButton[] tabHeaderSlave = new SM4PrefabPlanningButton[6];
    public SM4PrefabPlanningButton[] tabHeaderSlaveMaker = new SM4PrefabPlanningButton[3];
    public SM4PrefabPlanningButton[] tabHeaderAssistant = new SM4PrefabPlanningButton[1];
    public SM4PlanningTab[] tabsSlave = new SM4PlanningTab[6];
    public SM4PlanningTab[] tabsSlaveMaker = new SM4PlanningTab[3];
    public SM4PlanningTab[] tabsAssistant = new SM4PlanningTab[1];


    public GameObject selectButtonSlaveMaker;
    public GameObject selectButtonSlave;
    public GameObject selectButtonAssistant;
    public SM4PlanningFieldBoxes[] slaveColumPlanningFieldBoxeses = new SM4PlanningFieldBoxes[10];
    public SM4PlanningFieldBoxes[] slavemakerColumPlanningFieldBoxeses = new SM4PlanningFieldBoxes[10];
    public SM4PlanningFieldBoxes[] assistantColumPlanningFieldBoxeses = new SM4PlanningFieldBoxes[10];

    public Button slaveMakerField;
    public Button slaveField;
    public Button assistantField;

    

    

    public void StartPlanning()
    {
        
        World.instance.UpdateDate();
        FindHourAtStartOfPlanning();
        
        AssignButtonFunctions();
        selectedRowSlave = true;
        selectedRowAssistant = false;
        selectedRowSlaveMaker = false;
        selectButtonSlaveMaker.SetActive(true);
        selectButtonSlave.SetActive(true);
        selectButtonAssistant.SetActive(true);
        selectButtonSlave.GetComponent<Button>().interactable = false;
        selectButtonSlaveMaker.GetComponent<Button>().interactable = true;
        selectButtonAssistant.GetComponent<Button>().interactable = true;
        //if(!assistantAviable)
        //selectButtonAssistant.SetActive(false);
        //rowAssistant[0].gameObject.transform.parent.gameObject.SetActive(false);
        //if(!slaveMakerAviable)
        //selectButtonSlave.SetActive(false);
        //rowSlave[0].gameObject.transform.parent.gameObject.SetActive(false);
        //if(!slaveAviable)
        //selectButtonSlaveMaker.SetActive(false);
        //rowSlaveMaker[0].gameObject.transform.parent.gameObject.SetActive(false);
        
        
        HideAllTabs();
        HideAllTabHeaders();
        HideAllHeaders();
        CheckIfAllCharactersAreAviableForPlanning();
        // show first tab

        AddActivities();

        questionIsActive = false;





    }

    public void AssignButtonFunctions()
    {
        headerSlave.button.onClick.AddListener(()=>TabSlaveShow());
        headerSlaveMaker.button.onClick.AddListener(()=>TabSlaveMakerShow());
        headerAssistant.button.onClick.AddListener(()=>TabAssistantShow());
        tabHeaderSlave[0].button.onClick.AddListener(()=>SubTabSlave00Show());
        tabHeaderSlave[1].button.onClick.AddListener(()=>SubTabSlave01Show());
        tabHeaderSlave[2].button.onClick.AddListener(()=>SubTabSlave02Show());
        tabHeaderSlave[3].button.onClick.AddListener(()=>SubTabSlave03Show());
        tabHeaderSlave[4].button.onClick.AddListener(()=>SubTabSlave04Show());
        tabHeaderSlave[5].button.onClick.AddListener(()=>SubTabSlave05Show());
        tabHeaderSlaveMaker[0].button.onClick.AddListener(()=>SubTabSlaveMaker00Show());
        tabHeaderSlaveMaker[1].button.onClick.AddListener(()=>SubTabSlaveMaker01Show());
        tabHeaderSlaveMaker[2].button.onClick.AddListener(()=>SubTabSlaveMaker02Show());
        tabHeaderAssistant[0].button.onClick.AddListener(()=>SubTabAssistant00Show());
    }
    
    
    public int planningTimeStart;
    public int planningTimeCurrent;
    public int planningTimeEnd;
    
    public bool selectedRowSlaveMaker;
    public bool selectedRowSlave;
    public bool selectedRowAssistant;


    public void SelectRowSlave()
    {
        selectedRowSlave = true; selectedRowAssistant = false; selectedRowSlaveMaker = false;
        selectButtonSlave.GetComponent<Button>().interactable = false;
        selectButtonSlaveMaker.GetComponent<Button>().interactable = true;
        selectButtonAssistant.GetComponent<Button>().interactable = true;
    }

    public void SelectRowAssistant()
    {
        selectedRowSlave = false; selectedRowAssistant = true; selectedRowSlaveMaker = false;
        selectButtonSlave.GetComponent<Button>().interactable = true;
        selectButtonSlaveMaker.GetComponent<Button>().interactable = true;
        selectButtonAssistant.GetComponent<Button>().interactable = false;
    }

    public void SelectRowSlaveMaker()
    {
        selectedRowSlave = false; selectedRowAssistant = false; selectedRowSlaveMaker = true;
        selectButtonSlave.GetComponent<Button>().interactable = true;
        selectButtonSlaveMaker.GetComponent<Button>().interactable = false;
        selectButtonAssistant.GetComponent<Button>().interactable = true;
    }

    public void HideAllTabs()
    {
        foreach (var tab in tabsSlave)
            tab.gameObject.SetActive(false);
        foreach (var tab in tabsAssistant)
            tab.gameObject.SetActive(false);
        foreach (var tab in tabsSlaveMaker)
            tab.gameObject.SetActive(false);
    }

    public void HideAllTabHeaders()
    {
        foreach (var tabheader in tabHeaderSlave)
            tabheader.gameObject.SetActive(false);
        foreach (var tabheader in tabHeaderSlaveMaker)
            tabheader.gameObject.SetActive(false);
        foreach (var tabheader in tabHeaderAssistant)
            tabheader.gameObject.SetActive(false);
    }

    public void HideAllHeaders()
    {
        headerSlaveMaker.gameObject.SetActive(false);
        headerSlave.gameObject.SetActive(false);
        headerAssistant.gameObject.SetActive(false);
    }

    public void CheckIfAllCharactersAreAviableForPlanning()
    {
        //if(!assistantAviable)
        //selectButtonAssistant.SetActive(false);
        //rowAssistant[0].gameObject.transform.parent.gameObject.SetActive(false);
        headerAssistant.gameObject.SetActive(true);
        tabsSlave[0].gameObject.transform.parent.gameObject.SetActive(true);
        TabSlaveShow();
        SubTabSlave00Show();
        //if(!slaveMakerAviable)
        //selectButtonSlave.SetActive(false);
        //rowSlave[0].gameObject.transform.parent.gameObject.SetActive(false);
        headerSlave.gameObject.SetActive(true);
        //if(!slaveAviable)
        //selectButtonSlaveMaker.SetActive(false);
        //rowSlaveMaker[0].gameObject.transform.parent.gameObject.SetActive(false);
        headerSlaveMaker.gameObject.SetActive(true);
        
    }

    public void TabSlaveShow()
    {
        HideAllTabs();
        HideAllTabHeaders();
        foreach (var tabheader in tabHeaderSlave)
            tabheader.gameObject.SetActive(true);
        tabsSlave[0].gameObject.SetActive(true);
    }
    public void TabSlaveMakerShow()
    {
        HideAllTabs();
        HideAllTabHeaders();
        foreach (var tabheader in tabHeaderSlaveMaker)
            tabheader.gameObject.SetActive(true);
        tabsSlaveMaker[0].gameObject.SetActive(true);
    }
    public void TabAssistantShow()
    {
        HideAllTabs();
        HideAllTabHeaders();
        foreach (var tabheader in tabHeaderAssistant)
            tabheader.gameObject.SetActive(true);
        tabsAssistant[0].gameObject.SetActive(true);
    }

    public void SubTabSlave00Show() { HideAllTabs(); tabsSlave[0].gameObject.SetActive(true); }
    public void SubTabSlave01Show() { HideAllTabs(); tabsSlave[1].gameObject.SetActive(true); }
    public void SubTabSlave02Show() { HideAllTabs(); tabsSlave[2].gameObject.SetActive(true); }
    public void SubTabSlave03Show() { HideAllTabs(); tabsSlave[3].gameObject.SetActive(true); }
    public void SubTabSlave04Show() { HideAllTabs(); tabsSlave[4].gameObject.SetActive(true); }
    public void SubTabSlave05Show() { HideAllTabs(); tabsSlave[5].gameObject.SetActive(true); }
    
    public void SubTabSlaveMaker00Show() { HideAllTabs(); tabsSlaveMaker[0].gameObject.SetActive(true); }
    public void SubTabSlaveMaker01Show() { HideAllTabs(); tabsSlaveMaker[1].gameObject.SetActive(true); }
    public void SubTabSlaveMaker02Show() { HideAllTabs(); tabsSlaveMaker[2].gameObject.SetActive(true); }
    
    public void SubTabAssistant00Show() { HideAllTabs(); tabsAssistant[0].gameObject.SetActive(true); }



    public void AddActivities()
    {
        HideAllsubTabBlockElements();
        HideAllsubTabs();
        ApplyPlanningButtons();
    }

    
    public List<PlanningActButtonData> planningActs = new List<PlanningActButtonData>();
    public List<PlanningActHintData> planningActHints = new List<PlanningActHintData>();
    public List<SM4Event> planningEvents = new List<SM4Event>();
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

        foreach (var planningElement in xElement.Elements())
        {
            if (planningElement.NodeType != XmlNodeType.Comment)
            {
                PlanningActButtonData planningAct = new PlanningActButtonData();
                planningAct.gameobjectName = planningElement.Name.ToString();
                foreach (var attribute in planningElement.Attributes())
                {
                    switch (attribute.Name.ToString())
                    {
                        case "location":
                            planningAct.location = attribute.Value;
                            break;
                        case "characterID":
                            planningAct.characterID = Int32.Parse(attribute.Value);
                            break;
                        case "tab":
                            planningAct.tab = Int32.Parse(attribute.Value);
                            break;
                        case "subtab":
                            planningAct.subtab = Int32.Parse(attribute.Value);
                            break;
                        case "label":
                            planningAct.label = attribute.Value;
                            break;
                        case "hintCode":
                            planningAct.hintCode = attribute.Value;
                            break;
                        case "planningEvent":
                            planningAct.planningEvent = attribute.Value;
                            break;
                        case "buttonNumber":
                            planningAct.buttonNumber = Int32.Parse(attribute.Value);
                            break;
                    }
                }

                planningActs.Add(planningAct);
            }
        }
        

        XElement xElementHints = null;
        try { xElementHints = doc.Descendants("Hints").First();  }
        catch { xElementHints = null; }
        if (xElementHints == null) { ErrorLogger.LogErrorInFile("In " + this.name + "planningHints was null"); return; }
        foreach (var planningHintsElememts in xElementHints.Elements())
        {
            if (planningHintsElememts.NodeType != XmlNodeType.Comment)
            {
                PlanningActHintData hint = new PlanningActHintData();
                foreach (var hintAttritbute in planningHintsElememts.Attributes())
                {
                    switch (hintAttritbute.Name.ToString())
                    {
                        case "hintCode":
                            hint.hintCode = hintAttritbute.Value;
                            break;
                        case "text":
                            hint.text = hintAttritbute.Value;
                            break;
                    }
                }

                planningActHints.Add(hint);
            }
        }
        
        XElement xElementEvents = null;
        try { xElementEvents = doc.Descendants("PlanningEvents").First();  }
        catch { xElementEvents = null; }
        if (xElementEvents == null) { ErrorLogger.LogErrorInFile("In " + this.name + "PlanningEvents was null"); return; }
        foreach (var planningEventsElememts in xElementEvents.Elements())
        {
            if (planningEventsElememts.NodeType != XmlNodeType.Comment)
            {
                SM4Event sm4Event = new SM4Event();
                sm4Event.xElement = planningEventsElememts;
                foreach (var xAttribute in planningEventsElememts.Attributes())
                    sm4Event.attributes.Add(new KeyValuePair<string, string>(xAttribute.Name.ToString(), xAttribute.Value.ToString()));
                sm4Event.eventName = planningEventsElememts.Name.LocalName;
                planningEvents.Add(sm4Event);
            }
        }
        
    }

    public bool questionIsActive;
    public void ShowHintOnHover(string hintCode)
    {
        if(!questionIsActive)
        {
            SM4UIMainTextfield.instance.ClearText();
            foreach (var hint in planningActHints)
                if (hint.hintCode == hintCode)
                {
                    SM4UIMainTextfield.instance.AddText(hint.text);
                    return;
                }
        }
    }

    public void HideAllsubTabBlockElements()
    {
        foreach (var tab in tabsSlave)
            foreach (var row in tab.rows)
                foreach (var rowButton in row.row01Buttons)
                {
                    rowButton.button.interactable = false;
                    rowButton.label.text = "";
                }
        foreach (var tab in tabsSlaveMaker)
            foreach (var row in tab.rows)
                foreach (var rowButton in row.row01Buttons)
                {
                    rowButton.button.interactable = false;
                    rowButton.label.text = "";
                }
        foreach (var tab in tabsAssistant)
             foreach (var row in tab.rows)
                foreach (var rowButton in row.row01Buttons)
                {
                    rowButton.button.interactable = false;
                    rowButton.label.text = "";
                }
    }
    public void HideAllsubTabs()
    {
        foreach (var tab in tabsSlave)
            foreach (var row in tab.rows)
                row.label.gameObject.SetActive(false);
        foreach (var tab in tabsSlaveMaker)
            foreach (var row in tab.rows)
                row.label.gameObject.SetActive(false);
        foreach (var tab in tabsAssistant)
            foreach (var row in tab.rows)
                row.label.gameObject.SetActive(false);
    }

    public void ApplyPlanningButtons()
    {
        foreach (var planningAct in planningActs)
        {
            var buttontab = tabsSlaveMaker[0].rows[0].row01Buttons[0];;
            if (planningAct.characterID == 0)
            { buttontab = tabsSlaveMaker[planningAct.tab].rows[planningAct.subtab].row01Buttons[planningAct.buttonNumber]; }
            else if (planningAct.characterID < 1000)
            { buttontab = tabsSlave[planningAct.tab].rows[planningAct.subtab].row01Buttons[planningAct.buttonNumber]; }
            else
            { buttontab = tabsAssistant[planningAct.tab].rows[planningAct.subtab].row01Buttons[planningAct.buttonNumber]; }
           
            buttontab.transform.parent.transform.parent.GetComponent<SM4PlanningTabRow>().label.gameObject.SetActive(true);
            buttontab.label.text= planningAct.label;
            buttontab.eventName = planningAct.planningEvent;
            buttontab.hintCode = planningAct.hintCode;
            buttontab.button.interactable = true; 
        }
    }

    public void FindHourAtStartOfPlanning()
    {
        for (int i = 0; i < 10; i++)
        {
            slavemakerColumPlanningFieldBoxeses[i].button.interactable = true;
            slavemakerColumPlanningFieldBoxeses[i].timeslot = i + 8;
            slavemakerColumPlanningFieldBoxeses[i].characterCode = 1;
            
            slaveColumPlanningFieldBoxeses[i].button.interactable = true;
            slaveColumPlanningFieldBoxeses[i].timeslot = i + 8;
            slaveColumPlanningFieldBoxeses[i].characterCode = 0;
            
            assistantColumPlanningFieldBoxeses[i].button.interactable = true;
            assistantColumPlanningFieldBoxeses[i].timeslot = i + 8;
            assistantColumPlanningFieldBoxeses[i].characterCode = 2;
        }
        
        
        planningTimeStart = World.instance.hour;
        planningTimeEnd = 18;
        var count = planningTimeStart - 8;
        for (int i = 0; i < count && i<10; i++)
        {
            slavemakerColumPlanningFieldBoxeses[i].button.interactable = false;
            slaveColumPlanningFieldBoxeses[i].button.interactable = false;
            assistantColumPlanningFieldBoxeses[i].button.interactable = false;
        }

        planningTimeCurrent = planningTimeStart;

    }

    public void AddPlanningActToDailyPlanPart1(XElement xElement)
    {
        string label = "";
        string eventName = "";
        int durationInHours = 0;
        int participant01 = 0;
        int participant02 = 0;
        foreach (var attribute in xElement.Attributes())
        {
            switch (attribute.Name.ToString())
            {
                case "duration":
                    durationInHours = Int32.Parse(attribute.Value);
                    break;
                case "participant01":
                    participant01 = Int32.Parse(attribute.Value);
                    break;
                case "participant02":
                    participant02 = Int32.Parse(attribute.Value);
                    break;
                case "event":
                    eventName = attribute.Value;
                    break;
            }
        }
        AddPlanningActToDailyPlanPart2(label,eventName,durationInHours,participant01,participant02);
    }
    public void AddPlanningActToDailyPlanPart2(string label, string eventName, int durationInHours, int participant01, int participant02)
    {
        if ((planningTimeCurrent + durationInHours) > planningTimeEnd)
        {
            SM4UIMainTextfield.instance.ClearText();
            SM4UIMainTextfield.instance.AddText("Not enough time remaining");
            return;
        }
        var timeslot = planningTimeCurrent - 8;
        
        if(participant01 >= 0)
            RemoveSelectedTrainingField(timeslot, participant01);
        if(participant02 >= 0)
            RemoveSelectedTrainingField(timeslot, participant02);
        
        if(participant01 == 0 || participant02 == 0)
        {
            
            for (int i = 0; i < durationInHours; i++)
            {
                slaveColumPlanningFieldBoxeses[timeslot].label.text = label + " (cont.)";
                slaveColumPlanningFieldBoxeses[timeslot + i].eventName = "continuation";
                slaveColumPlanningFieldBoxeses[timeslot].participant01 = participant01;
                slaveColumPlanningFieldBoxeses[timeslot].participant02 = participant02;
                slaveColumPlanningFieldBoxeses[timeslot].durationTotal = durationInHours;
                slaveColumPlanningFieldBoxeses[timeslot].durationRemaining = durationInHours - i;
            }
            slaveColumPlanningFieldBoxeses[timeslot].label.text = label;
            slaveColumPlanningFieldBoxeses[timeslot].eventName = eventName;
        }
        if(participant01 == 1 || participant02 == 1)
        {
            for (int i = 0; i < durationInHours; i++)
            {
                slavemakerColumPlanningFieldBoxeses[timeslot].label.text = label + " (cont.)";
                slavemakerColumPlanningFieldBoxeses[timeslot + i].eventName = "continuation";
                slavemakerColumPlanningFieldBoxeses[timeslot].participant01 = participant01;
                slavemakerColumPlanningFieldBoxeses[timeslot].participant02 = participant02;
                slavemakerColumPlanningFieldBoxeses[timeslot].durationTotal = durationInHours;
                slavemakerColumPlanningFieldBoxeses[timeslot].durationRemaining = durationInHours - i;
            }
            slavemakerColumPlanningFieldBoxeses[timeslot].label.text = label;
            slavemakerColumPlanningFieldBoxeses[timeslot].eventName = eventName;
        }
        if(participant01 == 2 || participant02 == 2)
        {
            for (int i = 0; i < durationInHours; i++)
            {
                assistantColumPlanningFieldBoxeses[timeslot].label.text = label + " (cont.)";
                assistantColumPlanningFieldBoxeses[timeslot + i].eventName = "continuation";
                assistantColumPlanningFieldBoxeses[timeslot].participant01 = participant01;
                assistantColumPlanningFieldBoxeses[timeslot].participant02 = participant02;
                assistantColumPlanningFieldBoxeses[timeslot].durationTotal = durationInHours;
                assistantColumPlanningFieldBoxeses[timeslot].durationRemaining = durationInHours - i;
            }
            assistantColumPlanningFieldBoxeses[timeslot].label.text = label;
            assistantColumPlanningFieldBoxeses[timeslot].eventName = eventName;
        }
    }
    public void RemoveSelectedTrainingField(int timeslot, int participant )
    {

        SM4PlanningFieldBoxes[] boxes = new SM4PlanningFieldBoxes[10];
        if (participant == 0)
            boxes = slaveColumPlanningFieldBoxeses;
        if (participant == 1)
            boxes = slavemakerColumPlanningFieldBoxeses;
        if (participant == 2)
            boxes = assistantColumPlanningFieldBoxeses;
        int totalDuration = boxes[timeslot].durationTotal;
        int durationRemaining = boxes[timeslot].durationRemaining;
        int intialTime = timeslot - durationRemaining + 1;
        int participant01 = boxes[timeslot].participant01;
        int participant02 = boxes[timeslot].participant02;
        
        if(participant01 == 0 || participant02 == 0)
            for (int i = 0; i < totalDuration; i++)
            {
                slaveColumPlanningFieldBoxeses[intialTime+i].label.text = "idle";
                slaveColumPlanningFieldBoxeses[intialTime+i].eventName = "idle";
                slaveColumPlanningFieldBoxeses[intialTime+i].participant01 = -1;
                slaveColumPlanningFieldBoxeses[intialTime+i].participant02 = -1;
                slaveColumPlanningFieldBoxeses[intialTime+i].durationTotal = 0;
                slaveColumPlanningFieldBoxeses[intialTime+i].durationRemaining = 0;
            }
        if(participant01 == 1 || participant02 == 1)
            for (int i = 0; i < totalDuration; i++)
            {
                slavemakerColumPlanningFieldBoxeses[intialTime+i].label.text = "idle";
                slavemakerColumPlanningFieldBoxeses[intialTime+i].eventName = "idle";
                slavemakerColumPlanningFieldBoxeses[intialTime+i].participant01 = -1;
                slavemakerColumPlanningFieldBoxeses[intialTime+i].participant02 = -1;
                slavemakerColumPlanningFieldBoxeses[intialTime+i].durationTotal = 0;
                slavemakerColumPlanningFieldBoxeses[intialTime+i].durationRemaining = 0;
            }
        if(participant01 == 2 || participant02 == 2)
            for (int i = 0; i < totalDuration; i++)
            {
                assistantColumPlanningFieldBoxeses[intialTime+i].label.text = "idle";
                assistantColumPlanningFieldBoxeses[intialTime+i].eventName = "idle";
                assistantColumPlanningFieldBoxeses[intialTime+i].participant01 = -1;
                assistantColumPlanningFieldBoxeses[intialTime+i].participant02 = -1;
                assistantColumPlanningFieldBoxeses[intialTime+i].durationTotal = 0;
                assistantColumPlanningFieldBoxeses[intialTime+i].durationRemaining = 0;
            }
        
        
    }

    public void FindPlanningEventAssosciatedToButton(string eventName)
    {
        foreach (var sm4Event in planningEvents)
        {
            if (eventName == sm4Event.eventName)
            {
                SM4EventExecute.instance.ExecuteEvent(sm4Event);
                return;
            }
        }
    }
    

}

public class PlanningActButtonData
{
    public string gameobjectName;

    public string location;
    
    public int characterID;
    public int tab;
    public int subtab;
    public int buttonNumber;
    
    public string label;
    public string hintCode;
    public string planningEvent;
}

public class PlanningActHintData
{
    public string hintCode;
    public string text;
}

public class PlanningActQuestionData
{
    public bool noOptionsHenceContinue = true;
    public SM4Event sm4Event;

}

