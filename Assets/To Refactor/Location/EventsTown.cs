using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsTown : MonoBehaviour
{
    public GameUI gameUI;
    public World world;
    public Menus menus;


    public void Events()
    {
        if (world.hour == 12)
        {
           // gameUI.BNextEventSet(9998);
            gameUI.ShowBase();
            gameUI.ImagesShow();
            gameUI.TSet("You eat a nice lunch. EventsTown-Events-if12");
            gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Kitchen 1",0);
            //world.continueGame = false;
            gameUI.BNext(true, "Leave Town");
            Debug.LogFormat("game did not stop aat {0}", world.hour);
        }
    }
}
