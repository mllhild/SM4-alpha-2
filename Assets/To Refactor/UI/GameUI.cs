using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public World world;
    public Popups popups;
    public FloatingFields floatingFields;
    //public EventListener eventListener;

    //public SlaveMaker sm;
    //public Slave slave;
    //public Assistant assistant;

    //prefabs
    //public Statsbar statsbar;
    public Image background;

    // Left collum
    // NPC panel
    public Image npcBG;
    public Image npcPortrait;
    public Image npcNameBG;
    public TextMeshProUGUI npcName;


    // superviser panel
    public Image spBG;
    public Image spPortrait;
    public Image spNameBG;
    public TextMeshProUGUI spName;

    // Assistant house panel
    public Image assistantBG;
    public Image assistantPortrait;
    public Image assistantNameBG;
    public TextMeshProUGUI assistantName;

    // SM House panel
    public Image smBG;
    public Image smPortrait;
    public Image smNameBG;
    public TextMeshProUGUI smName;

    // Note panel
    public Image notebg;
    public TextMeshProUGUI noteText;

    // Date panel
    public Image datebg;
    public TextMeshProUGUI dateText;
    public Image moonFase;
    public TextMeshProUGUI moonFaseName;

    // Gold panel
    public Image goldbg;
    public Image goldIcon;
    public TextMeshProUGUI goldText;

    // Middle Collum
    // opaque black border in house management screen
    public GameObject opaqueBorder;

    // Top bar
    public Image topBarBG;
    public TopIcons topBarIcons;
    public TextMeshProUGUI topBarText;

    // Image window
    public GameObject imageFolder;
    public Image imageBG;
    public Image imageL1;
    public Image imageL2;
    public Image imageL3;
    public Image imageL4;
    public Image imageL5;

    // Planning Act Panels
    public GameObject allPanels;
    public PlanningActPannel actPannel1;
    public PlanningActPannel actPannel2;
    public PlanningActPannel actPannel3;
    public PlanningActPannel actPannel4;
    public PlanningActPannel actPannel5;

    // Planning Field
    public PlanningField planningField;


    // TextMeshProUGUI Panel
    public Image textBoxBG;
    public TextMeshProUGUI textBox;

    // Lend Area
    public LendArea lendArea;

    // Item Menu
    public ItemMenu itemMenu;

    // Equipment
    public EquipmentMenu equipmentMenu;

    // Crafting
    public CraftingMenu craftingMenu;

    // Rules
    public RulesMenu rulesMenu;


    // Right Collum

    // House sub Menu
    public HouseMenuBar houseMenuBar;



    // Statscreen Events Fields
    //public List<Statsbar> statsbarCollumn = new List<Statsbar>(20);
    //public Statsbar[] statsbarsAssistant = new Statsbar[20];
    public statsPanel statsSlave;
    public statsPanel statsSM;
    
    public statsPanel statsAssistant;


    // B1 Button (Slave)
    public Button ButtonB1;
    public TextMeshProUGUI ButtonB1Text;
    // B2 Button (SM)
    public Button ButtonB2;
    public TextMeshProUGUI ButtonB2Text;
    // B3 Button
    public Button ButtonB3;
    public TextMeshProUGUI ButtonB3Text;
    // B4 Button
    public Button ButtonB4;
    public TextMeshProUGUI ButtonB4Text;




    // Next Button
    public Button ButtonNext;
    public TextMeshProUGUI ButtonNextText;

    // Planning Button
    public Button ButtonPlanning;
    public TextMeshProUGUI ButtonPlanningText;

    // Planning Button
    public Button ButtonDoPlanning;
    public TextMeshProUGUI ButtonDoPlanningText;

    // System Icon
    public Button ButtonSettings;



    public void TextboxSet(string text)
    {
        TSet(text);
    }
    public void TSet(string text)
    {
        textBox.text = text;
    }
    public void TAdd(string text)
    {
        textBox.text = textBox.text + text;
    }
    public void TBlancLine()
    {
        TAdd("\n\n");
    }
    public void TSpeak(string name,string text)
    {
        TAdd("\n \n" + name + ": \u0022" + text + "\u0022 \n \n");
    }

    public void HideAll()
    {
        background.gameObject.SetActive(false);

        npcBG.gameObject.SetActive(false);
        npcPortrait.gameObject.SetActive(false);
        npcNameBG.gameObject.SetActive(false);
        npcName.gameObject.SetActive(false);

        spBG.gameObject.SetActive(false);
        spPortrait.gameObject.SetActive(false);
        spNameBG.gameObject.SetActive(false);
        spName.gameObject.SetActive(false);

        assistantBG.gameObject.SetActive(false);
        assistantPortrait.gameObject.SetActive(false);
        assistantNameBG.gameObject.SetActive(false);
        assistantName.gameObject.SetActive(false);

        smBG.gameObject.SetActive(false);
        smPortrait.gameObject.SetActive(false);
        smNameBG.gameObject.SetActive(false);
        smName.gameObject.SetActive(false);

        notebg.gameObject.SetActive(false);
        noteText.gameObject.SetActive(false);

        datebg.gameObject.SetActive(false);
        dateText.gameObject.SetActive(false);
        moonFase.gameObject.SetActive(false);
        moonFaseName.gameObject.SetActive(false);

        goldbg.gameObject.SetActive(false);
        goldIcon.gameObject.SetActive(false);
        goldText.gameObject.SetActive(false);

        opaqueBorder.SetActive(false);

        topBarBG.gameObject.SetActive(false);
        topBarIcons.gameObject.SetActive(false);
        topBarText.gameObject.SetActive(false);

        imageFolder.SetActive(false);
        //imageBG.gameObject.SetActive(false);
        //imageL1.gameObject.SetActive(false);
        //imageL2.gameObject.SetActive(false);
        //imageL3.gameObject.SetActive(false);
        //imageL4.gameObject.SetActive(false);
        //imageL5.gameObject.SetActive(false);

        allPanels.SetActive(false);
        //actPannel1.gameObject.SetActive(false);
        //actPannel2.gameObject.SetActive(false);
        //actPannel3.gameObject.SetActive(false);
        //actPannel4.gameObject.SetActive(false);
        //actPannel5.gameObject.SetActive(false);

        planningField.gameObject.SetActive(false);

        textBoxBG.gameObject.SetActive(false);
        textBox.gameObject.SetActive(false);

        lendArea.gameObject.SetActive(false);
        itemMenu.gameObject.SetActive(false);
        equipmentMenu.gameObject.SetActive(false);
        craftingMenu.gameObject.SetActive(false);
        rulesMenu.gameObject.SetActive(false);
        houseMenuBar.gameObject.SetActive(false);

        statsSlave.gameObject.SetActive(false);
        statsSM.gameObject.SetActive(false);
        statsAssistant.gameObject.SetActive(false);

        ButtonB1.gameObject.SetActive(false);
        //ButtonB1Text.gameObject.SetActive(false);
        ButtonB2.gameObject.SetActive(false);
        //ButtonB2Text.gameObject.SetActive(false);
        ButtonB3.gameObject.SetActive(false);
        //ButtonB3Text.gameObject.SetActive(false);
        ButtonB4.gameObject.SetActive(false);
        //ButtonB4Text.gameObject.SetActive(false);

        ButtonNext.gameObject.SetActive(false);
        //ButtonNextText.gameObject.SetActive(false);
        ButtonPlanning.gameObject.SetActive(false);
        //ButtonPlanningText.gameObject.SetActive(false);
        ButtonDoPlanning.gameObject.SetActive(false);
        //ButtonDoPlanningText.gameObject.SetActive(false);

        ButtonSettings.gameObject.SetActive(false);
    }
    public void ShowBase()
    {
        world.listen = false; // stops event listener from running on
        background.gameObject.SetActive(true);
        ButtonSettings.gameObject.SetActive(true);
        GoldUIShow();
        DateUIShow();
        NoteUIShow();
        topBarBG.gameObject.SetActive(true);
        topBarIcons.gameObject.SetActive(true);
        topBarText.gameObject.SetActive(true);

        textBoxBG.gameObject.SetActive(true);
        textBox.gameObject.SetActive(true);
    }
    public void ShowBaseEvent()
    {
        world.listen = false; // stops event listener from running on
        background.gameObject.SetActive(true);
        ButtonSettings.gameObject.SetActive(true);

        Portrait02Show(); // shows portraits on the left. They need ot be made into prefabs and fitted into a grid
        Portrait01Show();

        statsSlave.gameObject.SetActive(true);
        //slave.panel.HidePlusMinusIcons();

        statsSM.gameObject.SetActive(true);
        //sm.panel.HidePlusMinusIcons(); // hides the icons of the stat changes

        ImagesShow();


        GoldUIShow();
        DateUIShow();
        NoteUIShow();
        topBarBG.gameObject.SetActive(true);
        topBarIcons.gameObject.SetActive(true);
        topBarText.gameObject.SetActive(true);

        textBoxBG.gameObject.SetActive(true);
        textBox.gameObject.SetActive(true);
    }
    public void GoldUIShow()
    {
        goldbg.gameObject.SetActive(true);
        goldIcon.gameObject.SetActive(true);
        goldText.gameObject.SetActive(true);
    }
    public void GoldUIHide()
    {
        goldbg.gameObject.SetActive(false);
        goldIcon.gameObject.SetActive(false);
        goldText.gameObject.SetActive(false);
    }
    public void GoldUpdate(int gold)
    {
        //sm.gold += gold;
        //goldText.text = sm.gold.ToString();
        //if(sm.gold < 0)
        //{
        //    goldText.text = "<color=red>" + sm.gold.ToString() + "</color>";
        //}
    }
        
    public void DateUIShow()
    {
        datebg.gameObject.SetActive(true);
        dateText.gameObject.SetActive(true);
        moonFase.gameObject.SetActive(true);
        moonFaseName.gameObject.SetActive(true);
    }
    public void DateUIHide()
    {
        datebg.gameObject.SetActive(false);
        dateText.gameObject.SetActive(false);
        moonFase.gameObject.SetActive(false);
        moonFaseName.gameObject.SetActive(false);
    }
    public void NoteUIShow()
    {
        notebg.gameObject.SetActive(true);
        noteText.gameObject.SetActive(true);
    }
    public void NoteUIHide()
    {
        notebg.gameObject.SetActive(false);
        noteText.gameObject.SetActive(false);
    }
    public void PlanningMenuShow()
    {
        HideAll();
        ShowBase();
        planningField.UpdatefieldUIDay();
        if (world.turn < 180)
        {
            TSet("Planning for the Day");
        }
        else
        {
            TSet("Planning for the Night");
        }
        

        planningField.withWho = 1;
        planningField.fieldID = 0;
        planningField.hour = 8;
        if (planningField.hour != world.hour) // correct for delayed event start
        {
            planningField.hour = world.hour;
            planningField.fieldID = planningField.hour - 10; // night actions
            // day actions
            if (planningField.hour < 18) { planningField.fieldID = planningField.hour - 10; } // 4 to 7
            if (planningField.hour < 12) { planningField.fieldID = planningField.hour - 8; } // 0 to 3
        }

        
        //ButtonB1.gameObject.SetActive(true);
        //ButtonB1Text.gameObject.SetActive(true);
        //ButtonB2.gameObject.SetActive(true);
        //ButtonB2Text.gameObject.SetActive(true);
        //ButtonB3.gameObject.SetActive(true);
        //ButtonB3Text.gameObject.SetActive(true);
        //ButtonB4.gameObject.SetActive(true);
        //ButtonB4Text.gameObject.SetActive(true);


        allPanels.SetActive(true);
        actPannel1.gameObject.SetActive(true);
        actPannel2.gameObject.SetActive(true);
        actPannel3.gameObject.SetActive(true);
        actPannel4.gameObject.SetActive(true);
        actPannel5.gameObject.SetActive(true);

        planningField.gameObject.SetActive(true);
        ButtonDoPlanning.gameObject.SetActive(true);
        ButtonDoPlanningText.gameObject.SetActive(true);
    }
    public void PlanningMenuHide()
    {
        ButtonB1.gameObject.SetActive(false);
        ButtonB1Text.gameObject.SetActive(false);
        ButtonB2.gameObject.SetActive(false);
        ButtonB2Text.gameObject.SetActive(false);
        ButtonB3.gameObject.SetActive(false);
        ButtonB3Text.gameObject.SetActive(false);
        ButtonB4.gameObject.SetActive(false);
        ButtonB4Text.gameObject.SetActive(false);

        allPanels.SetActive(false);
        actPannel1.gameObject.SetActive(false);
        actPannel2.gameObject.SetActive(false);
        actPannel3.gameObject.SetActive(false);
        actPannel4.gameObject.SetActive(false);
        actPannel5.gameObject.SetActive(false);

        planningField.gameObject.SetActive(false);
        ButtonDoPlanning.gameObject.SetActive(false);
    }
    public void EventScreenShow()
    {
        ShowBase();

        npcBG.gameObject.SetActive(true);
        npcPortrait.gameObject.SetActive(true);
        npcNameBG.gameObject.SetActive(true);
        npcName.gameObject.SetActive(true);

        spBG.gameObject.SetActive(true);
        spPortrait.gameObject.SetActive(true);
        spNameBG.gameObject.SetActive(true);
        spName.gameObject.SetActive(true);

        statsSlave.gameObject.SetActive(true);
        statsSM.gameObject.SetActive(true);
        statsAssistant.gameObject.SetActive(true);
    }
    public void EventScreenHide()
    {
        npcBG.gameObject.SetActive(false);
        npcPortrait.gameObject.SetActive(false);
        npcNameBG.gameObject.SetActive(false);
        npcName.gameObject.SetActive(false);

        spBG.gameObject.SetActive(false);
        spPortrait.gameObject.SetActive(false);
        spNameBG.gameObject.SetActive(false);
        spName.gameObject.SetActive(false);

        statsSlave.gameObject.SetActive(false);
        statsSM.gameObject.SetActive(false);
        statsAssistant.gameObject.SetActive(false);
    }
    public void Portrait02Show()
    {
        spBG.gameObject.SetActive(true);
        spPortrait.gameObject.SetActive(true);
        spNameBG.gameObject.SetActive(true);
        spName.gameObject.SetActive(true);
        //spName.text = sm.name1 + " " + sm.familyname;
    }
    public void Portrait02Hide()
    {
        spBG.gameObject.SetActive(false);
        spPortrait.gameObject.SetActive(false);
        spNameBG.gameObject.SetActive(false);
        spName.gameObject.SetActive(false);
        
    }
    public void Portrait01Show()
    {
        npcBG.gameObject.SetActive(true);
        npcPortrait.gameObject.SetActive(true);
        npcNameBG.gameObject.SetActive(true);
        npcName.gameObject.SetActive(true);
        //npcName.text = slave.name1;
    }
    public void Portrait01Hide()
    {
        npcBG.gameObject.SetActive(false);
        npcPortrait.gameObject.SetActive(false);
        npcNameBG.gameObject.SetActive(false);
        npcName.gameObject.SetActive(false);
    }
    

        
    public void PortraitSMShow()
    {
        smBG.gameObject.SetActive(true);
        smPortrait.gameObject.SetActive(true);
        smNameBG.gameObject.SetActive(true);
        smName.gameObject.SetActive(true);
    }
    public void PortraitSMHide()
    {
        smBG.gameObject.SetActive(false);
        smPortrait.gameObject.SetActive(false);
        smNameBG.gameObject.SetActive(false);
        smName.gameObject.SetActive(false);
    }
    public void PortraitAssistantShow()
    {
        assistantBG.gameObject.SetActive(true);
        assistantPortrait.gameObject.SetActive(true);
        assistantNameBG.gameObject.SetActive(true);
        assistantName.gameObject.SetActive(true);
    }
    public void PortraitAssistantHide()
    {
        assistantBG.gameObject.SetActive(false);
        assistantPortrait.gameObject.SetActive(false);
        assistantNameBG.gameObject.SetActive(false);
        assistantName.gameObject.SetActive(false);
    }

    public void HouseMenuShow()
    {
        //PortraitAssistantShow();
        //PortraitSMShow();
        Portrait01Show();
        Portrait02Show();
        houseMenuBar.gameObject.SetActive(true);
        
        //ButtonPlanning.gameObject.SetActive(true);
        //ButtonPlanningText.gameObject.SetActive(true);

    }
    public void HouseMenuHide()
    {
        houseMenuBar.gameObject.SetActive(false);
        ButtonDoPlanning.gameObject.SetActive(false);
    }
    public void ItemMenuShow()
    {
        itemMenu.gameObject.SetActive(true);
    }
    public void ItemMenuHide()
    {
        itemMenu.gameObject.SetActive(false);
    }
    public void CraftingMenuShow()
    {
        craftingMenu.gameObject.SetActive(true);
        ItemMenuShow();
    }
    public void CraftingMenuHide()
    {
        craftingMenu.gameObject.SetActive(false);
    }
    public void EquipmentMenuShow()
    {
        equipmentMenu.gameObject.SetActive(true);
        ItemMenuShow();
    }
    public void EquipmentMenuHide()
    {
        equipmentMenu.gameObject.SetActive(false);
    }
    public void RulesMenuShow()
    {
        rulesMenu.gameObject.SetActive(true);
    }
    public void RulesMenuHide()
    {
        rulesMenu.gameObject.SetActive(false);
    }
    public void LendMenuShow()
    {
        lendArea.gameObject.SetActive(true);
    }
    public void LendMenuHide()
    {
        lendArea.gameObject.SetActive(false);
    }

    public void HouseMenusHideAll()
    {
        lendArea.gameObject.SetActive(false);
        itemMenu.gameObject.SetActive(false);
        equipmentMenu.gameObject.SetActive(false);
        craftingMenu.gameObject.SetActive(false);
        rulesMenu.gameObject.SetActive(false);
    }
    public void ImagesShow()
    {
        imageFolder.SetActive(true);
        if (imageBG.sprite != null) {imageBG.gameObject.SetActive(true); }
        if (imageL1.sprite != null) { imageL1.gameObject.SetActive(true);}
        if (imageL2.sprite != null) { imageL2.gameObject.SetActive(true);}
        if (imageL3.sprite != null) { imageL3.gameObject.SetActive(true);}
        if (imageL4.sprite != null) { imageL4.gameObject.SetActive(true);}
        if (imageL5.sprite != null) { imageL5.gameObject.SetActive(true);}
    }
    public void ImagesHide()
    {
        imageFolder.SetActive(false);
        imageBG.gameObject.SetActive(false);
        imageL1.gameObject.SetActive(false);
        imageL2.gameObject.SetActive(false);
        imageL3.gameObject.SetActive(false);
        imageL4.gameObject.SetActive(false);
        imageL5.gameObject.SetActive(false);
    }

    public void UpdateClock(int turn)
    {
        int hour = turn / 10;
        // Date panel
        //public Image datebg;
        //public TextMeshProUGUI dateText;
        //public Image moonFase;
        //public TextMeshProUGUI moonFaseName;
        string newDate = world.year.ToString() + "/" + world.month.ToString() + "/" + world.day.ToString();
        string newClock = hour.ToString() + ":00";
        dateText.text = newDate + "\n" + newClock;
    }

    public void BPlanning(bool state, string text)
    {
        ButtonPlanning.gameObject.SetActive(state);
        ButtonPlanningText.text = text;
    }
    public void BNext(bool state, string text) // sets next event number as 0
    {
        ButtonNext.gameObject.SetActive(state);
        ButtonNextText.text = text;
        world.nextEventNumber = 0;
    }
    public void BNext(bool state, string text, int nextEventNumber)
    {
        if(world.nextEventNumber == nextEventNumber) // to prevent loops if people dont reset it
        {
            nextEventNumber = 0;
        }
        world.nextEventNumber = nextEventNumber;
        ButtonNext.gameObject.SetActive(state);
        ButtonNextText.text = text;
    }

    //public int BNextEventNumber;
    //public void BNextEventSet(int eventNumber)
    //{
    //    BNextEventNumber = eventNumber;
    //}
    //public void BNextEventCall()
    //{
    //    if (BNextEventNumber == 9999) // call for normal end
    //    {
    //        world.RunTime();
    //        return;
    //    }
    //    if (BNextEventNumber == 9998) // call if in planning acts
    //    {
    //        eventListener.doPlanning.FindFirstField();
    //        return;
    //    }
    //    // DoEvent(BNextEventNumber) once an index exists
    //    Debug.LogFormat("BNextEvent got a unspecified eventNumber: {0}", BNextEventNumber);
    //    world.RunTime();
    //    return;
    //}


    public void ShowImage(string pathToImage, int layer)
    {
        switch (layer) // higher number means in front
        {
            case 0: // Background small
                imageBG.sprite = Resources.Load<Sprite>(pathToImage);
                imageBG.gameObject.SetActive(true);
                break;
            case 1: // Layer 1
                imageL1.sprite = Resources.Load<Sprite>(pathToImage);
                imageL1.gameObject.SetActive(true);
                break;
            case 2: // Layer 2
                imageL2.sprite = Resources.Load<Sprite>(pathToImage);
                imageL2.gameObject.SetActive(true);
                break;
            case 3: // Layer 3
                imageL3.sprite = Resources.Load<Sprite>(pathToImage);
                imageL3.gameObject.SetActive(true);
                break;
            case 4: // Layer 4
                imageL4.sprite = Resources.Load<Sprite>(pathToImage);
                imageL4.gameObject.SetActive(true);
                break;
            case 5: // Layer 5
                imageL5.sprite = Resources.Load<Sprite>(pathToImage);
                imageL5.gameObject.SetActive(true);
                break;

            default:
                Debug.LogFormat("Number for Layer received was {0}, outside of range of 0(BG) to 5 ", layer);
                break;
        }
        
    }
}
