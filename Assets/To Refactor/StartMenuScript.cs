using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
using System.Xml; // basic XML attributes
using System.Xml.Serialization; // access xml serializer


public class StartMenuScript : MonoBehaviour
{
    

    public GameObject StartMenu;
    public GameObject LoadMenu;
    public GameObject SaveMenu;
    public GameObject OptionsMenu;
    public GameObject Credits;
    public GameObject Background;
    public GameObject Page01;
    public GameObject Page02;
    public GameObject Page03;
    public GameObject Page04;
    public GameObject Page05;
    public GameObject HiddenButtons;
    public GameObject HiddenButtons2;
    public GameObject IntroScene;

    public GameObject IntroSceneImage;
    public Text IntroSceneText;
    public GameObject SMCreator;


    

    public MenuOptions menuOptions;

    public int genVar = 0;

    public SM4SlaveMaker slaveMaker;
    public SMCreator sMCreator;
    public XMLsave xmlSave;


    public Sprite[] sprites;

    private void Awake()
    {

    }

    void Start()
    {
       // slaveMaker.character.measurements.height = 10;
        //Debug.Log(slaveMaker.character.measurements.height.ToString());

        menuOptions.GetResolutions();
        HideAll();
        StartMenu.SetActive(true);
        Background.SetActive(true);
        // folder path, file name, class type
        xmlSave.Load("Core", "Config", "DataBaseOptionMenu");
        
        
        
        


        // test code from here
        //Sprite sprite1;
        //sprite1 = Resources.Load<Sprite>("Assets/mllhild/9148104275cc367e_2");
        //IntroSceneImage.sprite = sprite1;
        //IntroSceneImage.preserveAspect = false;
        //IntroSceneImage.sprite = Resources.Load<Sprite>("mllhild/017.jpg");
        //Debug.LogFormat("asdas");
        //IntroSceneImage.sprite = Resources.Load<Sprite>("mllhild/017.jpg") as Sprite;
        //IntroSceneImage.enabled = false;
        //myTexture = Resources.Load("Images/SampleImage") as Texture2D;

        //GameObject rawImage = GameObject.Find("RawImage");
        //rawImage.GetComponent<RawImage>().texture = myTexture;



        // to here
    }




    public void NewGame()
    {
        
        Background.SetActive(false);
        SceneManager.LoadScene("Game");
        //SceneManager.LoadScene("Game", LoadSceneMode.Additive);
        //SceneManager.MergeScenes(SceneManager.GetSceneByBuildIndex(0), SceneManager.GetSceneByBuildIndex(1));
    }
    
