using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsPlanningActs : MonoBehaviour
{
    public GameUI gameUI;
    public World world;
    public Menus menus;


    public void Events(int eventNumber)
    {
        //gameUI.BNextEventSet(9998);
        gameUI.ShowBaseEvent();
        world.didAEvent = true;
        gameUI.TSet("\n This is the event number " + eventNumber.ToString() + " press Next to continue to next event");
        int x = eventNumber % 5;
        switch (x)
        {
            case 0:
                gameUI.TAdd("\n Case 0");
                //gameUI.sm.panel.PointsStats(20, 0);
                //gameUI.slave.panel.PointsStats(20, 0);
                gameUI.ShowImage("mllhild/Kuro/combatSword", 1);
                gameUI.TAdd("\n You do some nice sword training.");
                gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Lake 1", 0);
                break;
            case 1:
                gameUI.TAdd("\n Case 1");
                //gameUI.sm.panel.PointsStats(20, 1);
                //gameUI.slave.panel.PointsStats(20, 1);
                gameUI.ShowImage("mllhild/Kuro/download (14)", 1);
                gameUI.TAdd("\n Sparring with your friend on the backyard of the temple.");
                gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Temple 1", 0);
                break;
            case 2:
                gameUI.TAdd("\n Case 2");
                //gameUI.sm.panel.PointsStats(-20, 2);
                //gameUI.slave.panel.PointsStats(20, 3);
                gameUI.ShowImage("mllhild/Kuro/friends", 1);
                gameUI.TAdd("\n Your friends are relaxing and watching the actions.");
                gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Slave Market 3", 0);
                break;
            case 3:
                gameUI.TAdd("\n Case 3");
                //gameUI.sm.panel.PointsStats(-20, 1);
                //gameUI.slave.panel.PointsStats(20, 5);
                gameUI.ShowImage("mllhild/Kuro/Walking", 1);
                gameUI.TAdd("\n Taking a nice stroll around and hoping for someone to pick a fight.");
                gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Slums 2", 0);
                break;
            case 4:
                gameUI.TAdd("\n Case 4");
                //gameUI.sm.panel.PointsStats(-20, 0);
                //gameUI.slave.panel.PointsStats(20, 4);
                gameUI.ShowImage("mllhild/Kuro/combatSword02", 1);
                gameUI.TAdd("\n You needed some new swords.");
                gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Shop 2", 0);
                break;
            default:
                gameUI.TAdd("\n Case Default");
                gameUI.ShowImage("mllhild/Kuro/kys", 1);
                world.didAEvent = false; // error, outside of event range
                gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Onsen 1", 0);
                break;
        }
        
    }

}
