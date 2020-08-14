using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartNewGameSMCreatorMenu : MonoBehaviour
{
    
    /*
    public SM4SlaveMaker sm = new SM4SlaveMaker();
    

    

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
        sm.gender.current = 1;
        sm.raceID = 1;
        sm.raceName = "Human";
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
                //startMenuScript.ShowOptionsMenu();
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

    

    public void PressDone()
    {
        

    }*/
    
    public SM4SlaveMaker sm = new SM4SlaveMaker();

    //describes which "state" the screen is in. Used mostly for the back and done buttons
    enum SMState { 
        Basic,
        Advanced,
        Religion,
        Package
    }

    enum SMGender { 
        Male = 1,
        Female = 2,
        Futa = 3
    }

    enum SMReligion {
        New_Gods = 1,
        Old_Gods = 2,
        No_Gods = 3
    }


    

    private SMState smState = SMState.Basic;
    private SMReligion smReligion = SMReligion.New_Gods;
    private SMGender smGender = SMGender.Male;

    //coat of arms
    private List<Texture2D> coaTextures;
    public RawImage coatOfArmsImage;
    public Button coaNext;
    public Button coaPrevious;
    private int currentCOA = 0;
    private int maxCoa;

    //avatar
    private List<Texture2D> avatarTextures;
    public RawImage avatarImage;
    public Button avatarNext;
    public Button avatarPrevious;
    private int currentAvatar = 0;
    private int maxAvatar;


            


    // gender selection
    public GameObject genderSelection;
    public TextMeshProUGUI genderSelectionGender;
    public TextMeshProUGUI genderSelectionText;
    public Toggle genderToggleMale;
    public Toggle genderToggleFemale;
    public Toggle genderToggleFuta;

    
    //UI panels
    public GameObject topPanel;
    public TextMeshProUGUI topPanelTitle;
    public TextMeshProUGUI topPanelText;
    public GameObject advancedScreen;

    // measurements
    public GameObject measurements;
    public TextMeshProUGUI genital1;
    public TextMeshProUGUI genital2;

    // religion
    public GameObject religionPanel;
    public TextMeshProUGUI religionTitle;
    public TextMeshProUGUI religionText;
    public GameObject religionScreen;
    public Button religionButton;

    public Button pickReligionNewGods;
    public Button pickReligionOldGods;
    public Button pickReligionNoGods;

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
        //initailize stats for the coat of arms and avatar images
        coaTextures = new List<Texture2D>();
        avatarTextures = new List<Texture2D>();

        loadCOAImageAssets();
        loadAvatarImageAssets();

        maxCoa = coaTextures.Count;
        coatOfArmsImage.texture = coaTextures[currentCOA];
        maxAvatar = avatarTextures.Count;
        avatarImage.texture = avatarTextures[currentAvatar];


        //get handles to UI
        initButtons();
        initGenderToggles();
        initReligion();





        
        

    }


    //helpers to get UI references
    public void initButtons() {
        mainMenuButton.onClick.AddListener(() => onMainMenuPressed());
        optionsButton.onClick.AddListener(() => onOptionsPressed());
        doneButton.onClick.AddListener(() => onDonePressed());
        backButton.onClick.AddListener(() => onBackPressed());
        advancedButton.onClick.AddListener(() => onAdvancedPressed());
        pickPackageButton.onClick.AddListener(() => onPickPackagePressed());
        religionButton.onClick.AddListener(() => onReligionPickerOpenPressed());

        coaNext.onClick.AddListener(() => onCOANextPressed());
        coaPrevious.onClick.AddListener(() => onCOAPreviousPressed());
        avatarNext.onClick.AddListener(() => onAvatarNextPressed());
        avatarPrevious.onClick.AddListener(() => onAvatarPreviousPressed());
    }

    public void initGenderToggles() {
        genderToggleMale.onValueChanged.AddListener((value) => onGenderChanged(value));
        genderToggleFemale.onValueChanged.AddListener((value) => onGenderChanged(value));
        genderToggleFuta.onValueChanged.AddListener((value) => onGenderChanged(value));


        genital1.gameObject.SetActive(true);
        genital1.text = "Cock";
        genital2.gameObject.SetActive(false);
        genital2.text = "null";
    }

    public void initReligion() {
        pickReligionOldGods.onClick.AddListener(() => onReligionPickerOldGodsPressed());
        pickReligionNewGods.onClick.AddListener(() => onReligionPickerNewGodsPressed());
        pickReligionNoGods.onClick.AddListener(() => onReligionPickerNoGodsPressed());
    }

    //listeners for buttons
    public void onMainMenuPressed() {
        //TODO: Clear all the stuff before going back to main menu
        FindObjectOfType<UIControlerSceneStartMenu>().SetUIElement("StartMenu", true);
        FindObjectOfType<UIControlerSceneStartMenu>().SetUIElement("SMCreator", false);
    }
    public void onOptionsPressed() { }
    public void onDonePressed() { }
    public void onBackPressed() {
        switch (smState) {
            case (SMState.Basic):
                break;
            case (SMState.Advanced):
                break;
            case (SMState.Religion):
                break;
            case (SMState.Package):
                break;
        }
    }

    public void onAdvancedPressed() {
        
    }

    public void onPickPackagePressed() {
        
        showPackageScreen();
    }

    public void onReligionPickerOpenPressed() {
        clearMainArea();
        showReligionScreen();
    }

    //coa buttons
    public void onCOANextPressed() {
        if (currentCOA < maxCoa - 1) {
            coatOfArmsImage.texture = coaTextures[++currentCOA];
        }
    }
    public void onCOAPreviousPressed() {
        if (currentCOA > 0) {
            coatOfArmsImage.texture = coaTextures[--currentCOA];
        }
    }

    //avatar buttons
    public void onAvatarNextPressed() {
        if (currentAvatar < maxAvatar - 1) {
            avatarImage.texture = avatarTextures[++currentAvatar];
        }
    }

    public void onAvatarPreviousPressed() {
        if (currentAvatar > 0) {
            avatarImage.texture = avatarTextures[--currentAvatar];
        }
    }


    //religion choose screen buttons
    public void onReligionPickerOldGodsPressed() {
        smReligion = SMReligion.Old_Gods;
        
        clearMainArea();
        showBasicScreen();

        religionTitle.text = "Old Gods";
        religionText.text = "+ Sexually free, wild, and connected to nature.\n" +
            "- Hates restrictions, bondage.";

    }

    public void onReligionPickerNewGodsPressed() {
        smReligion = SMReligion.New_Gods;

        clearMainArea();
        showBasicScreen();

        religionTitle.text = "New Gods";
        religionText.text = "+ Approved religion, no restrictions.\n" +
            "- Sexually inhibited.";
    }

    public void onReligionPickerNoGodsPressed() {
        smReligion = SMReligion.No_Gods;

        clearMainArea();
        showBasicScreen();

        religionTitle.text = "No Gods";
        religionText.text = "+ No restrictions.\n" +
            "- No help.";

    }

    //gender listener

    //this is sub-optimal considering that the toggle gives it's value in the method, but couldn't find a simple way to do this without making a new togglegroup class, which is too much work.
    public void onGenderChanged(bool value) {
        if (genderToggleMale.isOn){
            smGender = SMGender.Male;
            genderSelectionGender.text = "Male Slave Maker";
            genderSelectionText.text = "You use your masculinity to master your slaves, taking a leading role but seeking advice from your assistant. You personally do all sex acts you can, making sure not to get too emotionally involved.";
            genital1.gameObject.SetActive(true);
            genital1.text = "Cock";
            genital2.gameObject.SetActive(false);
            genital2.text = "null";
        }
        else if (genderToggleFemale.isOn){
            smGender = SMGender.Female;
            genderSelectionGender.text = "Female Slave Maker";
            genderSelectionText.text = "You are a controlling woman, but considerate of your slave's needs. You try to gain your slave's confidence as a way to control them. Female slaves find it difficult to fall in love with you.";
            genital1.gameObject.SetActive(true);
            genital1.text = "Clitoris";
            genital2.gameObject.SetActive(true);
            genital2.text = "Bust";
        }
        else if (genderToggleFuta.isOn) {
            smGender = SMGender.Futa;
            genderSelectionGender.text = "Futa Slave Maker";
            genderSelectionText.text = "You are a dominant hermaphrodite with the high libido common to your sex. Your training methods are similar to male training methods, but with a heavier focus on cock and cum. It is more difficult for slaves to fall in love with you.";
            genital1.gameObject.SetActive(true);
            genital1.text = "Cock";
            genital2.gameObject.SetActive(true);
            genital2.text = "Bust";
        }

    }

    //utilities to show and hide UI as needed.

    public void showBasicScreen() {
        smState = SMState.Basic;
        infoPanel.gameObject.SetActive(true);
        religionPanel.gameObject.SetActive(true);
        topPanel.gameObject.SetActive(true);
        genderSelection.gameObject.SetActive(true);
        measurements.gameObject.SetActive(true);

        advancedButton.gameObject.SetActive(true);
        pickPackageButton.gameObject.SetActive(true);
    }

    public void showAdvancedScreen() {
        smState = SMState.Advanced;
    }

    public void showPackageScreen() {
        smState = SMState.Package;
        
        pickPackageScreen.gameObject.SetActive(true);
    }

    public void showReligionScreen() {
        smState = SMState.Religion;
        religionScreen.gameObject.SetActive(true);
    }

    //clears the main area on the right hand of the screen, leaving the avatar selection and name-changer controls visable
    public void clearMainArea() {
        infoPanel.gameObject.SetActive(false);
        religionPanel.gameObject.SetActive(false);
        topPanel.gameObject.SetActive(false);
        genderSelection.gameObject.SetActive(false);
        measurements.gameObject.SetActive(false);
        advancedScreen.gameObject.SetActive(false);
        pickPackageScreen.gameObject.SetActive(false);
        religionScreen.gameObject.SetActive(false);

        //these two buttons are visable with the religion screen open, and can cause issues
        advancedButton.gameObject.SetActive(false);
        pickPackageButton.gameObject.SetActive(false);
    }


    //TODO: maybe limit file types to only jpeg; gifs are too massive and transparency isn't really needed for pngs.
    //TODO: these should probabaly be threaded to avoid blocking the UI thread.

    private void loadCOAImageAssets()
    {
        
        DirectoryInfo streamingAssets = new DirectoryInfo(Path.Combine(Application.streamingAssetsPath, "SM/CoatOfArms"));
        FileInfo[] allFiles = streamingAssets.GetFiles("*.*");

        foreach (FileInfo file in allFiles) {
            
            if (file.Name.Contains("meta")) continue;

            coaTextures.Add(loadImage(file.FullName));
        }
    }

    private void loadAvatarImageAssets() {
        //load avatar images
        //TODO: races, everyone's human for the moment.
        string path = "SM/Avatar/Human";

        switch (smGender)
        {
            //TODO: Change this back to Male 
            case SMGender.Male:
                path += "/Female";
                break;
            case SMGender.Female:
                path += "/Female";
                break;
            case SMGender.Futa:
                path += "/Futa";
                break;
        }

        Debug.Log(path);

        DirectoryInfo streamingAssets = new DirectoryInfo(Path.Combine(Application.streamingAssetsPath, path));
        DirectoryInfo[] portraitFolders = streamingAssets.GetDirectories();


        FileInfo[] allFiles;


        foreach (DirectoryInfo folder in portraitFolders) {
            allFiles = folder.GetFiles("Portrait*.*");

            foreach (FileInfo file in allFiles) {
                if (file.Name.Contains("meta")) continue;

                avatarTextures.Add(loadImage(file.FullName));
            }
        }
    }




    private Texture2D loadImage(string path) {
        Texture2D texture = null;
        byte[] fileData;

        if(File.Exists(path)){
            fileData = File.ReadAllBytes(path);
            texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
        }

        return texture;
    }
}
