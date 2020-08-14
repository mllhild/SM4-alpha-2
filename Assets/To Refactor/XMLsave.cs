using System.Collections;
using System.Collections.Generic; // lets us use lists
using UnityEngine;
using System.Xml; // basic XML attributes
using System.Xml.Serialization; // access xml serializer
using System.IO;  // file management
using UnityEngine.UI;


public class XMLsave : MonoBehaviour
{/*
    public DataBaseOptionMenu dbOptions;
    public MenuOptions menuOptions;
    public DataBaseSlaveMaker dbSlaveMaker;
    public SlaveMaker SM;
    public DataBaseSlave dbSlave;
    public Slave slave;
    public DataBaseAssistant dbAssistant;
    public Assistant assistant;

    public Savefile savedata;

    public static XMLsave ins;
    */




    void Awake()
    {
        //ins = this;// makes instance to the xml manager?
    }
    public void GetData()
    {
        //dbOptions.Sandboxmode = 
    }

    public string SavePath(string addToPath) // finds save path
    {
        string path;
        if (Application.isEditor)
        {
            // path = "C:/Unity/SM/User/Saves/item_data" + staticInt.ToString() + ".xml";
        }
        else
        {
            // path = Application.dataPath + "/item_data" + staticInt.ToString() + ".xml";
        }
        path = "C:/SlaveMaker4/" + addToPath;
        return path;
    }


    // saves the file, classType is a string to know the file type
    public void Save(string fileFolder, string fileName, string classType)
    { /*
        // you need to push the data from the GameObject to the Database
        // since Serializable files cant be added to game objects
        // this will also be a pain later on with parsing
        GOdataToDBdata();
        string saveFilePath = SavePath(fileFolder) + "/" + fileName + ".xml";
        //checks if save directory exists
        if (!Directory.Exists(SavePath(fileFolder)))
        {
            //creates save directory
            Directory.CreateDirectory(SavePath(fileFolder));
        }
        // creates file stream and creates file
        FileStream stream = new FileStream(saveFilePath, FileMode.Create);
        // chooses the serializer type
        switch (classType)
        {
            case "DataBaseSlave":
                //start xml Serializer
                XmlSerializer xmlSerializerSlave = new XmlSerializer(typeof(DataBaseSlave));
                //takes info from unity class and puts it in the xml
                xmlSerializerSlave.Serialize(stream, dbSlave);

                break;
            case "DataBaseSlaveMaker":

                XmlSerializer xmlSerializerSM = new XmlSerializer(typeof(DataBaseSlaveMaker));
                xmlSerializerSM.Serialize(stream, dbSlaveMaker);
                Debug.LogFormat("Saved SlaveMaker of family {0}", dbSlaveMaker.familyname);
                break;
            case "DataBaseAssistant":
                XmlSerializer xmlSerializerAssistant = new XmlSerializer(typeof(DataBaseAssistant));
                xmlSerializerAssistant.Serialize(stream, dbAssistant);
                break;
            case "DataBaseOptionMenu":
                XmlSerializer xmlSerializerOptions = new XmlSerializer(typeof(DataBaseOptionMenu));
                xmlSerializerOptions.Serialize(stream, dbOptions);
                break;
            default:
                stream.Close();
                saveFilePath = SavePath(fileFolder) + "/Mega.xml";
                FileStream stream2 = new FileStream(saveFilePath, FileMode.Create);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataBaseOptionMenu));
                xmlSerializer.Serialize(stream2, dbOptions);
                Debug.LogFormat("Command Save, wrong string classType {0}", classType);
                Debug.LogFormat("To be saved as {0}", saveFilePath);
                Debug.LogFormat("So a mega save was created");
                stream2.Close();
                return;
        }

        // closes stream. fatal error if you try to open two streams at once
        stream.Close();
        
        */
    }


