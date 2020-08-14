using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SMCreator : MonoBehaviour
{

    
    // class reference
            public SM4SlaveMaker SM;
            public XMLsave xmlSave;
            public StartMenuScript startMenuScript;
           


            // UI references
            
            public GameObject smAvatar;
            public Image smAvatarImage;
            public GameObject coatOfArms;
            public Image coatOfArmsImage;
            public GameObject namePanel;
            public TMP_InputField smNameInputField;
            public GameObject familynamePanel;
            public TMP_InputField smFamiliyNameInputField;
            // left collumn

            

            // middle collumn
            // top panel
            public GameObject topPanel;
            public TextMeshProUGUI topPanelTitle;
            public TextMeshProUGUI topPanelText;

            // gender selection
            public GameObject genderSelection;
            public TextMeshProUGUI genderSelectionGender;
            public TextMeshProUGUI genderSelectionText;
            public Toggle genderMale;
            public Toggle genderFemale;
            public Toggle genderFuta;
            

            // measurements
            public GameObject measurements;
            public TextMeshProUGUI genital1;
            public TextMeshProUGUI genital2;

            // religion
            public GameObject religionPanel;
            public TextMeshProUGUI religionTitle;
            public TextMeshProUGUI religionText;
            public GameObject religionScreen;

            // info panel
            public GameObject infoPanel;

            //Buttons
            public Button mainMenuButton;
            public Button optionsButton;
            public Button doneButton;
            public Button backButton;
            public Button advancedButton;
            public Button pickPackageButton;

            // pick package
            public GameObject pickPackageScreen;

            // advanced screens
            public GameObject advancedScreen;
            public GameObject advTopPanel;
            public GameObject advMain;
            public TextMeshProUGUI advMainTtitle;
            public GameObject advOrigin;
            public GameObject advSpecialEvents;
            public GameObject advAdvantages;
            public GameObject advSkills;
            public GameObject advInitialItems;
            public GameObject advStats;
            public GameObject advOverview;
            public GameObject advInitialHouse;
            
            // points
            public GameObject advPointsScreen;
            public TextMeshProUGUI pointDisplay;
            public int points;
            public int initialPoints = 100;
            public int statsPoints = 0;


            // General Stats
            public string smName = "Slave Maker";
            public string smFamilyName = "Family Name";
            public int gender;
            public int avatarID = 1;
            public Sprite[] spritesAvatar;
            public List<Sprite> spritesCoat = new List<Sprite>();
            public int coatID = 1;
            public int religion; // 1 new gods, 2 old gods, 3 none
            public float sizeCockClit = 0.5f;
            public float sizeBust = 0f;
            public float sizeHeight = 0f;
            public float sizeBuild = 0f;

            // Origins
            public SMCreatorOrigin originCountryTown;
            public SMCreatorOrigin originOldFaithStronghold;
            public SMCreatorOrigin originAmazonTribeMaleFemale;
            public SMCreatorOrigin originAmazongTribeFuta;
            public SMCreatorOrigin originMardukane;
            public SMCreatorOrigin originCaravan;
            public SMCreatorOrigin originElvenForest;
            public SMCreatorOrigin originDarkElvenCapital;
            public SMCreatorOrigin originTrueCatGirlTribe;
            public int origin = 1;

            // Special Events
            public SMCreatorOrigin spEvInhumanAncestry;
            public SMCreatorOrigin spEvCockOfDemonicOrigin;
            public SMCreatorOrigin spEvConvertedByTentacles;
            public SMCreatorOrigin spEvExcowgirls;
            public SMCreatorOrigin spEvTentacleHybrid;
            public SMCreatorOrigin spEvExMilkSlave;
            public int specialevents = 0;

            // Advantages
            public SMCreatorOrigin advMinorNoble;
            public SMCreatorOrigin advDev;

            // Skills

            // Initial Itmes

            // Stats
            public InteractableStatbarBlock smCharisma;
            public InteractableStatbarBlock smConversation;
            public InteractableStatbarBlock smConstitution;
            public InteractableStatbarBlock smStrenght;
            public InteractableStatbarBlock smDexterity;
            public InteractableStatbarBlock smInteligence;
            public InteractableStatbarBlock smRefinement;
            public InteractableStatbarBlock smNymphomania;
            public InteractableStatbarBlock smDominance;
            public InteractableStatbarBlock smLust;
            public InteractableStatbarBlock smRenown;
            public InteractableStatbarBlock smCorruption;

      // House




    public void Start()
    {
        avatarID = 1;
        coatID = 1;
        smNameInputField.text = smName;
        smFamiliyNameInputField.text = smFamilyName;
        spritesAvatar = Resources.LoadAll<Sprite>("mllhild/Kuro/download (4)"); // this is for a multiple sprite call
        spritesCoat.Add(Resources.Load<Sprite>("UI/Items/CoatofArms/coat01a"));
        spritesCoat.Add(Resources.Load<Sprite>("UI/Items/CoatofArms/coat01b"));
        spritesCoat.Add(Resources.Load<Sprite>("UI/Items/CoatofArms/coat01c"));

        UpdateAvatar();
        UpdateGender();
        UpdateReligion(1);
        HideAll();
        ShowBasicScreen();
        
    }

    public void updatePoints()
    {
        
        points = initialPoints - statsPoints - Checkforspendpoints();
        pointDisplay.text = points.ToString();
    }
    public int Checkforspendpoints()
    {
        int spendpoints = 0;
        // Origin
        // Special Events
        if (specialevents != 0)
        {

        }
        // Advantages
        // Skills
        // initial Items
        // Stats
        // Initial House


        return spendpoints;
    }

    public void PressAButton(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 0: // back
                    HideAll();
                    ShowBasicScreen();
                break;

            case 1: // options
                // opens the option menu
                startMenuScript.ShowOptionsMenu();
                HideAll();
                break;

            case 2: // Done
                PressDone();
                break;

            case 3: // use Last
                // check for Last
                // Load last
                // Press Done
                break;

            case 4:	// Pick Package
                pickPackageScreen.SetActive(true);

                doneButton.gameObject.SetActive(false);
                pickPackageButton.gameObject.SetActive(false);
                advancedButton.gameObject.SetActive(false);

                topPanel.SetActive(false);
                genderSelection.SetActive(false);
                measurements.SetActive(false);
                religionPanel.SetActive(false);
                infoPanel.SetActive(false);

                break;

            case 5:	// Advanced
                updatePoints();
                pickPackageButton.gameObject.SetActive(false);
                advancedButton.gameObject.SetActive(false);

                topPanel.SetActive(false);
                genderSelection.SetActive(false);
                measurements.SetActive(false);
                religionPanel.SetActive(false);
                infoPanel.SetActive(false);

                advancedScreen.SetActive(true);
                advPointsScreen.SetActive(true);
                advTopPanel.SetActive(true);
                advMain.SetActive(true);


                PressAButton(6);

                break;
            case 6:	// Origin
                HideAdvancedTabs();
                advOrigin.SetActive(true);
                advMainTtitle.text = "Choose where you were born";
                break;
            case 7:	// Special Events
                HideAdvancedTabs();
                advSpecialEvents.SetActive(true);
                
                advMainTtitle.text = "You may choose a strange event that happened in your past";
                break;
            case 8:	// Advantages
                HideAdvancedTabs();
                advAdvantages.SetActive(true);
                
                advMainTtitle.text = "You may choose some talents and abilities you have";
                break;
            case 9:	// Skills
                HideAdvancedTabs();
                advSkills.SetActive(true);
                
                advMainTtitle.text = "You may choose some initial skills you have";
                break;
            case 10:	// Initial Items
                HideAdvancedTabs();
                advInitialItems.SetActive(true);
                
                advMainTtitle.text = "You may choose some initial items you have";
                break;
            case 11:	// Statistics
                HideAdvancedTabs();
                advStats.SetActive(true);
                
                advMainTtitle.text = "Choose your initial statistics";
                break;
            case 12:	// House
                HideAdvancedTabs();
                advOverview.SetActive(true);
                
                advMainTtitle.text = "Choose your initial House";
                break;
            case 13:	// Overview
                HideAdvancedTabs();
                advInitialHouse.SetActive(true);
                advMainTtitle.text = "Review all before you start";
                break;
            case 14:	// avatar previous
                avatarID--;
                if (avatarID < 0)
                {
                    avatarID = spritesAvatar.Length - 1;
                }
                UpdateAvatar();
                break;
            case 15:	// avatar next
                avatarID++;
                if(avatarID >= spritesAvatar.Length)
                {
                    avatarID = 0;
                }
                UpdateAvatar();

                break;
            case 16:	// coat previous
                coatID--;
                if (coatID <= 0)
                {
                    coatID = spritesCoat.Count - 1;
                }
                UpdateCoat();
                break;
            case 17:	// coat next
                coatID++;
                if (coatID >= spritesCoat.Count)
                {
                    coatID = 0;
                }
                UpdateCoat();
                break;
            case 18:	// Religion
                pickPackageButton.gameObject.SetActive(false);
                advancedButton.gameObject.SetActive(false);

                topPanel.SetActive(false);
                genderSelection.SetActive(false);
                measurements.SetActive(false);
                religionPanel.SetActive(false);
                infoPanel.SetActive(false);
                
                religionScreen.SetActive(true);
                break;
            default:
                Debug.LogFormat("Unknown ButonNumber {0}", buttonNumber);
                HideAll();
                ShowBasicScreen();
                break;
        }
    }



    public void UpdateGender()
    {
        if (genderMale.isOn)
        {
            gender = 1;
            genderSelectionGender.text = "Male Slave Maker";
            genderSelectionText.text = "You use your masculinity to master your slaves, taking a leading role but seeking advice from your assistant. You personally do all sex acts you can, making sure not to get too emotionally involved.";
            genital1.gameObject.SetActive(true);
            genital1.text = "Cock";
            genital2.gameObject.SetActive(false);
            genital2.text = "null";
            return;
        }
        if (genderFemale.isOn)
        {
            gender = 2;
            genderSelectionGender.text = "Female Slave Maker";
            genderSelectionText.text = "You are a controlling woman, but considerate of your slave's needs. You try to gain your slave's confidence as a way to control them. Female slaves find it difficult to fall in love with you.";
            genital1.gameObject.SetActive(true);
            genital1.text = "Clitoris";
            genital2.gameObject.SetActive(true);
            genital2.text = "Bust";
            return;
        }
        if (genderFuta.isOn)
        {
            gender = 3;
            genderSelectionGender.text = "Futa Slave Maker";
            genderSelectionText.text = "You are a dominant hermaphrodite with the high libido common to your sex. Your training methods are similar to male training methods, but with a heavier focus on cock and cum. It is more difficult for slaves to fall in love with you.";
            genital1.gameObject.SetActive(true);
            genital1.text = "Cock";
            genital2.gameObject.SetActive(true);
            genital2.text = "Bust";
            return;
        }
        genderMale.isOn = true;
        UpdateGender();
        
    }

    public void UpdateReligion(int newreligion)
    {
        religion = newreligion;


        if (religion == 1)
        {
            religionTitle.text = "New Gods";
            religionText.text = "+ approved religion, no restrictions\n-  sexually inhibited";
            return;
        }
        if (religion == 2)
        {
            religionTitle.text = "Old Gods";
            religionText.text = "+ sexually free, wild and nature-connected\n-  hates restriction, bondage";
            return;
        }
        if (religion == 3)
        {
            religionTitle.text = "No Gods";
            religionText.text = "+ no restrictions\n- no help, people may think you are demonic";
            return;
        }
    }

    public void HideAdvancedTabs()
    {
        advOrigin.SetActive(false);
        advSpecialEvents.SetActive(false);
        advAdvantages.SetActive(false);
        advSkills.SetActive(false);
        advInitialItems.SetActive(false);
        advStats.SetActive(false);
        advOverview.SetActive(false);
        advInitialHouse.SetActive(false);
    }
    
    public void HideAll()
    {
        // UI references
        // left collumn
        smAvatar.SetActive(false);
        coatOfArms.SetActive(false);
        namePanel.SetActive(false);
        familynamePanel.SetActive(false);

        // middle collumn
        // top panel
         topPanel.SetActive(false);

        // gender selection
         genderSelection.SetActive(false);

        // measurements
         measurements.SetActive(false);

        // religion
         religionPanel.SetActive(false);
         religionScreen.SetActive(false);

        // info panel
         infoPanel.SetActive(false);

        //Buttons
        mainMenuButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        doneButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        advancedButton.gameObject.SetActive(false);
        pickPackageButton.gameObject.SetActive(false);

        // pick package
         pickPackageScreen.SetActive(false);

        // advanced screens
         advancedScreen.SetActive(false);

    }

    public void ShowBasicScreen() // the first screen with the gender selection
    {
        smAvatar.SetActive(true);
        namePanel.SetActive(true);
        topPanel.SetActive(true);
        genderSelection.SetActive(true);
        measurements.SetActive(true);
        religionPanel.SetActive(true);
        infoPanel.SetActive(true);

        mainMenuButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        doneButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        advancedButton.gameObject.SetActive(true);
        pickPackageButton.gameObject.SetActive(true);
        if(religion != 1 && religion != 2 && religion != 3)
        {
            religion = 1;
        }
        UpdateGender();
        UpdateReligion(religion);
    }

    public void PickAPackage(int package)
    {
        switch (package)
        {
            default:
                Debug.LogFormat("Unknown package {0}", package);
                HideAll();
                ShowBasicScreen();
                break;
        }
    }
    

    public void UpdateAvatar()
    {
        smAvatarImage.sprite = spritesAvatar[avatarID];
    }
    public void UpdateCoat()
    {
        coatOfArmsImage.sprite = spritesCoat[coatID];
    }
    
    
    public void UpdateNobility()
    {
        if (advMinorNoble.GetComponentInChildren<Toggle>().isOn)
        {
            familynamePanel.SetActive(true);
            coatOfArms.SetActive(true);
            UpdateCoat();
        }
        else
        {
            familynamePanel.SetActive(false);
            coatOfArms.SetActive(false);
        }
        
    }
    //public void UpdateStatsOnClick(int x)
    //{
    //    this.gameObject.GetComponentInChildren<Slider>().value += x;
    //    //this.gameObject.GetComponent<Slider>().value += x;
    //}
    

    public void PressDone()
    {
        //SM.Index = -1;
        //SM.gender = gender;
        //SM.bool1 = true;
        //SM.bool2 = false;
        //SM.bool3 = true;
        //SM.stat1 = smCharisma.slider.value;
        //SM.stat2 = smDominance.slider.value;
        //SM.stat3 = smConstitution.slider.value;
        
        //SM.name1 = smNameInputField.text;
        //if (advMinorNoble.GetComponentInChildren<Toggle>().isOn)
        //{
        //    SM.name2 = " von ";
        //    SM.familyname = smFamiliyNameInputField.text;
        //}
            
        //Debug.LogFormat(familyname.text);
        xmlSave.Save("Core", "SlaveMaker", "DataBaseSlaveMaker");
        //Debug.LogFormat(familyname.text);

        startMenuScript.NewGame();

    }
}
