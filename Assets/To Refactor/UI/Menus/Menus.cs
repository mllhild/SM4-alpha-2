using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{

    public MenuPlanning menuPlanning;
    public MenuOptions menuOptions;

    public GameObject UIEvent;
    public GameObject NPCOverview;
    public GameObject AssistantOverview;
    public GameObject MinorSlaveOverview;
    public GameObject SlaveOverview;
    public GameObject SMOverview;
    public GameObject HouseManagementMenu;
    public GameObject TalkToSlavesMenu;
    public GameObject RulesMenu;
    public GameObject LendMenu;
    public GameObject MoneyOverview;
    public GameObject ItemManagementMenu;
    public GameObject EquipmentMenu;
    public GameObject CraftingMenu;
    public GameObject CalenderMenu;
    public GameObject VisitMenu;
    public GameObject PlanningMenu;
    public GameObject UISMStats1;
    public GameObject UISMStats2;
    public GameObject UISMStats3;
    public GameObject UISlaveStats1;
    public GameObject UISlaveStats2;
    public GameObject UISlaveStats3;
    public GameObject UIStatScreenButtons;
    public GameObject UIImage1; // central image screen, layer 1 (BG)
    public GameObject UIImage2; // central image screen, layer 2
    public GameObject UIImage3; // central image screen, layer 3
    public GameObject UIImage4; // central image screen, layer 4 (front)
    public GameObject UITopbar; // Bar above central image
    public GameObject UINpcPanel; // Shows NPC you are interacting with
    public GameObject UISuperviserPanel; // Shows who is active superviser
    public GameObject UINotePanel; // for showing small notes
    public GameObject UIDatePanel; // Display date
    public GameObject UIGoldPanel; // Dilplay gold
    public GameObject UIPlanningButton; // Planning Button
    public GameObject UISystemButton; //System Button
    public GameObject UITextBoxEvent; // Standard Text box for events
    public GameObject UIDoPlanningButton; // Starts the execution of plannings

    public GameUI gameUI;

    void Start()
    {

    }
       

    public void HideAllUI()
    {
        HouseManagementMenu.SetActive(false);
        NPCOverview.SetActive(false);
        AssistantOverview.SetActive(false);
        MinorSlaveOverview.SetActive(false);
        SlaveOverview.SetActive(false);
        SMOverview.SetActive(false);
        HouseManagementMenu.SetActive(false);
        TalkToSlavesMenu.SetActive(false);
        LendMenu.SetActive(false);
        MoneyOverview.SetActive(false);
        ItemManagementMenu.SetActive(false);
        EquipmentMenu.SetActive(false);
        CraftingMenu.SetActive(false);
        CalenderMenu.SetActive(false);
        VisitMenu.SetActive(false);
        PlanningMenu.SetActive(false);
        UISMStats1.SetActive(false);
        UISMStats2.SetActive(false);
        UISMStats3.SetActive(false);
        UISlaveStats1.SetActive(false);
        UISlaveStats2.SetActive(false);
        UISlaveStats3.SetActive(false);
        UIStatScreenButtons.SetActive(false);
        UIImage1.SetActive(false);
        UIImage2.SetActive(false);
        UIImage3.SetActive(false);
        UIImage4.SetActive(false);
        UITopbar.SetActive(false); 
        UINpcPanel.SetActive(false);
        UISuperviserPanel.SetActive(false);
        UINotePanel.SetActive(false);
        UIDatePanel.SetActive(false);
        UIGoldPanel.SetActive(false);
        UIPlanningButton.SetActive(false);
        UISystemButton.SetActive(false);
        UITextBoxEvent.SetActive(false);
        UIDoPlanningButton.SetActive(false);
    }


    // ---------------------------------  UI Base Elements------------------------------------
    
    public void HideStats()
    {
        UISlaveStats1.SetActive(false);
        UISlaveStats2.SetActive(false);
        UISlaveStats3.SetActive(false);
        UISMStats1.SetActive(false);
        UISMStats2.SetActive(false);
        UISMStats3.SetActive(false);
    }
    public void ClickSlaveStatButton() //Cycles the slave stats screen
    {
        // if this screen visible, turn off and show this one
        // if none visible, turn on first
        if (UISlaveStats1.activeSelf)
        {
            UISlaveStats1.SetActive(false);
            UISlaveStats2.SetActive(true);
            UISlaveStats3.SetActive(false);
            return;
        }
        if (UISlaveStats2.activeSelf)
        {
            UISlaveStats1.SetActive(false);
            UISlaveStats2.SetActive(false);
            UISlaveStats3.SetActive(true);
            return;
        }
        if (UISlaveStats3.activeSelf)
        {
            UISlaveStats1.SetActive(true);
            UISlaveStats2.SetActive(false);
            UISlaveStats3.SetActive(false);
            return;
        }
        if(UISlaveStats1.activeSelf != true && UISlaveStats2.activeSelf != true && UISlaveStats3.activeSelf != true)
        {
            UISlaveStats1.SetActive(true);
            UISlaveStats2.SetActive(false);
            UISlaveStats3.SetActive(false);
            UISMStats1.SetActive(true);
            UISMStats2.SetActive(false);
            UISMStats3.SetActive(false);
            return;
        }

    }
    public void ClickSMStatButton() //Cycles the SM stats screen
    {
        // if this screen visible, turn off and show this one
        // if none visible, turn on first
        if (UISMStats1.activeSelf)
        {
            UISMStats1.SetActive(false);
            UISMStats2.SetActive(true);
            UISMStats3.SetActive(false);
            return;
        }
        if (UISMStats2.activeSelf)
        {
            UISMStats1.SetActive(false);
            UISMStats2.SetActive(false);
            UISMStats3.SetActive(true);
            return;
        }
        if (UISMStats3.activeSelf)
        {
            UISMStats1.SetActive(true);
            UISMStats2.SetActive(false);
            UISMStats3.SetActive(false);
            return;
        }
        if (UISMStats1.activeSelf != true && UISMStats2.activeSelf != true && UISMStats3.activeSelf != true)
        {
            UISlaveStats1.SetActive(true);
            UISlaveStats2.SetActive(false);
            UISlaveStats3.SetActive(false);
            UISMStats1.SetActive(true);
            UISMStats2.SetActive(false);
            UISMStats3.SetActive(false);
            return;
        }

    }

    public void ShowUIStatScreenButtons() // Shows stat screen buttoms Slave, SM, B3, B4
    {
        UIStatScreenButtons.SetActive(true);
    }
    public void HideUIStatScreenButtons() 
    {
        UIStatScreenButtons.SetActive(false);
    }

    public void ShowUITopbar() // Show central image
    {
        UITopbar.SetActive(true);
    }
    public void HideUITopbar() // Hides central image
    {
        UITopbar.SetActive(false);
    }
    public void ShowUINpcPanel() // Show central image
    {
        UINpcPanel.SetActive(true);
    }
    public void HideUINpcPanel() // Hides central image
    {
        UINpcPanel.SetActive(false);
    }
    public void ShowUISuperviserPanel() // Show central SuperviserPanel
    {
        UISuperviserPanel.SetActive(true);
    }
    public void HideUISuperviserPanel() // Hides central SuperviserPanel
    {
        UISuperviserPanel.SetActive(false);
    }
    public void ShowUINotePanel() // Show central NotePanel
    {
        UINotePanel.SetActive(true);
    }
    public void HideUINotePanel() // Hides central NotePanel
    {
        UINotePanel.SetActive(false);
    }
    public void ShowUIDatePanel() // Show central DatePanel
    {
        UIDatePanel.SetActive(true);
    }
    public void HideUIDatePanel() // Hides central DatePanel
    {
        UIDatePanel.SetActive(false);
    }
    public void ShowUIGoldPanel() // Show central GoldPanel
    {
        UIGoldPanel.SetActive(true);
    }
    public void HideUIGoldPanel() // Hides central GoldPanel
    {
        UIGoldPanel.SetActive(false);
    }
    public void ShowUIPlanningButton() // Show central PlanningButton
    {
        UIPlanningButton.SetActive(true);
    }
    public void HideUIPlanningButton() // Hides central PlanningButton
    {
        UIPlanningButton.SetActive(false);
    }
    public void ShowUIDoPlanningButton() // Show central PlanningButton
    {
        UIDoPlanningButton.SetActive(true);
    }
    public void HideUIDoPlanningButton() // Hides central PlanningButton
    {
        UIDoPlanningButton.SetActive(false);
    }
    public void ShowUISystemButton() // Show central SystemButton
    {
        UISystemButton.SetActive(true);
    }
    public void HideUISystemButton() // Hides central SystemButton
    {
        UISystemButton.SetActive(false);
    }
    public void ShowUIImage1() // Show central UIImage1
    {
        UIImage1.SetActive(true);
    }
    public void HideUIImage1() // Hides central UIImage1
    {
        UIImage1.SetActive(false);
    }
    public void ShowUIImage2() // Show central UIImage2
    {
        UIImage2.SetActive(true);
    }
    public void HideUIImage2() // Hides central UIImage2
    {
        UIImage2.SetActive(false);
    }
    public void ShowUIImage3() // Show central UIImage3
    {
        UIImage3.SetActive(true);
    }
    public void HideUIImage3() // Hides central UIImage3
    {
        UIImage3.SetActive(false);
    }
    public void ShowUIImage4() // Show central UIImage4
    {
        UIImage4.SetActive(true);
    }
    public void HideUIImage4() // Hides central UIImage4
    {
        UIImage4.SetActive(false);
    }
    public void HideUIImageAll() // Hides all central UIImages
    {
        UIImage1.SetActive(false);
        UIImage2.SetActive(false);
        UIImage3.SetActive(false);
        UIImage4.SetActive(false);
    }
    public void ShowUITextBoxEvent() // Show Standard event text box
    {
        UITextBoxEvent.SetActive(true);
    }
    public void HideUITextBoxEvent() // Hides Standard event text box
    {
        UITextBoxEvent.SetActive(false);
    }

    // ---------------------------------- UIEvent ----------------------------------------------------
    public void OpenUIEvent()
    {
        UIEvent.SetActive(true);
    }
    public void CloseUIEvent()
    {
        UIEvent.SetActive(false);
    }
   

    // ---------------------------------- NPCOverview ----------------------------------------------------
    public void OpenNPCOverview()
    {
        NPCOverview.SetActive(true);
    }
    public void CloseNPCOverview()
    {
        NPCOverview.SetActive(false);
    }


    // ---------------------------------- AssistantOverview ----------------------------------------------------
    public void OpenAssistantOverview()
    {
        AssistantOverview.SetActive(true);
    }
    public void CloseAssistantOverview()
    {
        AssistantOverview.SetActive(false);
    }
    // ---------------------------------- MinorSlaveOverview ----------------------------------------------------
    public void OpenMinorSlaveOverview()
    {
        MinorSlaveOverview.SetActive(true);
    }
    public void CloseMinorSlaveOverview()
    {
        MinorSlaveOverview.SetActive(false);
    }

    // ---------------------------------- SlaveOverview ----------------------------------------------------
    public void OpenSlaveOverview()
    {
        SlaveOverview.SetActive(true);
    }
    public void CloseSlaveOverview()
    {
        SlaveOverview.SetActive(false);
    }

    // ---------------------------------- SMOverview ----------------------------------------------------
    public void OpenSMOverview()
    {
        SMOverview.SetActive(true);
    }
    public void CloseSMOverview()
    {
        SMOverview.SetActive(false);
    }

    // ---------------------------------- HouseManagementMenu ----------------------------------------------------
    public void OpenHouseManagementMenu()
    {
        HouseManagementMenu.SetActive(true);
    }
    public void CloseHouseManagementMenu()
    {
        HouseManagementMenu.SetActive(false);
    }

    // ---------------------------------- TalkToSlavesMenu ----------------------------------------------------
    public void OpenTalkToSlavesMenu()
    {
        TalkToSlavesMenu.SetActive(true);
    }
    public void CloseTalkToSlavesMenu()
    {
        TalkToSlavesMenu.SetActive(false);
    }
    // ---------------------------------- Rules Menu ----------------------------------------------------
    public void OpenRulesMenu()
    {
        RulesMenu.SetActive(true);
    }
    public void CloseRulesMenu()
    {
        RulesMenu.SetActive(false);
    }
    // ---------------------------------- LendMenu ----------------------------------------------------
    public void OpenLendMenu()
    {
        LendMenu.SetActive(true);
    }
    public void CloseLendMenu()
    {
        LendMenu.SetActive(false);
    }

    // ---------------------------------- MoneyOverview ----------------------------------------------------
    public void OpenMoneyOverview()
    {
        MoneyOverview.SetActive(true);
    }
    public void CloseMoneyOverview()
    {
        MoneyOverview.SetActive(false);
    }

    // ---------------------------------- ItemManagementMenu ----------------------------------------------------
    public void OpenItemManagementMenu()
    {
        ItemManagementMenu.SetActive(true);
        Debug.LogFormat("hi");
    }
    public void CloseItemManagementMenu()
    {
        ItemManagementMenu.SetActive(false);
    }

    // ---------------------------------- EquipmentMenu ----------------------------------------------------
    public void OpenEquipmentMenu()
    {
        EquipmentMenu.SetActive(true);
        Debug.LogFormat("OpenEquipmentMenu");
    }
    public void CloseEquipmentMenu()
    {
        EquipmentMenu.SetActive(false);
    }

    // ---------------------------------- CraftingMenu ----------------------------------------------------
    public void OpenCraftingMenu()
    {
        CraftingMenu.SetActive(true);
    }
    public void CloseCraftingMenu()
    {
        CraftingMenu.SetActive(false);
    }

    // ---------------------------------- CalenderMenu ----------------------------------------------------
    public void OpenCalenderMenu()
    {
        CalenderMenu.SetActive(true);
    }
    public void CloseCalenderMenu()
    {
        CalenderMenu.SetActive(false);
    }

    // ---------------------------------- VisitMenu ----------------------------------------------------
    public void OpenVisitMenu()
    {
        VisitMenu.SetActive(true);
    }
    public void CloseVisitMenu()
    {
        VisitMenu.SetActive(false);
    }


    // ---------------------------------- PlanningMenu ----------------------------------------------------
    public void OpenPlanningMenu()
    {
        PlanningMenu.SetActive(true);
        menuPlanning.CheckForEvents();
        HideUIImageAll();
        HideUINpcPanel();
        HideUISuperviserPanel();
        HideStats();
        HideUIPlanningButton();
        ShowUIDoPlanningButton();
        menuPlanning.HideALLButtons();
        menuPlanning.ShowButtons();
        //check if there is any thing with time and limits

;
    }
    public void ClosePlanningMenu()
    {
        PlanningMenu.SetActive(false);
    }
    public void DoPlanning()
    {
        PlanningMenu.SetActive(false);
    }



    // ----------------------------------  ----------------------------------------------------
    public int date;
    public int year;
    public void StartNewGame()
    {
        date = 0;
        year = 1234;
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        Debug.Log("date: " + date + "  " + "year: " + year);

    }
}


//// ---------------------------------- Event UI Funciton ----------------------------------------------------

//public void UIf_NPC()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//    OpenNPCOverview();
//}
//public void UIf_Character()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_Date()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//    OpenCalenderMenu();
//}
//public void UIf_Reminder() // field below gold
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_Gold()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//    OpenMoneyOverview();
//}
//public void UIf_topbar()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_Image()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_Textbox()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}

//public void UIf_FieldLarge()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_FieldDouble_1()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_FieldDouble_2()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_Slave()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_SM()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_B1()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_B2()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_B3()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_Planning()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}
//public void UIf_Next()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//    Debug.Log("9999");
//}
//public void UIf_System()
//{
//    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
//}


