using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events12Midday : MonoBehaviour
{
    public GameUI gameUI;
    public World world;
    public Menus menus;


    public void Events()
    {
        if (world.turn == 130)
        {
            //gameUI.BNextEventSet(9998);
            world.didAEvent = true;
            gameUI.HideAll();
            gameUI.ShowBaseEvent();
            gameUI.ImagesShow();
            gameUI.TSet("You sit down to eat a nice lunch. Events12Midday-Events-if 13");
            gameUI.TAdd("\n Afterwards a bit of walking would do good..");
            gameUI.GoldUpdate(-10);
            gameUI.ShowImage("mllhild/food (1)", 1);
            gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Lake 2", 0);
            int id = 1000; //test id
            int index = 1;
            world.smaker[world.turn + 1] = id * 10000 + index;// declare the next event to happen, if you dont want a direct call
            gameUI.BNext(true, "Walk a bit");
        }


        //if (world.hour == 7)
        //{
        //    Debug.Log("Entered ");
        //    //world.continueGame = false;
        //    //menus.UITextBoxEvent.SetActive(true);
        //    //gameUI.textBoxBG.gameObject.SetActive(false);
        //    //menus.UITextBoxEvent.SetActive(true);
        //    //gameUI.statScreenB1Nr1.gameObject.SetActive(true);
        //    ////gameUI.statScreenB1Nr2.GetComponent<Sprite>(). =
        //    //gameUI.statScreenB1Nr1.sprite = Resources.Load<Sprite>("UI/Texture/woodBackground");
        //    ////gameUI.sliderB1N1S1./
        //    //statsbar.statName.text = "helloo";
        //    //gameUI.TextboxSet("its breakfeast time");
        //    //gameUI.statsbarsCollumn[3].value.text = gameUI.statsbarsCollumn[3].slider.value.ToString();
        //}
    }
}