    public void Load(string fileFolder, string fileName, string classType)
    { /*
        string saveFilePath = SavePath(fileFolder) + "/" + fileName + ".xml";
        Debug.LogFormat("To be loaded from {0}", saveFilePath);
        //checks if load directory exists
        if (!Directory.Exists(SavePath(fileFolder)))
        {
            //creates load directory
            Directory.CreateDirectory(SavePath(fileFolder));
        }
        // check if file exists, if not then it stops the load
        if (!File.Exists(saveFilePath))
        {
            Debug.LogFormat("File {0}  did NOT exist", saveFilePath);
            return;
        }

        // opens file
        FileStream stream = new FileStream(saveFilePath, FileMode.Open);
        ////if (stream.Position > 0)
        ////{stream.Position = 0;}
        try
        {

            switch (classType)
            {
                case "DataBaseSlave":
                    //start xml Serializer
                    XmlSerializer xmlSerializerSlave = new XmlSerializer(typeof(DataBaseSlave));
                    //takes info from unity class and puts it in the xml
                    dbSlave = xmlSerializerSlave.Deserialize(stream) as DataBaseSlave;
                    break;
                case "DataBaseSlaveMaker":

                    XmlSerializer xmlSerializerSM = new XmlSerializer(typeof(DataBaseSlaveMaker));
                    dbSlaveMaker = xmlSerializerSM.Deserialize(stream) as DataBaseSlaveMaker;
                    BDdataToGOdataSM();
                    Debug.LogFormat("Loaded SlaveMaker of family {0}", dbSlaveMaker.familyname);
                    break;
                case "DataBaseAssistant":
                    XmlSerializer xmlSerializerAssistant = new XmlSerializer(typeof(DataBaseAssistant));
                    dbAssistant = xmlSerializerAssistant.Deserialize(stream) as DataBaseAssistant;
                    break;
                case "DataBaseOptionMenu":
                    XmlSerializer xmlSerializerOptions = new XmlSerializer(typeof(DataBaseOptionMenu));
                    dbOptions = xmlSerializerOptions.Deserialize(stream) as DataBaseOptionMenu;
                    break;
                default:
                    Debug.LogFormat("Command Load, wrong string classType {0}", classType);
                    Debug.LogFormat("To be loaded as {0}", saveFilePath);
                    break;
            }

            stream.Close();
            return;
        }
        catch
        {
            stream.Close();
            Debug.LogFormat("Failed to load from saveFilePath: {0}", saveFilePath);
            return;
        }
        */
    }

    // you need to push the data from the GameObject to the Database
    // since Serializable files cant be added to game objects
    // this will also be a pain later on with parsing
    public void GOdataToDBdata()
    {
        /*
        GOdataToDBdataSM();
        GOdataToDBdataOptions();
        savedata.dbOptionMenu = dbOptions;
        savedata.dbSM = dbSlaveMaker;
        */

    }
    public void GOdataToDBdataSM()
    {
        //dbSlaveMaker.Index = SM.Index;
        //dbSlaveMaker.gender = SM.gender;
        //dbSlaveMaker.bool1 = SM.bool1;
        //dbSlaveMaker.bool2 = SM.bool2;
        //dbSlaveMaker.bool3 = SM.bool3;
        //dbSlaveMaker.stat1 = SM.stat1;
        //dbSlaveMaker.stat2 = SM.stat2;
        //dbSlaveMaker.stat3 = SM.stat3;
        //dbSlaveMaker.name1 = SM.name1;
        //dbSlaveMaker.name2 = SM.name2;
        //dbSlaveMaker.name3 = SM.name3;
        //dbSlaveMaker.familyname = SM.familyname;

    }
    public void BDdataToGOdataSM()
    {
        //SM.Index = dbSlaveMaker.Index;
        //SM.gender = dbSlaveMaker.gender;
        //SM.bool1 = dbSlaveMaker.bool1;
        //SM.bool2 = dbSlaveMaker.bool2;
        //SM.bool3 = dbSlaveMaker.bool3;
        //SM.stat1 = dbSlaveMaker.stat1;
        //SM.stat2 = dbSlaveMaker.stat2;
        //SM.stat3 = dbSlaveMaker.stat3;
        //SM.name1 = dbSlaveMaker.name1;
        //SM.name2 = dbSlaveMaker.name2;
        //SM.name3 = dbSlaveMaker.name3;
        //SM.familyname = dbSlaveMaker.familyname;

    }

