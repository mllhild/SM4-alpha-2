using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsHouse : MonoBehaviour
{
    public GameUI gameUI;
    public World world;
    public Menus menus;


    public void Events()
    {
        if (world.turn >= 80 && world.didMorningPlanning == false)
        {
            //gameUI.BNextEventSet(9999);
            world.didAEvent = true;
            world.didMorningPlanning = true;
            gameUI.HideAll();
            gameUI.ShowBaseEvent();
            gameUI.ImagesShow();
            gameUI.TSet("You eat a nice breakfeast. EventsHouse-Events-if 8+");
            gameUI.ShowImage("mllhild/Kuro/Day03", 1);
            gameUI.TAdd("\n but are still half asleep as you get your hair brushed.");
            gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Kennels - Gustaf Home Day", 0);
            gameUI.BPlanning(true, "Planning");
            gameUI.HouseMenuShow();

        }
        if (world.turn >= 180 && world.didEveningPlanning == false)
        {
            //gameUI.BNextEventSet(9999);
            world.didAEvent = true;
            world.didEveningPlanning = true;
            gameUI.HideAll();
            gameUI.ShowBaseEvent();
            
            gameUI.ImagesShow();
            gameUI.TSet("You eat a nice dinner. EventsHouse-Events-if 18+");
            gameUI.ShowImage("mllhild/Kuro/family", 1);
            gameUI.TAdd("\n Afterwards there is a family reunion as you are all tired and beat for the day.");
            gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Kennels - Gustaf Home Evening",0);

            gameUI.HouseMenuShow();
            gameUI.BNext(true, "Relax for the Evening");

        }
        if (world.turn >= 230 && world.didGoSleep == false)
        {
            //gameUI.BNextEventSet(9999);
            world.didAEvent = true;
            world.didGoSleep = true;
            gameUI.HideAll();
            gameUI.ShowBaseEvent();
            
            gameUI.ImagesShow();
            gameUI.TSet("Its late at night. EventsHouse-Events-if 23+");
            gameUI.ShowImage("mllhild/Kuro/Day01", 1);
            gameUI.TAdd("\n Time to go to bed and sleep.");
            gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Kennels - Gustaf Home Night",0);

            gameUI.HouseMenuShow();
            gameUI.BNext(true, "Sleep");

        }
    }
}
