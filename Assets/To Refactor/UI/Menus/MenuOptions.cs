using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Xml; // basic XML attributes
using System.Xml.Serialization; // access xml serializer
using System.IO;  // file management

public class MenuOptions : MonoBehaviour
{
    public int whereToReturnTo;
    // Gameplay
    public Toggle Sandboxmode;
    public Toggle LimitSaving;
    public Toggle DebugMode;
    public Toggle CheatsEnabled;
    public Dropdown DifficultyDropdown;
    public Dropdown CombatDifficultyDropdown;

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

    //Appearance
    public Toggle TutorialEnabled;
    public Toggle ClockHas24Hours;
    public Toggle FullscreenEnabled;
    public Dropdown ResolutionsDropdown;
    public Toggle ImperialUnitsEnabled;
    public Dropdown LanguageDropdown;
    public Dropdown UIDropdown;

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

    
    Resolution[] resolutions;
    public List<int> resolutionWidth = new List<int>();
    public List<int> resolutionHeight = new List<int>();

    public AudioMixer audioMixer;


    void Start()
    {

        
    }
    
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
                        string option = resolutions[i].width + " x " + resolutions[i].height;
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
                    string option = resolutions[i].width + " x " + resolutions[i].height;
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
        //DebugLogFormat("{0}", currentResolutionIndex);
        ResolutionsDropdown.value = currentResolutionIndex;
        ResolutionsDropdown.RefreshShownValue();
        FullscreenEnabled.isOn = Screen.fullScreen;
    }
    public void SetFullscreen()
    {
        Screen.fullScreen = FullscreenEnabled.isOn;
        //DebugLogFormat("SetFullscreen {0}", FullscreenEnabled.isOn);
    }
    public void SetScreenResolution()
    {
        //DebugLogFormat("SetScreenResolution {0}", resolutionHeight[ResolutionsDropdown.value]);
        //DebugLogFormat("SetScreenResolution {0}", resolutionWidth[ResolutionsDropdown.value]);
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
        //DebugLog(volume);
    }


    // ------------------ SAVE LOAD PART --------------------------------------------
    public XMLsave xmlSave;

    public void SaveOptionsToFile()
    {
        xmlSave.Save("Core", "Config", "DataBaseOptionMenu");
    }
    public void LoadOptionsFromFile()
    {
        xmlSave.Load("Core", "Config", "DataBaseOptionMenu");
    }

}

