using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Events06Morning : MonoBehaviour
{
    public GameUI gameUI;
    public World world;
    public Menus menus;


    public void Events()
    {
        if (world.turn == 60)
        {
            //gameUI.BNextEventSet(9999);
           
            world.didAEvent = true;
            gameUI.ShowBaseEvent();
            gameUI.ImagesShow();
            gameUI.TSet("Its Morning. Events06Morning-Events-if 6");
            gameUI.ShowImage("mllhild/Kuro/Day02", 1);
            gameUI.TBlancLine();
            //gameUI.TSpeak(gameUI.sm.name1, "Is it really morning already?");
            gameUI.ShowImage("Images/Standard Images/Backgrounds/tn_Kennels - Millie's Room", 0);
            gameUI.BNext(true, "Next");

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
