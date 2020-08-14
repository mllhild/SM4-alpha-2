using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SM4OptionClass
{
    // Gameplay
    public bool isOnSandboxmode = true;
    public bool isOnLimitSaving = true;
    public bool isOnDebugMode = true;
    public bool isOnCheatsEnabled = true;
    public int valueDifficultyDropdown = 0;
    public int valueCombatDifficultyDropdown = 0;

    //Content
    public bool isOnNonHumanSexEnabled = true;
    public bool isOnFurriesEnabled = true;
    public bool isOnBestiaryEnabled = true;
    public bool isOnTentaclesEnabled = true;
    public int valueTentaclesDropdown = 0;
    public bool isOnFutanariEnabled = true;
    public int valueFutanariDropdown = 0;
    public bool isOnPermanentFutaTransformation = true;
    public bool isOnLesbiansLoveFutas = true;
    public bool isOnFutasCanHaveBalls = true;
    public bool isOnFemaleSlavesStartAsFutas = true;
    public bool isOnHumanPetsEnabled = true;
    public bool isOnHumanCattleEnabled = true;
    public bool isOnPonyGirlTrainingEnabled = true;
    public bool isOnCowGirlTrainingEnabled = true;
    public bool isOnRapeEnabled = true;
    public bool isOnVoreEnabled = true;
    public bool isOnGoreGuroEnabled = true;
    public bool isOnPregnancyEnabled = true;
    public bool isOnIncestEnabled = true;
    public bool isOnGiantGenitalsEnabled = true;
    public bool isOnBadEndsEnabled = true;
    public bool isOnLoliShotaEnabled = true;

    //Appearance
    public bool isOnTutorialEnabled = true;
    public bool isOnClockHas24Hours = true;
    public bool isOnFullscreenEnabled = true;
    public int valueResolutionsDropdown = 0;
    public bool isOnImperialUnitsEnabled = true;
    public int valueLanguageDropdown = 0;
    public int valueUIDropdown = 0;

    //Sound
    public bool isOnMasterVolumeEnabled = true;
    public float valueMasterVolumeSlider = 1;
    public bool isOnMenuSFXEnabled = true;
    public float valueMenuSFXSlider = 1;
    public bool isOnCombatSFXEnabled = true;
    public float valueCombatSFXSlider = 1;
    public bool isOnMusicEnabled = true;
    public float valueMusicSlider = 1;
    public bool isOnEffectsSFXEnabled = true;
    public float valueEffectsSFXSlider = 1;

    
    
    // Resolution
    Resolution[] resolutions;
    public List<int> resolutionWidth = new List<int>();
    public List<int> resolutionHeight = new List<int>();

    
    


    public void SaveOptions(SM4OptionClass optionClass)
    {
        string path = Path.Combine(Application.streamingAssetsPath + "options.xml");
        FileStream stream = new FileStream(@path, FileMode.Create);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SM4OptionClass));
        xmlSerializer.Serialize(stream, optionClass);
        stream.Close();
    }
    
    public void LoadOptions(SM4OptionClass optionClass, bool firstAttemp)
    {

        string path = Path.Combine(Application.streamingAssetsPath + "options.xml");
        try
        {
            FileStream stream = new FileStream(@path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SM4OptionClass));
            optionClass = xmlSerializer.Deserialize(stream) as SM4OptionClass;
            stream.Close();
        }
        catch
        {
            SM4OptionClass emptyOptions = new SM4OptionClass();
            optionClass = emptyOptions;
            SaveOptions(optionClass);
        }
    }
}