    public void GOdataToDBdataOptions()
    {
        /*
        // Gameplay 
        dbOptions.Sandboxmode = menuOptions.Sandboxmode.isOn;
        dbOptions.LimitSaving = menuOptions.LimitSaving.isOn;
        dbOptions.DebugMode = menuOptions.DebugMode.isOn;
        dbOptions.CheatsEnabled = menuOptions.CheatsEnabled.isOn;
        dbOptions.DifficultyDropdown = menuOptions.DifficultyDropdown.value;
        dbOptions.CombatDifficultyDropdown = menuOptions.CombatDifficultyDropdown.value;


        //Content							
        dbOptions.NonHumanSexEnabled = menuOptions.NonHumanSexEnabled.isOn;
        dbOptions.FurriesEnabled = menuOptions.FurriesEnabled.isOn;
        dbOptions.BestiaryEnabled = menuOptions.BestiaryEnabled.isOn;
        dbOptions.TentaclesEnabled = menuOptions.TentaclesEnabled.isOn;
        dbOptions.TentaclesDropdown = menuOptions.TentaclesDropdown.value;
        dbOptions.FutanariEnabled = menuOptions.FutanariEnabled.isOn;
        dbOptions.FutanariDropdown = menuOptions.FutanariDropdown.value;
        dbOptions.PermanentFutaTransformation = menuOptions.PermanentFutaTransformation.isOn;
        dbOptions.LesbiansLoveFutas = menuOptions.LesbiansLoveFutas.isOn;
        dbOptions.FutasCanHaveBalls = menuOptions.FutasCanHaveBalls.isOn;
        dbOptions.FemaleSlavesStartAsFutas = menuOptions.FemaleSlavesStartAsFutas.isOn;
        dbOptions.HumanPetsEnabled = menuOptions.HumanPetsEnabled.isOn;
        dbOptions.HumanCattleEnabled = menuOptions.HumanCattleEnabled.isOn;
        dbOptions.PonyGirlTrainingEnabled = menuOptions.PonyGirlTrainingEnabled.isOn;
        dbOptions.CowGirlTrainingEnabled = menuOptions.CowGirlTrainingEnabled.isOn;
        dbOptions.RapeEnabled = menuOptions.RapeEnabled.isOn;
        dbOptions.VoreEnabled = menuOptions.VoreEnabled.isOn;
        dbOptions.GoreGuroEnabled = menuOptions.GoreGuroEnabled.isOn;
        dbOptions.PregnancyEnabled = menuOptions.PregnancyEnabled.isOn;
        dbOptions.IncestEnabled = menuOptions.IncestEnabled.isOn;
        dbOptions.GiantGenitalsEnabled = menuOptions.GiantGenitalsEnabled.isOn;
        dbOptions.BadEndsEnabled = menuOptions.BadEndsEnabled.isOn;
        dbOptions.LoliShotaEnabled = menuOptions.LoliShotaEnabled.isOn;


        //Appearance								
        dbOptions.TutorialEnabled = menuOptions.TutorialEnabled.isOn;
        dbOptions.ClockHas24Hours = menuOptions.ClockHas24Hours.isOn;
        dbOptions.FullscreenEnabled = menuOptions.FullscreenEnabled.isOn;
        dbOptions.ResolutionsDropdown = menuOptions.ResolutionsDropdown.value;
        dbOptions.ImperialUnitsEnabled = menuOptions.ImperialUnitsEnabled.isOn;
        dbOptions.LanguageDropdown = menuOptions.LanguageDropdown.value;
        dbOptions.UIDropdown = menuOptions.UIDropdown.value;


        //Sound						
        dbOptions.MasterVolumeEnabled = menuOptions.MasterVolumeEnabled.isOn;
        dbOptions.MasterVolumeSlider = menuOptions.MasterVolumeSlider.value;
        dbOptions.MenuSFXEnabled = menuOptions.MenuSFXEnabled.isOn;
        dbOptions.MenuSFXSlider = menuOptions.MenuSFXSlider.value;
        dbOptions.CombatSFXEnabled = menuOptions.CombatSFXEnabled.isOn;
        dbOptions.CombatSFXSlider = menuOptions.CombatSFXSlider.value;
        dbOptions.MusicEnabled = menuOptions.MusicEnabled.isOn;
        dbOptions.MusicSlider = menuOptions.MusicSlider.value;
        dbOptions.EffectsSFXEnabled = menuOptions.EffectsSFXEnabled.isOn;
        dbOptions.EffectsSFXSlider = menuOptions.EffectsSFXSlider.value;
        
        */

    }
    public void DBdataToGOdataOptions()
    {
        /*
        //Gameplay			
        menuOptions.Sandboxmode.isOn = dbOptions.Sandboxmode;
        menuOptions.LimitSaving.isOn = dbOptions.LimitSaving;
        menuOptions.DebugMode.isOn = dbOptions.DebugMode;
        menuOptions.CheatsEnabled.isOn = dbOptions.CheatsEnabled;
        menuOptions.DifficultyDropdown.value = dbOptions.DifficultyDropdown;
        menuOptions.CombatDifficultyDropdown.value = dbOptions.CombatDifficultyDropdown;


        //Content							
        menuOptions.NonHumanSexEnabled.isOn = dbOptions.NonHumanSexEnabled;
        menuOptions.FurriesEnabled.isOn = dbOptions.FurriesEnabled;
        menuOptions.BestiaryEnabled.isOn = dbOptions.BestiaryEnabled;
        menuOptions.TentaclesEnabled.isOn = dbOptions.TentaclesEnabled;
        menuOptions.TentaclesDropdown.value = dbOptions.TentaclesDropdown;
        menuOptions.FutanariEnabled.isOn = dbOptions.FutanariEnabled;
        menuOptions.FutanariDropdown.value = dbOptions.FutanariDropdown;
        menuOptions.PermanentFutaTransformation.isOn = dbOptions.PermanentFutaTransformation;
        menuOptions.LesbiansLoveFutas.isOn = dbOptions.LesbiansLoveFutas;
        menuOptions.FutasCanHaveBalls.isOn = dbOptions.FutasCanHaveBalls;
        menuOptions.FemaleSlavesStartAsFutas.isOn = dbOptions.FemaleSlavesStartAsFutas;
        menuOptions.HumanPetsEnabled.isOn = dbOptions.HumanPetsEnabled;
        menuOptions.HumanCattleEnabled.isOn = dbOptions.HumanCattleEnabled;
        menuOptions.PonyGirlTrainingEnabled.isOn = dbOptions.PonyGirlTrainingEnabled;
        menuOptions.CowGirlTrainingEnabled.isOn = dbOptions.CowGirlTrainingEnabled;
        menuOptions.RapeEnabled.isOn = dbOptions.RapeEnabled;
        menuOptions.VoreEnabled.isOn = dbOptions.VoreEnabled;
        menuOptions.GoreGuroEnabled.isOn = dbOptions.GoreGuroEnabled;
        menuOptions.PregnancyEnabled.isOn = dbOptions.PregnancyEnabled;
        menuOptions.IncestEnabled.isOn = dbOptions.IncestEnabled;
        menuOptions.GiantGenitalsEnabled.isOn = dbOptions.GiantGenitalsEnabled;
        menuOptions.BadEndsEnabled.isOn = dbOptions.BadEndsEnabled;
        menuOptions.LoliShotaEnabled.isOn = dbOptions.LoliShotaEnabled;


        //Appearance								
        menuOptions.TutorialEnabled.isOn = dbOptions.TutorialEnabled;
        menuOptions.ClockHas24Hours.isOn = dbOptions.ClockHas24Hours;
        menuOptions.FullscreenEnabled.isOn = dbOptions.FullscreenEnabled;
        menuOptions.ResolutionsDropdown.value = dbOptions.ResolutionsDropdown;
        menuOptions.ImperialUnitsEnabled.isOn = dbOptions.ImperialUnitsEnabled;
        menuOptions.LanguageDropdown.value = dbOptions.LanguageDropdown;
        menuOptions.UIDropdown.value = dbOptions.UIDropdown;


        //Sound						
        menuOptions.MasterVolumeEnabled.isOn = dbOptions.MasterVolumeEnabled;
        menuOptions.MasterVolumeSlider.value = dbOptions.MasterVolumeSlider;
        menuOptions.MenuSFXEnabled.isOn = dbOptions.MenuSFXEnabled;
        menuOptions.MenuSFXSlider.value = dbOptions.MenuSFXSlider;
        menuOptions.CombatSFXEnabled.isOn = dbOptions.CombatSFXEnabled;
        menuOptions.CombatSFXSlider.value = dbOptions.CombatSFXSlider;
        menuOptions.MusicEnabled.isOn = dbOptions.MusicEnabled;
        menuOptions.MusicSlider.value = dbOptions.MusicSlider;
        menuOptions.EffectsSFXEnabled.isOn = dbOptions.EffectsSFXEnabled;
        menuOptions.EffectsSFXSlider.value = dbOptions.EffectsSFXSlider;
        
        */


    }
    
}

