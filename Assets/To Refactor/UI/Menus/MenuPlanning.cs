using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuPlanning : MonoBehaviour
{

    // buttons for acts
    public GameObject ButtonPlanningCol1Row1;
    public GameObject ButtonPlanningCol1Row2;
    public GameObject ButtonPlanningCol1Row3;
    public GameObject ButtonPlanningCol1Row4;
    public GameObject ButtonPlanningCol1Row5;
    public GameObject ButtonPlanningCol1Row6;
    public GameObject ButtonPlanningCol1Row7;
    public GameObject ButtonPlanningCol1Row8;
    public GameObject ButtonPlanningCol1Row9;
    public GameObject ButtonPlanningCol1Row10;
    public GameObject ButtonPlanningCol2Row1;
    public GameObject ButtonPlanningCol2Row2;
    public GameObject ButtonPlanningCol2Row3;
    public GameObject ButtonPlanningCol2Row4;
    public GameObject ButtonPlanningCol2Row5;
    public GameObject ButtonPlanningCol2Row6;
    public GameObject ButtonPlanningCol2Row7;
    public GameObject ButtonPlanningCol2Row8;
    public GameObject ButtonPlanningCol2Row9;
    public GameObject ButtonPlanningCol2Row10;
    public GameObject ButtonPlanningCol3Row1;
    public GameObject ButtonPlanningCol3Row2;
    public GameObject ButtonPlanningCol3Row3;
    public GameObject ButtonPlanningCol3Row4;
    public GameObject ButtonPlanningCol3Row5;
    public GameObject ButtonPlanningCol3Row6;
    public GameObject ButtonPlanningCol3Row7;
    public GameObject ButtonPlanningCol3Row8;
    public GameObject ButtonPlanningCol3Row9;
    public GameObject ButtonPlanningCol3Row10;
    public GameObject ButtonPlanningCol4Row1;
    public GameObject ButtonPlanningCol4Row2;
    public GameObject ButtonPlanningCol4Row3;
    public GameObject ButtonPlanningCol4Row4;
    public GameObject ButtonPlanningCol4Row5;
    public GameObject ButtonPlanningCol4Row6;
    public GameObject ButtonPlanningCol4Row7;
    public GameObject ButtonPlanningCol4Row8;
    public GameObject ButtonPlanningCol4Row9;
    public GameObject ButtonPlanningCol4Row10;
    public GameObject ButtonPlanningCol5Row1;
    public GameObject ButtonPlanningCol5Row2;
    public GameObject ButtonPlanningCol5Row3;
    public GameObject ButtonPlanningCol5Row4;
    public GameObject ButtonPlanningCol5Row5;
    public GameObject ButtonPlanningCol5Row6;
    public GameObject ButtonPlanningCol5Row7;
    public GameObject ButtonPlanningCol5Row8;
    public GameObject ButtonPlanningCol5Row9;
    public GameObject ButtonPlanningCol5Row10;


    // text of the buttons for acts
    public Text ButtonPlanningCol1Row1Text;
    public Text ButtonPlanningCol1Row2Text;
    public Text ButtonPlanningCol1Row3Text;
    public Text ButtonPlanningCol1Row4Text;
    public Text ButtonPlanningCol1Row5Text;
    public Text ButtonPlanningCol1Row6Text;
    public Text ButtonPlanningCol1Row7Text;
    public Text ButtonPlanningCol1Row8Text;
    public Text ButtonPlanningCol1Row9Text;
    public Text ButtonPlanningCol1Row10Text;
    public Text ButtonPlanningCol2Row1Text;
    public Text ButtonPlanningCol2Row2Text;
    public Text ButtonPlanningCol2Row3Text;
    public Text ButtonPlanningCol2Row4Text;
    public Text ButtonPlanningCol2Row5Text;
    public Text ButtonPlanningCol2Row6Text;
    public Text ButtonPlanningCol2Row7Text;
    public Text ButtonPlanningCol2Row8Text;
    public Text ButtonPlanningCol2Row9Text;
    public Text ButtonPlanningCol2Row10Text;
    public Text ButtonPlanningCol3Row1Text;
    public Text ButtonPlanningCol3Row2Text;
    public Text ButtonPlanningCol3Row3Text;
    public Text ButtonPlanningCol3Row4Text;
    public Text ButtonPlanningCol3Row5Text;
    public Text ButtonPlanningCol3Row6Text;
    public Text ButtonPlanningCol3Row7Text;
    public Text ButtonPlanningCol3Row8Text;
    public Text ButtonPlanningCol3Row9Text;
    public Text ButtonPlanningCol3Row10Text;
    public Text ButtonPlanningCol4Row1Text;
    public Text ButtonPlanningCol4Row2Text;
    public Text ButtonPlanningCol4Row3Text;
    public Text ButtonPlanningCol4Row4Text;
    public Text ButtonPlanningCol4Row5Text;
    public Text ButtonPlanningCol4Row6Text;
    public Text ButtonPlanningCol4Row7Text;
    public Text ButtonPlanningCol4Row8Text;
    public Text ButtonPlanningCol4Row9Text;
    public Text ButtonPlanningCol4Row10Text;
    public Text ButtonPlanningCol5Row1Text;
    public Text ButtonPlanningCol5Row2Text;
    public Text ButtonPlanningCol5Row3Text;
    public Text ButtonPlanningCol5Row4Text;
    public Text ButtonPlanningCol5Row5Text;
    public Text ButtonPlanningCol5Row6Text;
    public Text ButtonPlanningCol5Row7Text;
    public Text ButtonPlanningCol5Row8Text;
    public Text ButtonPlanningCol5Row9Text;
    public Text ButtonPlanningCol5Row10Text;


    // planning fields
    public GameObject ButtonPlanningListCol1Row1;
    public GameObject ButtonPlanningListCol1Row2;
    public GameObject ButtonPlanningListCol1Row3;
    public GameObject ButtonPlanningListCol1Row4;
    public GameObject ButtonPlanningListCol1Row5;
    public GameObject ButtonPlanningListCol1Row6;
    public GameObject ButtonPlanningListCol1Row7;
    public GameObject ButtonPlanningListCol1Row8;

    public GameObject ButtonPlanningListCol2Row1;
    public GameObject ButtonPlanningListCol2Row2;
    public GameObject ButtonPlanningListCol2Row3;
    public GameObject ButtonPlanningListCol2Row4;
    public GameObject ButtonPlanningListCol2Row5;
    public GameObject ButtonPlanningListCol2Row6;
    public GameObject ButtonPlanningListCol2Row7;
    public GameObject ButtonPlanningListCol2Row8;

    public GameObject ButtonPlanningListCol3Row1;
    public GameObject ButtonPlanningListCol3Row2;
    public GameObject ButtonPlanningListCol3Row3;
    public GameObject ButtonPlanningListCol3Row4;
    public GameObject ButtonPlanningListCol3Row5;
    public GameObject ButtonPlanningListCol3Row6;
    public GameObject ButtonPlanningListCol3Row7;
    public GameObject ButtonPlanningListCol3Row8;

    // text of the buttons for acts
    public Text ButtonPlanningListCol1Row1Text;
    public Text ButtonPlanningListCol1Row2Text;
    public Text ButtonPlanningListCol1Row3Text;
    public Text ButtonPlanningListCol1Row4Text;
    public Text ButtonPlanningListCol1Row5Text;
    public Text ButtonPlanningListCol1Row6Text;
    public Text ButtonPlanningListCol1Row7Text;
    public Text ButtonPlanningListCol1Row8Text;

    public Text ButtonPlanningListCol2Row1Text;
    public Text ButtonPlanningListCol2Row2Text;
    public Text ButtonPlanningListCol2Row3Text;
    public Text ButtonPlanningListCol2Row4Text;
    public Text ButtonPlanningListCol2Row5Text;
    public Text ButtonPlanningListCol2Row6Text;
    public Text ButtonPlanningListCol2Row7Text;
    public Text ButtonPlanningListCol2Row8Text;

    public Text ButtonPlanningListCol3Row1Text;
    public Text ButtonPlanningListCol3Row2Text;
    public Text ButtonPlanningListCol3Row3Text;
    public Text ButtonPlanningListCol3Row4Text;
    public Text ButtonPlanningListCol3Row5Text;
    public Text ButtonPlanningListCol3Row6Text;
    public Text ButtonPlanningListCol3Row7Text;
    public Text ButtonPlanningListCol3Row8Text;


    // variables for control
    public bool IsSlaveInTraining;  // Are you training a slave?
    public bool IsSlaveAviable;     // Is your slave there for training? Stolen, Escaped = false
    public int Superviser;          // 0 = No One, 1 = SM, 2 = Assistant, 3 = reserve
    public int PlanningColumn;      // what column is selected in the planing screen
    public int PlanningRow;         // what row is selected in the planing screen
    public int[,] PlanningList = new int[3, 8]; // Column 0 Slave, 1 SM, 2 Assistant

    public int KeyPress01;        // for our two stage shortkey select
    public int KeyPress02;        // for our two stage shortkey select



    public void HideALLButtons()
    {
        ButtonPlanningCol1Row1.SetActive(false);
        ButtonPlanningCol1Row2.SetActive(false);
        ButtonPlanningCol1Row3.SetActive(false);
        ButtonPlanningCol1Row4.SetActive(false);
        ButtonPlanningCol1Row5.SetActive(false);
        ButtonPlanningCol1Row6.SetActive(false);
        ButtonPlanningCol1Row7.SetActive(false);
        ButtonPlanningCol1Row8.SetActive(false);
        ButtonPlanningCol1Row9.SetActive(false);
        ButtonPlanningCol1Row10.SetActive(false);
        ButtonPlanningCol2Row1.SetActive(false);
        ButtonPlanningCol2Row2.SetActive(false);
        ButtonPlanningCol2Row3.SetActive(false);
        ButtonPlanningCol2Row4.SetActive(false);
        ButtonPlanningCol2Row5.SetActive(false);
        ButtonPlanningCol2Row6.SetActive(false);
        ButtonPlanningCol2Row7.SetActive(false);
        ButtonPlanningCol2Row8.SetActive(false);
        ButtonPlanningCol2Row9.SetActive(false);
        ButtonPlanningCol2Row10.SetActive(false);
        ButtonPlanningCol3Row1.SetActive(false);
        ButtonPlanningCol3Row2.SetActive(false);
        ButtonPlanningCol3Row3.SetActive(false);
        ButtonPlanningCol3Row4.SetActive(false);
        ButtonPlanningCol3Row5.SetActive(false);
        ButtonPlanningCol3Row6.SetActive(false);
        ButtonPlanningCol3Row7.SetActive(false);
        ButtonPlanningCol3Row8.SetActive(false);
        ButtonPlanningCol3Row9.SetActive(false);
        ButtonPlanningCol3Row10.SetActive(false);
        ButtonPlanningCol4Row1.SetActive(false);
        ButtonPlanningCol4Row2.SetActive(false);
        ButtonPlanningCol4Row3.SetActive(false);
        ButtonPlanningCol4Row4.SetActive(false);
        ButtonPlanningCol4Row5.SetActive(false);
        ButtonPlanningCol4Row6.SetActive(false);
        ButtonPlanningCol4Row7.SetActive(false);
        ButtonPlanningCol4Row8.SetActive(false);
        ButtonPlanningCol4Row9.SetActive(false);
        ButtonPlanningCol4Row10.SetActive(false);
        ButtonPlanningCol5Row1.SetActive(false);
        ButtonPlanningCol5Row2.SetActive(false);
        ButtonPlanningCol5Row3.SetActive(false);
        ButtonPlanningCol5Row4.SetActive(false);
        ButtonPlanningCol5Row5.SetActive(false);
        ButtonPlanningCol5Row6.SetActive(false);
        ButtonPlanningCol5Row7.SetActive(false);
        ButtonPlanningCol5Row8.SetActive(false);
        ButtonPlanningCol5Row9.SetActive(false);
        ButtonPlanningCol5Row10.SetActive(false);
    }

    public void ShowButtons() // suposed to check what buttons it should show, but at the moment it doesnt
    {
        ButtonPlanningCol1Row1.SetActive(true);
        ButtonPlanningCol1Row2.SetActive(true);
        ButtonPlanningCol1Row3.SetActive(true);
        ButtonPlanningCol1Row4.SetActive(true);
        ButtonPlanningCol1Row5.SetActive(true);
        ButtonPlanningCol1Row6.SetActive(true);
        ButtonPlanningCol1Row7.SetActive(true);
        ButtonPlanningCol1Row8.SetActive(true);
        ButtonPlanningCol1Row9.SetActive(true);
        ButtonPlanningCol1Row10.SetActive(true);
        ButtonPlanningCol2Row1.SetActive(true);
        ButtonPlanningCol2Row2.SetActive(true);
        ButtonPlanningCol2Row3.SetActive(true);
        ButtonPlanningCol2Row4.SetActive(true);
        ButtonPlanningCol2Row5.SetActive(true);
        ButtonPlanningCol2Row6.SetActive(true);
        ButtonPlanningCol2Row7.SetActive(true);
        ButtonPlanningCol2Row8.SetActive(true);
        ButtonPlanningCol2Row9.SetActive(true);
        ButtonPlanningCol2Row10.SetActive(true);
        ButtonPlanningCol3Row1.SetActive(true);
        ButtonPlanningCol3Row2.SetActive(true);
        ButtonPlanningCol3Row3.SetActive(true);
        ButtonPlanningCol3Row4.SetActive(true);
        ButtonPlanningCol3Row5.SetActive(true);
        ButtonPlanningCol3Row6.SetActive(true);
        ButtonPlanningCol3Row7.SetActive(true);
        ButtonPlanningCol3Row8.SetActive(true);
        ButtonPlanningCol3Row9.SetActive(true);
        ButtonPlanningCol3Row10.SetActive(true);
        ButtonPlanningCol4Row1.SetActive(true);
        ButtonPlanningCol4Row2.SetActive(true);
        ButtonPlanningCol4Row3.SetActive(true);
        ButtonPlanningCol4Row4.SetActive(true);
        ButtonPlanningCol4Row5.SetActive(true);
        ButtonPlanningCol4Row6.SetActive(true);
        ButtonPlanningCol4Row7.SetActive(true);
        ButtonPlanningCol4Row8.SetActive(true);
        ButtonPlanningCol4Row9.SetActive(true);
        ButtonPlanningCol4Row10.SetActive(true);
        ButtonPlanningCol5Row1.SetActive(true);
        ButtonPlanningCol5Row2.SetActive(true);
        ButtonPlanningCol5Row3.SetActive(true);
        ButtonPlanningCol5Row4.SetActive(true);
        ButtonPlanningCol5Row5.SetActive(true);
        ButtonPlanningCol5Row6.SetActive(true);
        ButtonPlanningCol5Row7.SetActive(true);
        ButtonPlanningCol5Row8.SetActive(true);
        ButtonPlanningCol5Row9.SetActive(true);
        ButtonPlanningCol5Row10.SetActive(true);
    }


    public void CheckTime() { } // check if you start at 8 o clock
    public void CheckForEvents() { } // check if any events are supposed to happen 
    public void CheckSlaveInTraining() { } // Is a slave being trained?
    public void CheckAssistantPresent() { } // Do you have an aviable assistant
    public void CheckAssistantTired() { } // Is Asssistant to tired to work?
    public void CheckSMTired() { } // Is SM to tired to work?

    public void CheckStandardSuperviser()
    {
        // look who was the last superviser
        // else check if the sm is avaible and put him in charge
    }

    public void PressButtonPlanning()
    {
        FindRelatedAction(EventSystem.current.currentSelectedGameObject.name);
    }

    public void FindRelatedAction(string PressedButton)
    {
        int ActionCode;
        // check via switch which which action it is and if it is possible
        switch (PressedButton)
        {
            case "1 1":
                if(true)
                {
                    //if time + duration + PlanningRow < 18
                    ActionCode = 11;
                }
                break;
            case "1 2":
                ActionCode = 12;
                break;
            default:
                
                ActionCode = 9999;
                break;
        }
        ActionCodeToList(ActionCode);

    }

    public void ActionCodeToList(int ActionCode)
    {
        CheckFields(ActionCode);
    }
    public void CheckFields(int ActionCode)
    {
        //
        //-------------------------check stuf
       // PlanningList[PlanningColumn, PlanningRow];
            DeleteActionFromList(PlanningColumn, PlanningRow);

    }
    public void DeleteActionFromList(int Column, int Row)
    {
        //check which fields the new action is going to occupy and run delete on all of them
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
