using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class StartNewGameIntroScreen : MonoBehaviour
{
    private GameObject buttonSkip;
    private GameObject buttonPrevious;
    private GameObject buttonNext;
    private List<GameObject> listOfGameObjects = new List<GameObject>();

    private int page = 0;
    
    public void StartIntroScreen()
    {
        buttonNext = GameObject.Find("Canvas/Introscreen/Buttons/IntroNext");
        buttonPrevious = GameObject.Find("Canvas/Introscreen/Buttons/IntroPrevious");
        buttonSkip = GameObject.Find("Canvas/Introscreen/Buttons/IntroSkip");
        
        listOfGameObjects.Add(GameObject.Find("Canvas/Introscreen/Part01"));
        listOfGameObjects.Add(GameObject.Find("Canvas/Introscreen/Part02"));
        listOfGameObjects.Add(GameObject.Find("Canvas/Introscreen/Part03"));
        listOfGameObjects.Add(GameObject.Find("Canvas/Introscreen/Part04"));
        
        page = 0;
        
        buttonNext.GetComponent<Button>().onClick.AddListener(GoToNextPage);
        buttonPrevious.GetComponent<Button>().onClick.AddListener(GoToPreviousPage);
        buttonSkip.GetComponent<Button>().onClick.AddListener(SkipIntro);

        GoToNextPage();




    }

    private void SkipIntro()
    {
        page = listOfGameObjects.Count + 1;
        ShowNewPage();
    }

    private void GoToPreviousPage()
    {
        HideCurrentPage();
        page--;
        ShowNewPage();
    }

    public void GoToNextPage()
    {
        HideCurrentPage();
        page++;
        ShowNewPage();
    }

    private void HideCurrentPage()
    {
        foreach (var introGameObject in listOfGameObjects)
        {
            //Destroy(introGameObject);
            introGameObject.SetActive(false);
        }
        
    }
    private void ShowNewPage()
    {
        switch (page)
        {
                
            case 0:
                FindObjectOfType<UIControlerSceneStartMenu>().SetUIElement("StartMenu", true);
                FindObjectOfType<UIControlerSceneStartMenu>().SetUIElement("Introscreen", false);
                break;
            case 1:
                GameObject.Find("Canvas/Introscreen/Part01").SetActive(true);
                break;
            case 2:
                GameObject.Find("Canvas/Introscreen/Part02").SetActive(true);
                break;
            case 3:
                GameObject.Find("Canvas/Introscreen/Part03").SetActive(true);
                break;
            case 4:
                GameObject.Find("Canvas/Introscreen/Part04").SetActive(true);
                break;
            case 5:
                FindObjectOfType<UIControlerSceneStartMenu>().SetUIElement("SMCreator", true);
                FindObjectOfType<UIControlerSceneStartMenu>().SetUIElement("Introscreen", false);
                break;
        }
    }
    
}
