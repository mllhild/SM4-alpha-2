using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public static World instance = null;
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
    
    
    
    public SM4OptionClass options = new SM4OptionClass();

    
    public EventListener eventListener;
    public bool listen;

    public int[] smaker = new int[240];
    public int[] slave = new int[240];
    public int[] assist = new int[240];

    public int time;
    public int day;
    public int year;
    public int month;
    public int week;
    public int weekday;
    public int hour;  // should be from 0 to 24

    public int turn;
    public int thing;
    public int superviser;
    public int nextEventNumber;

    public string locationCurrent;
   
    public bool didAEvent;
    public bool didMorningPlanning;
    public bool didEveningPlanning;
    public bool didGoSleep;
    public bool continueGame;


    public void NewDay() // call this at 24 hour to start a new day
    {
        hour = 0; // sets clock to 0 hours
        turn = 0;
        thing = 0;
        didMorningPlanning = false;
        didEveningPlanning = false;
        didAEvent = false;
        didGoSleep = false;
        UpdateDate();
    }
    
    public void UpdateDate() // updates the variables for year, month, week and weekday
    {
        int daysAYearHas = 364;
        int daysAMonthHas = 28;
        int daysAWeekHas = 7;
        int hoursInADay = 24;
        int timeInAHour = 10; // 10 time units make 1 hour 
        // other options 360/40/8  360/30/10  360/30/6  336/28/7 364/28/7
        day = time / (hoursInADay * timeInAHour);
        year = day / daysAYearHas +1; // since both are int it return a full number
        month = (day % daysAYearHas) / daysAMonthHas +1; // get remainder after removing all years
        week = ((day % daysAYearHas) % daysAMonthHas) / daysAWeekHas +1;
        weekday = (((day % daysAYearHas) % daysAMonthHas) % daysAWeekHas) + 1;
        
        UIElementsGeneral.instance.utilityDisplays.date.GetCurrentMoonfase();
        UIElementsGeneral.instance.utilityDisplays.date.GetCurrentTime();
        
    }
    
    public string WeekDayName(int weekday)// returns the name of the weekday
    {
        switch (weekday)
        {
            
            case 1:
                return "Moonday";
            case 2:
                return "Twinday";
            case 3:
                return "Wardsday";
            case 4:
                return "Thornsday";
            case 5:
                return "Triday";
            case 6:
                return "Satyrday";
            case 7:
                return "Sunday";
            case 8:
                return "Caturday ";
            default:
                return "weekday outside of expected range";
        }
    }



    public void BigBang(int x) // game start day
    {
        time = x;
        day = time / 240;
        turn = time % 240;
        thing = 0;
        UpdateDate();
    }

    public void AdvanceTime(int timeInHoursToAdvance, bool processDaysYesNO)//Advances the time of the game
    {
        int Oldhour = hour;
        if (processDaysYesNO)
        {
            QuickprocessDays(timeInHoursToAdvance);
        }
        else
        {
            time += timeInHoursToAdvance * 10;
            hour = hour + timeInHoursToAdvance; // advances to the next hour 
        }
        //gameUI.UpdateClock(hour);

        if (hour < 0) //should never happen
        {
            Debug.LogFormat("Error, hour = {0}, hour below Zero, hence hour restored Zero, hour before event: {1}", hour, Oldhour);
            hour = 0;
        }
        if (hour > 24)// should never happen
        {
            Debug.LogFormat("Error, hour = {0}, hour above 24, hence hour restored to 24, hour before event: {1}", hour, Oldhour);
            hour = 24;
        }
        if(hour == 24)// its midnight
        {
            NewDay();
        }

    }
    public void QuickprocessDays(int timeInHoursToAdvance) // for advancing more than to the next day
    {
        // need to figure out what all has to be processed
        // this can only be done once the game is complete
        // so for now place holder
        AdvanceTime(timeInHoursToAdvance, false);
    }
    public void DidTimeAdvance(int oldHour)
    {
        if(oldHour == hour)//somebody forgot to advance the time in their event
        {
            AdvanceTime(1, false);
        }
        //gameUI.UpdateClock(hour);
        UpdateDate();
    }

    //public void ContinueGame()
    //{
    //    continueGame = true;
    //}
    

    public void SequencialEventChecker()
    {
        if(nextEventNumber == 0)
        {
            Turn();
            return;
        }
        eventListener.DoEspecificEvent(nextEventNumber);
    }

    public void Turn()
    {
        
        int x = 0;
        switch (thing)
        {
            case 0:
                x = slave[turn];
                if(slave[turn] == smaker[turn]) { 
                    superviser = 1; // find out who is the supervisor
                    smaker[turn] = 0; // delete the event to not trigger twice
                } 
                if (slave[turn] == assist[turn]) { 
                    superviser = 2;
                    assist[turn] = 0; // delete the event to not trigger twice
                }
                else { 
                    superviser = 0; 
                }
                break;
            case 1:
                x = smaker[turn];
                break;
            case 2:
                x = assist[turn];
                break;
            default:
                Debug.LogFormat("Error in World-Turn, thing is {0}", thing);
                break;
        }
        thing++;
        if(thing > 2) 
        { 
            turn++;
            time++;
            //Debug.LogFormat("End of turn {0}", turn);
            thing = 0;
        } // next time interwall
        eventListener.FindEvents(x);
    }

    public void SetUpNextEvent(int numberForNextPart)
    {
        nextEventNumber = numberForNextPart;
    }

    

}