    public void ContinueGame()
    {
        //Load last recorded savefile
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
    public void HideAll()
    {
        StartMenu.SetActive(false);
        LoadMenu.SetActive(false);
        SaveMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        Credits.SetActive(false);
        Page01.SetActive(false);
        Page02.SetActive(false);
        Page03.SetActive(false);
        Page04.SetActive(false);
        Page05.SetActive(false);
        HiddenButtons.SetActive(false);
        HiddenButtons2.SetActive(false);
        
        IntroScene.SetActive(false);
        SMCreator.SetActive(false);

    }
    public void ShowStartMenu()
    {
        if(SceneManager.GetActiveScene().name == "Menus")
        {
            StartMenu.SetActive(true);
            Background.SetActive(true);
        }
        
    }
    public void HideStartMenu()
    {
        StartMenu.SetActive(false);
        Background.SetActive(false);
    }

    public void ShowLoadMenu()
    {
        LoadMenu.SetActive(true);
    }
    public void HideLoadMenu()
    {
        LoadMenu.SetActive(false);
    }
    public void ShowSaveMenu()
    {
        SaveMenu.SetActive(true);
    }
    public void HideSaveMenu()
    {
        SaveMenu.SetActive(false);
    }
    public void ShowOptionsMenu()
    {
        Debug.LogFormat("ShowOptionsMenu");
        menuOptions.LoadOptionsFromFile();
        //menuOptions.UpdateMenu();
        
        OptionsMenu.SetActive(true);

    }
    public void HideOptionsMenu()
    {
        Debug.LogFormat("HideOptionMenu");
        //menuOptions.UpdateDataBase();
        menuOptions.SaveOptionsToFile();
        
        OptionsMenu.SetActive(false);
    }
    public void ShowCredits()
    {
        Credits.SetActive(true);
        Page01.SetActive(true);
    }
    public void HideCredits()
    {
        Credits.SetActive(false);
        Page01.SetActive(false);
        Page02.SetActive(false);
        Page03.SetActive(false);
        Page04.SetActive(false);
        Page05.SetActive(false);
    }
    public void CredditsNextPage()
    {
        if (Page01.activeSelf)
        {
            Page01.SetActive(false);
            Page02.SetActive(true);
            return;
        }
        if (Page02.activeSelf)
        {
            Page02.SetActive(false);
            Page03.SetActive(true);
            return;
        }
        if (Page03.activeSelf)
        {
            Page03.SetActive(false);
            Page04.SetActive(true);
            return;
        }
        if (Page04.activeSelf)
        {
            Page04.SetActive(false);
            Page05.SetActive(true);
            return;
        }
        if (Page05.activeSelf)
        {
            return;
        }
    }
    public void CredditsPreviousPage()
    {
        if (Page01.activeSelf)
        {
            return;
        }
        if (Page02.activeSelf)
        {
            Page02.SetActive(false);
            Page01.SetActive(true);
            return;
        }
        if (Page03.activeSelf)
        {
            Page03.SetActive(false);
            Page02.SetActive(true);
            return;
        }
        if (Page04.activeSelf)
        {
            Page04.SetActive(false);
            Page03.SetActive(true);
            return;
        }
        if (Page05.activeSelf)
        {
            Page05.SetActive(false);
            Page04.SetActive(true);
            return;
        }

    }

    public void WebPageDiscord()
    {
        Application.OpenURL("https://discord.gg/7TfY8yb");
    }
    public void WebPageFutanariPalace()
    {
        Application.OpenURL("https://www.futanaripalace.com/forumdisplay.php?215-Slave-Maker");
    }
    public void WebPageFutanariPalaceLoli()
    {
        Application.OpenURL("https://www.futanaripalace.com/forumdisplay.php?55-Loli-amp-Shota-Central");
    }
    public void WebPageAllTheFallen()
    {
        Application.OpenURL("https://allthefallen.moe/");
    }
    public void WebPageAllLolicit()
    {
        Application.OpenURL("https://www.lolicit.org/");
    }
    public void AreTheyWanted()
    {
        HiddenButtons.SetActive(menuOptions.LoliShotaEnabled.isOn);
        HiddenButtons2.SetActive(menuOptions.LoliShotaEnabled.isOn);
        
    }
    public void ShowIntroScreen()
    {
        IntroScene.SetActive(true);
        sprites = Resources.LoadAll<Sprite>("mllhild/Kuro/download (4)"); // this is for a multiple sprite call

        IntroSceneImage.GetComponent<Image>().preserveAspect = true;
        IntroSceneImage.GetComponent<Image>().sprite = sprites[0]; // loads image 0 of sprites
        //IntroSceneImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("mllhild/Kuro/download (4)"); // loads image
        IntroSceneImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(440f, -540f); // positions image
        genVar = 0;
    }
    public void HideIntroScreen()
    {
        IntroScene.SetActive(false);
        genVar = 0;
    }
    private GameObject page2;
    public void IntroSceneNext()
    {
        
        genVar++;
        switch (genVar)
        {
            case 0:
                HideIntroScreen();
                ShowStartMenu();
                Destroy(page2);
                break;
            case 1:
                //IntroSceneImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("mllhild/Kuro/download (4)_0"); // loads image
                IntroSceneImage.GetComponent<Image>().sprite = sprites[1]; // loads image 1 of sprites
                IntroSceneImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(440f, -540f); // positions image
                break;
            case 2:
                //IntroSceneImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("mllhild/Kuro/download (4)_0");
                IntroSceneImage.GetComponent<Image>().sprite = sprites[2]; // loads image 2 of sprites
                IntroSceneImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(880f, -540f);
                
                page2 = Instantiate(IntroSceneImage, IntroScene.transform);
                page2.GetComponent<RectTransform>().anchoredPosition = new Vector2();
                page2.GetComponent<Image>().sprite = sprites[3]; // loads image 2 of sprites
                //page2.GetComponent<Image>().sprite = Resources.Load<Sprite>("mllhild/Kuro/download (4)_0");
                page2.GetComponent<RectTransform>().anchoredPosition = new Vector2(-50f, -540f);
                break;
            case 3:
                Destroy(page2);
                IntroSceneImage.GetComponent<Image>().sprite = sprites[4]; // loads image 2 of sprites
                //IntroSceneImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("mllhild/Kuro/download (4)_0");
                IntroSceneImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(880f, -540f);
                break;
            case 4:
                IntroSceneImage.GetComponent<Image>().sprite = sprites[5]; // loads image 2 of sprites
                //IntroSceneImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("mllhild/Kuro/download (4)_0");
                IntroSceneImage.GetComponent<Image>().preserveAspect = true;
                break;
            case 5:
                
                IntroSceneImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("mllhild/Kuro/download (7)");
                IntroSceneImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(960f, -540f);
                IntroSceneImage.GetComponent<Image>().preserveAspect = false;
                break;
            default:
                HideIntroScreen();
                ShowSMCreator();
                break;
        }
    }
    public void IntroScenePrevious()
    {
        genVar -= 2;
        IntroSceneNext();
    }
    public void ShowSMCreator()
    {
        SMCreator.SetActive(true);
    }
    public void HideSMCreator()
    {
        SMCreator.SetActive(false);
    }


    



}
