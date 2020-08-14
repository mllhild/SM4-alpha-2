using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events18Evening : MonoBehaviour
{
    public GameUI gameUI;
    public World world;
    public Menus menus;


    public void Events()
    {
        if (world.hour == 18)
        {
            //gameUI.BNextEventSet(9999);
            world.didAEvent = true;
            gameUI.HideAll();
            gameUI.ShowBaseEvent();
            gameUI.ImagesShow();
            gameUI.TSet("A letter seems to be waiting for you at home. Events18Evening-Events-if18");
            gameUI.TAdd(" Yet it doesnt seem to be addressed at you, better not to open it now.");
            gameUI.ShowImage("UI/Items/Books/envelope", 1);
            gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Lake 2", 0);
            gameUI.BNext(true, "Next");
        }

    }
}
