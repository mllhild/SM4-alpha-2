using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanningField : MonoBehaviour
{
    public GameUI gameUI;
    public World world;

    public Image Background;
    public TextMeshProUGUI superviser;
    public Button superviserIsSM;
    public Button superviserIsAssistant;
    public PlanningFieldColumn slave;
    public PlanningFieldColumn sm;
    public PlanningFieldColumn assistant;

    public PlanningActPannel actPannel1;
    public PlanningActPannel actPannel2;
    public PlanningActPannel actPannel3;
    public PlanningActPannel actPannel4;
    public PlanningActPannel actPannel5;


    public int hour; // hour of the field
    public int fieldID; // number of the field, 1 to 8(slave), 9 to 16(sm), 17 to 24(assistant)
    public int who; // 0 slave, 1 sm, 2 assistant
    public int withWho; // 0 none, 1 sm, 2 assistant
    public int[] plans = new int[36];
    // 0 - 7 dayactions slave (C# array starts at index 0 :( )
    // 8 - 15 dayactions sm
    // 16 - 23 dayactions as
    // 24 - 27 night sl
    // 28 - 31 night sm
    // 32 - 35 night as
    public int evNum; // event Number
    public int duration;

    public void SetSuperviser(int x)
    {
        withWho = x;
    }
    public void GetFieldID(int x)
    {
        fieldID = x;
        if(fieldID >= 0 && fieldID < 8)
        {
            who = 0;
            GetHourViaFieldID();
            return;
        }
        if (fieldID >= 8 && fieldID < 16 )
        {
            who = 1;
            GetHourViaFieldID();
            return;
        }
        if (fieldID >= 16 && fieldID < 24)
        {
            who = 2;
            GetHourViaFieldID();
            return;
        }
        if (fieldID >= 24 && fieldID < 28)
        {
            who = 0;
            GetHourViaFieldID();
            return;
        }
        if (fieldID >= 28 && fieldID < 32)
        {
            who = 1;
            GetHourViaFieldID();
            return;
        }
        if (fieldID >= 32 && fieldID < 36)
        {
            who = 2;
            GetHourViaFieldID();
            return;
        }
        
        
    }
    public void GetHourViaFieldID()
    {

        
        int x;
        x = fieldID - who * 8; // day action hour get
        if (x < 4)
        {
            hour = 8 + x;
            Debug.LogFormat("First day half at hour {0}", hour);
            return;
        }
        if (x < 8)
        {
            hour = 10 + x;
            Debug.LogFormat("Second day half at hour {0}", hour);
            return;
        }
        Debug.LogFormat("Is it night?  at  hour {0}", hour);
        hour = fieldID - who * 4 - 4; // night action hour get, reduce to slave 24 - 27 then -4 to 20 - 23
        return;
    }
    public void ReceiveEventNumber(int eventNumber) // core function
    {
        evNum = eventNumber;
        //gameUI.TextboxSet(eventNumber.ToString()) ;
        CheckEventDuration(eventNumber);
        CheckParticipants();
        if (!CheckTimeRemaining())
        {
            Debug.LogFormat("Not enought time 2");
            return;
        }
        if (!Checkfields())
        {
            return;
        }
        InsertEventsNumbersInPlans(eventNumber);
        UpdatefieldID();
        UpdatefieldUIDay();
        return;
        
    }
    public void CheckEventDuration(int eventNumber) //Placeholder
    {
        // get duration of event PLACEHOLDER
        int x = eventNumber % 2;
        if (x == 0)
        { duration = 1; }
        else { duration = 2; }
    }
    public void CheckParticipants() //PlaceHolder
    {
        //if(who == 0)
        //{
        //    Debug.Log("who: slave");
        //}
        //if (who == 1)
        //{
        //    Debug.Log("who: sm");
        //}
        //if (who == 2)
        //{
        //    Debug.Log("who: assistant");
        //}
        //if(withWho == 0)
        //{
        //    Debug.Log("with who: none");
        //}
        //if (withWho == 1)
        //{
        //    Debug.Log("with who: sm");
        //}
        //if (withWho == 2)
        //{
        //    Debug.Log("with who: assistant");
        //}
        Debug.LogFormat("eventNr {0} , duration {1}, participant {2}, superviser {3}",evNum, duration, who, withWho);
    }
    public bool CheckTimeRemaining()
    {
        int timeRemaining = 0;
        if (hour >= 8)
        {
            timeRemaining = 12 - hour;
        }
        if (hour >= 14)
        {
            timeRemaining = 18 - hour;
        }
        if (hour >= 20)
        {
            timeRemaining = 24 - hour;
        }
        if(timeRemaining >= duration)
        {
            Debug.LogFormat("time remaining" + timeRemaining.ToString());
            return true;
        }
        else
        {
            Debug.LogFormat("Not enought time");
            return false;
        }
    }

    public bool Checkfields()
    {
        int x = 0;
        int y = 0;
        for (int i = 0;i < duration;i++)
        {
            x = fieldID + i;
            if(fieldID < 8) // slave actions
            {
                y = x + 8 * withWho;
            }
            else
            {
                y = x; // solo actions
            }
            
            if(plans[x] != 0) // check if slave field is occupied
            {
                gameUI.TextboxSet("already plans for slave at that time");
                return false;
            }
            if (plans[y] != 0) // check if superviser field is occupied
            {
                if(withWho == 1)
                {
                    gameUI.TextboxSet("already plans for SM at that time");
                    return false;
                }
                else
                {
                    gameUI.TextboxSet("already plans for Assistant at that time");
                    return false;
                }
                
            }
        }
        return true;
    }
    public bool InsertEventsNumbersInPlans(int eventNumber)
    {
        int x = fieldID;
        int y = x + 8 * withWho;
        if (fieldID > 7) // solo actions
        {
            y = x;
        }
        
        
        plans[x] = eventNumber;
        plans[y] = eventNumber;
        for (int i = 1; i < duration; i++)
        {
            x = fieldID + i;
            y = x + 8 * withWho;
            if (fieldID > 7) // solo actions
            {
                y = x;
            }

            plans[x] = -1 * eventNumber;
            plans[y] = -1 * eventNumber;
            Debug.Log("InsertEventsNumbersInPlans for() did run");
            Debug.LogFormat("{0} {1} {2} {3} {4} {5} {6} {7}", plans[0], plans[1], plans[2], plans[3], plans[4], plans[5], plans[6], plans[7]);
        }
        return true;
    }

    public void UpdatefieldID()
    {
        while(plans[fieldID] != 0)
        {
            fieldID++;
            GetHourViaFieldID();
            if (hour >= 18)
            {
                return;
            }
        }
        
        

    }
    public void UpdatefieldUIDay()
    {
        slave.button08to09.GetComponentInChildren<TextMeshProUGUI>().text = plans[0].ToString();
        slave.button09to10.GetComponentInChildren<TextMeshProUGUI>().text = plans[1].ToString();
        slave.button10to11.GetComponentInChildren<TextMeshProUGUI>().text = plans[2].ToString();
        slave.button11to12.GetComponentInChildren<TextMeshProUGUI>().text = plans[3].ToString();
        slave.button14to15.GetComponentInChildren<TextMeshProUGUI>().text = plans[4].ToString();
        slave.button15to16.GetComponentInChildren<TextMeshProUGUI>().text = plans[5].ToString();
        slave.button16to17.GetComponentInChildren<TextMeshProUGUI>().text = plans[6].ToString();
        slave.button17to18.GetComponentInChildren<TextMeshProUGUI>().text = plans[7].ToString();
        sm.button08to09.GetComponentInChildren<TextMeshProUGUI>().text = plans[8].ToString();
        sm.button09to10.GetComponentInChildren<TextMeshProUGUI>().text = plans[9].ToString();
        sm.button10to11.GetComponentInChildren<TextMeshProUGUI>().text = plans[10].ToString();
        sm.button11to12.GetComponentInChildren<TextMeshProUGUI>().text = plans[11].ToString();
        sm.button14to15.GetComponentInChildren<TextMeshProUGUI>().text = plans[12].ToString();
        sm.button15to16.GetComponentInChildren<TextMeshProUGUI>().text = plans[13].ToString();
        sm.button16to17.GetComponentInChildren<TextMeshProUGUI>().text = plans[14].ToString();
        sm.button17to18.GetComponentInChildren<TextMeshProUGUI>().text = plans[15].ToString();
        assistant.button08to09.GetComponentInChildren<TextMeshProUGUI>().text = plans[16].ToString();
        assistant.button09to10.GetComponentInChildren<TextMeshProUGUI>().text = plans[17].ToString();
        assistant.button10to11.GetComponentInChildren<TextMeshProUGUI>().text = plans[18].ToString();
        assistant.button11to12.GetComponentInChildren<TextMeshProUGUI>().text = plans[19].ToString();
        assistant.button14to15.GetComponentInChildren<TextMeshProUGUI>().text = plans[20].ToString();
        assistant.button15to16.GetComponentInChildren<TextMeshProUGUI>().text = plans[21].ToString();
        assistant.button16to17.GetComponentInChildren<TextMeshProUGUI>().text = plans[22].ToString();
        assistant.button17to18.GetComponentInChildren<TextMeshProUGUI>().text = plans[23].ToString();
    }

    public void DeletePlans()
    {
        int x = fieldID;
        int y;
        //bool notDone = false;
        //CheckEventDuration(plans[fieldID]);
        while (plans[x] < 0)
        {
            x--;
        }
        y = x;
        if (x < 24)
        {
            if (x >= 0 && x < 8) // slave
            {
                if (plans[x] == plans[x + 8]) // check sm
                {
                    y = x + 8;
                }
                if (plans[x] == plans[x + 16]) // check assist
                {
                    y = x + 16;
                }
            }
            if (x >= 8 && x < 16) //sm
            {
                if (plans[x] == plans[x + 8]) // check assist
                {
                    y = x + 8;
                }
                if (plans[x] == plans[x - 8]) // check slave
                {
                    y = x - 8;
                }
            }
            if (x >= 16 && x < 24) //assistant
            {
                if (plans[x] == plans[x - 8]) // check sm
                {
                    y = x - 8;
                }
                if (plans[x] == plans[x - 16]) // check slave
                {
                    y = x - 16;
                }
            }
            
        }
        else
        {
            if (x >= 24 && x < 28) // slave
            {
                if (plans[x] == plans[x + 4])
                {
                    y = x + 4;
                }
                if (plans[x] == plans[x + 8])
                {
                    y = x + 8;
                }
            }
            if (x >= 28 && x < 32)
            {
                if (plans[x] == plans[x + 4])
                {
                    y = x + 4;
                }
                if (plans[x] == plans[x -4])
                {
                    y = x -4;
                }
            }
            if (x >= 32 && x < 36)
            {
                if (plans[x] == plans[x - 4])
                {
                    y = x - 4;
                }
                if (plans[x] == plans[x - 8])
                {
                    y = x - 8;
                }
            }

        }
        //Debug.LogFormat("x"+x.ToString());
        //Debug.LogFormat("y"+y.ToString());
        plans[x] = 0;
        plans[y] = 0;

        while (plans[x] <= 0 && y < 36)
        {
            plans[x] = 0;
            plans[y] = 0;
            x++;
            y++;
            
            //Debug.LogFormat("x" + x.ToString());
            //Debug.LogFormat("y" + y.ToString());
            if (x> 35)
            {
                break;
            }
        }
        UpdatefieldUIDay();

    }


    // Do Planning
    public void StartTheDoPlanning()
    {
        InsertPlansIntoTimeLine();

        gameUI.PlanningMenuHide();
        gameUI.ButtonPlanning.gameObject.SetActive(false);
        gameUI.ButtonDoPlanning.gameObject.SetActive(false);
        gameUI.ButtonNext.gameObject.SetActive(true);

        world.Turn();
    }

    public void InsertPlansIntoTimeLine()
    {
        //plans start at 8-12 14-18 20-24
        //8-12
        for(int i = 0; i<4; i++)
        {
            world.slave[81 + i * 10] = plans[0 + i];
            world.smaker[81 + i * 10] = plans[8 + i];
            world.assist[81 + i * 10] = plans[16 + i];
        }
        for (int i = 0; i < 4; i++)
        {
            world.slave[141 + i * 10] = plans[4 + i];
            world.smaker[141 + i * 10] = plans[12 + i];
            world.assist[141 + i * 10] = plans[20 + i];
        }
        for (int i = 0; i < 4; i++)
        {
            world.slave[201 + i * 10] = plans[24 + i];
            world.smaker[201 + i * 10] = plans[28 + i];
            world.assist[201 + i * 10] = plans[32 + i];
        }




    }
}
