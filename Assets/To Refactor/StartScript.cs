using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class StartScript : MonoBehaviour
{

    
    public AudioMixer audioMixer;
    public World world;
    public Menus menus;
    public EventListener eventListener;
    public GameUI gameUI;
    public XMLsave xmlSave;
    //public SlaveMaker sm = new SlaveMaker();
    //public Slave slave = new Slave();
    //public List<Slave> slaves = new List<Slave>();
    //public Assistant assistant;
    //public StartMenuScript startMenuScript;
    Resolution[] resolutions;

    public bool gameIsRunning;

    public void Awake()
    {

    }

       
    void Start()// Start is called before the first frame update
    {

        // --------------------------------------------- A lot of testing stuff ------- Start

        

        //Dress dress = new Dress();
        //dress.quantity = 1;

        //sm.generalSM.supervise = true;
        //sm.smActs1.Add(new PlanningAct());
        //sm.smActs1[0].actEventnumber = 1;
        //sm.generalSlave.highclassParty = 1;
        //sm.jobs.Add(new PlanningAct());
        //sm.jobs[0].actEventnumber = 1;
        //sm.ears.lenght = 1;
        //sm.usedItems.Add(new ItemUsed());
        //sm.usedItems[0].ID = 1;
        //sm.dresses.Add(new Dress());
        //sm.dresses[0].holy = true;
        ////sm.dressesArray[0] = new Dress();
        ////sm.dressesArray[0].holy = true;
        //sm.sexSkills.anal.current = 1;

        //for (int i = 0; i < 5; i++)
        //{
        //    slaves.Add(new Slave());
        //    slaves[i].ID = i;
        //}
        //for (int i = 0; i < 5; i++)
        //{
        //    //Debug.Log(slaves[i].ID);
        //}
        //slaves[2].sexSkills.anal.current = 1;

        //TestSave test = new TestSave();
        //test.TestThis();

        // --------------------------------------------- A lot of testing stuff ------- END



        gameUI.GoldUpdate(0);
        
        StartNewGame();
        gameIsRunning = true;
        world.continueGame = true;

   
    }
    private void StartNewGame()
    {
        xmlSave.Load("Core", "SlaveMaker", "DataBaseSlaveMaker");
        //Debug.Log(sm.familyname);
        //Debug.Log(xmlSave.SM.familyname);
        world.BigBang(0);
        gameUI.HideAll();
        world.Turn();
        

    }



    //IEnumerator RunGame()
    //{
    //    while (gameIsRunning)
    //    {
    //        Debug.LogFormat("Run game has been executed");
    //        eventListener.CheckCurrentHourForAction(world.hour);
    //        yield return new WaitUntil(() => world.continueGame == true);
    //        world.DidTimeAdvance(world.hour);
    //    }
    //}
    void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}


//Character.CharacterActions NameofName = new Character.CharacterActions();
//NextT.GetComponent<Text>().text = "...";

         
//Character hero = new Character(100, 80, 0, 10, 5);
//Debug.LogFormat("HP: {0}, MP: {1}, LP: {2},", hero.HP, hero.MP, hero.LP);
//Debug.LogFormat(NameofName.Attack(hero.ATK, hero.DEF).ToString());
//hero.HP += NameofName.Attack(hero.ATK, hero.DEF);
//Debug.LogFormat("HP: {0}, MP: {1}, LP: {2},", hero.HP, hero.MP, hero.LP);

//Debug.Log("void Start");
//resolutions = Screen.resolutions;  // getting the screen resolution for option menu
//resolutionDropdown.ClearOptions();
//List<string> options = new List<string>();
//int currentResolutionIndex = 0;
//for (int i = 0; i < resolutions.Length; i++)
//{
//    string option = resolutions[i].width + " x " + resolutions[i].height;
//    options.Add(option);
//    if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
//    {
//        currentResolutionIndex = i;
//    }
//}
//resolutionDropdown.AddOptions(options);
//resolutionDropdown.value = currentResolutionIndex;
//resolutionDropdown.RefreshShownValue();
