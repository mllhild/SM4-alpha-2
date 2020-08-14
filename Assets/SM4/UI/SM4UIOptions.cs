using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class SM4UIOptions : MonoBehaviour
{

    public Button gamepalyButton;
    public Button contentButtton;
    public Button appearanceButton;
    public Button soundButton;
    public Button returnButton;
    
    public GameObject gtab;
    public GameObject ctab;
    public GameObject atab;
    public GameObject stab;
    public GameObject previousMenu;

    public SM4OptionClass options;

    private void Awake()
    {
        ShowAppearanceTab();
        ShowContentTab();
        ShowSoundTab();
        ShowGamePlayTab();
        var toggles = GetComponentsInChildren<Toggle>();
        foreach (var toggle in toggles)
        {
            toggle.onValueChanged.AddListener(delegate(bool arg0) { MenuToClass(); });
        }
        var sliders = GetComponentsInChildren<Slider>();
        foreach (var slider in sliders)
        {
            slider.onValueChanged.AddListener(delegate(float arg0) { MenuToClass(); });
        }
        var dropdowns = GetComponentsInChildren<Dropdown>();
        foreach (var dropdown in dropdowns)
        {
            dropdown.onValueChanged.AddListener(delegate(int arg0) { MenuToClass(); });
        }
        RemoveFunctionsFromButtons();
        AssignFunctionsToButtons();
    }



    public void OpenOptionMenu(GameObject menuToReturnTo)
    {
        
        options = new SM4OptionClass();
        options.LoadOptions(options,true);
        GetResolutions();
        previousMenu = menuToReturnTo;
        HideTabs();
        ClassToMenu();
        ShowGamePlayTab();
        
        
    }
    
    // this if for use form the pause menu in game
    public void OpenOptionMenu()
    {
        options = World.instance.options;
        options.LoadOptions(options,true);
        GetResolutions();
        previousMenu = null;
        HideTabs();
        ClassToMenu();
        ShowGamePlayTab();
        

    }

    public void CloseOptionMenu()
    {
        MenuToClass();
        options.SaveOptions(options);
        HideTabs();
        if(previousMenu!= null)
            previousMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void RemoveFunctionsFromButtons()
    {
        returnButton.onClick.RemoveAllListeners();
        gamepalyButton.onClick.RemoveAllListeners();
        appearanceButton.onClick.RemoveAllListeners();
        contentButtton.onClick.RemoveAllListeners();
        soundButton.onClick.RemoveAllListeners();
    }
    private void AssignFunctionsToButtons()
    {
        returnButton.onClick.AddListener(CloseOptionMenu);
        gamepalyButton.onClick.AddListener(ShowGamePlayTab);
        appearanceButton.onClick.AddListener(ShowAppearanceTab);
        contentButtton.onClick.AddListener(ShowContentTab);
        soundButton.onClick.AddListener(ShowSoundTab);
    }
    

    private void HideTabs()
    {
        gtab.SetActive(false);
        ctab.SetActive(false);
        atab.SetActive(false);
        stab.SetActive(false);
    }
    
// Gameplay
    public Toggle Sandboxmode;
    public Toggle LimitSaving;
    public Toggle DebugMode;
    public Toggle CheatsEnabled;
    public Dropdown DifficultyDropdown;
    public Dropdown CombatDifficultyDropdown;

    private void ShowGamePlayTab()
    {
        HideTabs();
        gtab.SetActive(true);
    }
    
    
//Content
    public Toggle NonHumanSexEnabled;
    public Toggle FurriesEnabled;
    public Toggle BestiaryEnabled;
    public Toggle TentaclesEnabled;
    public Dropdown TentaclesDropdown;
    public Toggle FutanariEnabled;
    public Dropdown FutanariDropdown;
    public Toggle PermanentFutaTransformation;
    public Toggle LesbiansLoveFutas;
    public Toggle FutasCanHaveBalls;
    public Toggle FemaleSlavesStartAsFutas;
    public Toggle HumanPetsEnabled;
    public Toggle HumanCattleEnabled;
    public Toggle PonyGirlTrainingEnabled;
    public Toggle CowGirlTrainingEnabled;
    public Toggle RapeEnabled;
    public Toggle VoreEnabled;
    public Toggle GoreGuroEnabled;
    public Toggle PregnancyEnabled;
    public Toggle IncestEnabled;
    public Toggle GiantGenitalsEnabled;
    public Toggle BadEndsEnabled;
    public Toggle LoliShotaEnabled;
    private void ShowContentTab()
    {
        HideTabs();
        ctab.SetActive(true);
    }
    
    
//Appearance
    public Toggle TutorialEnabled;
    public Toggle ClockHas24Hours;
    public Toggle FullscreenEnabled;
    public Dropdown ResolutionsDropdown;
    public Toggle ImperialUnitsEnabled;
    public Dropdown LanguageDropdown;
    public Dropdown UIDropdown;
    
// Resolution
    Resolution[] resolutions;
    public List<int> resolutionWidth = new List<int>();
    public List<int> resolutionHeight = new List<int>();
    
    public void GetResolutions()
    {
        resolutions = Screen.resolutions;
        ResolutionsDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        int currentResolutionIndex2 = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].height == 720 || resolutions[i].height == 733 || resolutions[i].height == 1080 || resolutions[i].height == 1440 || resolutions[i].height == 2160)
            {
                if (i != 0)
                {
                    if (resolutions[i].height != resolutions[i - 1].height)
                    {
                        resolutionWidth.Add(resolutions[i].width);
                        resolutionHeight.Add(resolutions[i].height);
                        string option = resolutions[i].width.ToString() + " x " + resolutions[i].height.ToString();
                        options.Add(option);
                        if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                        {
                            currentResolutionIndex = currentResolutionIndex2;
                        }
                    }
                }
                else
                {
                    resolutionWidth.Add(resolutions[i].width);
                    resolutionHeight.Add(resolutions[i].height);
                    string option = resolutions[i].width.ToString() + " x " + resolutions[i].height.ToString();
                    options.Add(option);
                    if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                    {
                        currentResolutionIndex = currentResolutionIndex2;
                    }
                }
                
                currentResolutionIndex2++;
            }
        }

        ResolutionsDropdown.AddOptions(options);
        ResolutionsDropdown.value = currentResolutionIndex;
        ResolutionsDropdown.RefreshShownValue();
        FullscreenEnabled.isOn = Screen.fullScreen;
    }
    
    public void SetFullscreen()
    {
        Screen.fullScreen = FullscreenEnabled.isOn;
    }
    public void SetScreenResolution()
    {
        Screen.SetResolution(resolutionWidth[ResolutionsDropdown.value], resolutionHeight[ResolutionsDropdown.value], FullscreenEnabled.isOn);
    }

    public void SetResolution(int resolutionIndex) //update screen resolution
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    
    private void ShowAppearanceTab()
    {
        HideTabs();
        atab.SetActive(true);
    }
    
//Sound
    public Toggle MasterVolumeEnabled;
    public Slider MasterVolumeSlider;
    public Toggle MenuSFXEnabled;
    public Slider MenuSFXSlider;
    public Toggle CombatSFXEnabled;
    public Slider CombatSFXSlider;
    public Toggle MusicEnabled;
    public Slider MusicSlider;
    public Toggle EffectsSFXEnabled;
    public Slider EffectsSFXSlider;
// AudioChannels
    public AudioMixer audioMixer;
    private void ShowSoundTab()
    {
        HideTabs();
        stab.SetActive(true);
    }
    
    
   
// Save Load
    public void MenuToClass()
    {
        // Gameplay	//Gameplay
    Sandboxmode.isOn 	= options.isOnSandboxmode;
    LimitSaving.isOn 	= options.isOnLimitSaving;
    DebugMode.isOn 	= options.isOnDebugMode;
    CheatsEnabled.isOn 	= options.isOnCheatsEnabled;
    DifficultyDropdown.value 	= options.valueDifficultyDropdown;
    CombatDifficultyDropdown.value 	= options.valueCombatDifficultyDropdown;
	
  //Content	//Content
    NonHumanSexEnabled.isOn 	= options.isOnNonHumanSexEnabled;
    FurriesEnabled.isOn 	= options.isOnFurriesEnabled;
    BestiaryEnabled.isOn 	= options.isOnBestiaryEnabled;
    TentaclesEnabled.isOn 	= options.isOnTentaclesEnabled;
    TentaclesDropdown.value 	= options.valueTentaclesDropdown;
    FutanariEnabled.isOn 	= options.isOnFutanariEnabled;
    FutanariDropdown.value 	= options.valueFutanariDropdown;
    PermanentFutaTransformation.isOn 	= options.isOnPermanentFutaTransformation;
    LesbiansLoveFutas.isOn 	= options.isOnLesbiansLoveFutas;
    FutasCanHaveBalls.isOn 	= options.isOnFutasCanHaveBalls;
    FemaleSlavesStartAsFutas.isOn 	= options.isOnFemaleSlavesStartAsFutas;
    HumanPetsEnabled.isOn 	= options.isOnHumanPetsEnabled;
    HumanCattleEnabled.isOn 	= options.isOnHumanCattleEnabled;
    PonyGirlTrainingEnabled.isOn 	= options.isOnPonyGirlTrainingEnabled;
    CowGirlTrainingEnabled.isOn 	= options.isOnCowGirlTrainingEnabled;
    RapeEnabled.isOn 	= options.isOnRapeEnabled;
    VoreEnabled.isOn 	= options.isOnVoreEnabled;
    GoreGuroEnabled.isOn 	= options.isOnGoreGuroEnabled;
    PregnancyEnabled.isOn 	= options.isOnPregnancyEnabled;
    IncestEnabled.isOn 	= options.isOnIncestEnabled;
    GiantGenitalsEnabled.isOn 	= options.isOnGiantGenitalsEnabled;
    BadEndsEnabled.isOn 	= options.isOnBadEndsEnabled;
    LoliShotaEnabled.isOn 	= options.isOnLoliShotaEnabled;
	
  //Appearance	//Appearance
    TutorialEnabled.isOn 	= options.isOnTutorialEnabled;
    ClockHas24Hours.isOn 	= options.isOnClockHas24Hours;
    FullscreenEnabled.isOn 	= options.isOnFullscreenEnabled;
    ResolutionsDropdown.value	= options.valueResolutionsDropdown;
    ImperialUnitsEnabled.isOn 	= options.isOnImperialUnitsEnabled;
    LanguageDropdown.value 	= options.valueLanguageDropdown;
    UIDropdown.value 	= options.valueUIDropdown;
	
  //Sound	//Sound
    MasterVolumeEnabled.isOn 	= options.isOnMasterVolumeEnabled;
    MasterVolumeSlider.value 	= options.valueMasterVolumeSlider;
    MenuSFXEnabled.isOn 	= options.isOnMenuSFXEnabled;
    MenuSFXSlider.value 	= options.valueMenuSFXSlider;
    CombatSFXEnabled.isOn 	= options.isOnCombatSFXEnabled;
    CombatSFXSlider.value 	= options.valueCombatSFXSlider;
    MusicEnabled.isOn 	= options.isOnMusicEnabled;
    MusicSlider.value 	= options.valueMusicSlider;
    EffectsSFXEnabled.isOn 	= options.isOnEffectsSFXEnabled;
    EffectsSFXSlider.value 	= options.valueEffectsSFXSlider;

    }
    public void ClassToMenu()
    {
        //Gameplay
        options.isOnSandboxmode = Sandboxmode.isOn ;
        options.isOnLimitSaving = LimitSaving.isOn ;
        options.isOnDebugMode = DebugMode.isOn ;
        options.isOnCheatsEnabled = CheatsEnabled.isOn ;
        options.valueDifficultyDropdown = DifficultyDropdown.value ;
        options.valueCombatDifficultyDropdown = CombatDifficultyDropdown.value ;
          
         //Content //Content 
        options.isOnNonHumanSexEnabled = NonHumanSexEnabled.isOn ;
        options.isOnFurriesEnabled = FurriesEnabled.isOn ;
        options.isOnBestiaryEnabled = BestiaryEnabled.isOn ;
        options.isOnTentaclesEnabled = TentaclesEnabled.isOn ;
        options.valueTentaclesDropdown = TentaclesDropdown.value ;
        options.isOnFutanariEnabled = FutanariEnabled.isOn ;
        options.valueFutanariDropdown = FutanariDropdown.value ;
        options.isOnPermanentFutaTransformation = PermanentFutaTransformation.isOn ;
        options.isOnLesbiansLoveFutas = LesbiansLoveFutas.isOn ;
        options.isOnFutasCanHaveBalls = FutasCanHaveBalls.isOn ;
        options.isOnFemaleSlavesStartAsFutas = FemaleSlavesStartAsFutas.isOn ;
        options.isOnHumanPetsEnabled = HumanPetsEnabled.isOn ;
        options.isOnHumanCattleEnabled = HumanCattleEnabled.isOn ;
        options.isOnPonyGirlTrainingEnabled = PonyGirlTrainingEnabled.isOn ;
        options.isOnCowGirlTrainingEnabled = CowGirlTrainingEnabled.isOn ;
        options.isOnRapeEnabled = RapeEnabled.isOn ;
        options.isOnVoreEnabled = VoreEnabled.isOn ;
        options.isOnGoreGuroEnabled = GoreGuroEnabled.isOn ;
        options.isOnPregnancyEnabled = PregnancyEnabled.isOn ;
        options.isOnIncestEnabled = IncestEnabled.isOn ;
        options.isOnGiantGenitalsEnabled = GiantGenitalsEnabled.isOn ;
        options.isOnBadEndsEnabled = BadEndsEnabled.isOn ;
        options.isOnLoliShotaEnabled = LoliShotaEnabled.isOn ;
          
         //Appearance //Appearance 
        options.isOnTutorialEnabled = TutorialEnabled.isOn ;
        options.isOnClockHas24Hours = ClockHas24Hours.isOn ;
        options.isOnFullscreenEnabled = FullscreenEnabled.isOn ;
        options.valueResolutionsDropdown = ResolutionsDropdown.value;
        options.isOnImperialUnitsEnabled = ImperialUnitsEnabled.isOn ;
        options.valueLanguageDropdown = LanguageDropdown.value ;
        options.valueUIDropdown = UIDropdown.value ;
          
         //Sound //Sound 
        options.isOnMasterVolumeEnabled = MasterVolumeEnabled.isOn ;
        options.valueMasterVolumeSlider = MasterVolumeSlider.value ;
        options.isOnMenuSFXEnabled = MenuSFXEnabled.isOn ;
        options.valueMenuSFXSlider = MenuSFXSlider.value ;
        options.isOnCombatSFXEnabled = CombatSFXEnabled.isOn ;
        options.valueCombatSFXSlider = CombatSFXSlider.value ;
        options.isOnMusicEnabled = MusicEnabled.isOn ;
        options.valueMusicSlider = MusicSlider.value ;
        options.isOnEffectsSFXEnabled = EffectsSFXEnabled.isOn ;
        options.valueEffectsSFXSlider = EffectsSFXSlider.value ;
        options.isOnSandboxmode = Sandboxmode.isOn ;
        options.isOnLimitSaving = LimitSaving.isOn ;
        options.isOnDebugMode = DebugMode.isOn ;
        options.isOnCheatsEnabled = CheatsEnabled.isOn ;
        options.valueDifficultyDropdown = DifficultyDropdown.value ;
        options.valueCombatDifficultyDropdown = CombatDifficultyDropdown.value ;
        

    }
    
    
    
}
