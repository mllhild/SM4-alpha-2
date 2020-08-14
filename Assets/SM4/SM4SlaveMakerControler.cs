using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SM4SlaveMakerControler : MonoBehaviour
{
    public SM4SlaveMaker slaveMaker = new SM4SlaveMaker();
    public static SM4SlaveMakerControler instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            ErrorLogger.LogErrorInFile("Error in SM4SlaveMakerControler");
            Destroy(gameObject);   
        }
    }

    private void Start()
    {
        
    }

    public void AutoSaveSave()
    {
        var path = Path.Combine(Application.streamingAssetsPath, "Saves/AutoSave/");
        SaveSlaveMaker(@path);
    }
    public void AutoSaveLoad()
    {
        var path = Path.Combine(Application.streamingAssetsPath, "Saves/AutoSave/");
        LoadSlaveMaker(@path);
    }
    
    public void SaveSlaveMaker(string path)
    {
        FileStream stream = new FileStream(Path.Combine(path,  "SlaveMaker.xml"), FileMode.Create);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SM4SlaveMaker));
        xmlSerializer.Serialize(stream, slaveMaker);
        stream.Close();
    }
    public void LoadSlaveMaker(string path)
    {
        try
        {
            FileStream stream = new FileStream(Path.Combine(path, "SlaveMaker.xml"), FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SM4SlaveMaker));
            slaveMaker = xmlSerializer.Deserialize(stream) as SM4SlaveMaker;
            stream.Close();
        }
        catch
        {
            ErrorLogger.LogErrorInFile("Error in SlaveContainer Load with " + path.ToString() + "/SlaveMaker.xml");
        }
        finally
        {
            
        }

    }

    public void PrintVariables()
    {/*
       // very much used 
        // - slaveMaker.generalSM.supervise;
        //slaveMaker.generalSM.masterMistress what you get called
        //slaveMaker.text.;
        slaveMaker.stats.blowjob;
        slaveMaker.stats.charisma;
        slaveMaker.stats.cleaning;
        slaveMaker.stats.constitution;
        slaveMaker.stats.conversation;
        slaveMaker.stats.cooking;
        slaveMaker.stats.corruption;
        slaveMaker.gender;
        
        
        
        // much used
        slaveMaker.general;
        slaveMaker.nameChar;
        slaveMaker.vitals;
        slaveMaker.skills;
        slaveMaker.path;
        slaveMaker.fertility;
        
        // rarely used
        slaveMaker.products;
        slaveMaker.sexSkills;
        slaveMaker.sexNormal;
        slaveMaker.sexExtreme;
        slaveMaker.schools;
        slaveMaker.chores;
        slaveMaker.jobs;
        slaveMaker.astrid;
        slaveMaker.dating;
        

        // almost never used
        slaveMaker.arms;
        slaveMaker.ears;
        slaveMaker.eyes;
        slaveMaker.legs;
        slaveMaker.wings;
        slaveMaker.raceID;
        slaveMaker.averageBodySize;
        slaveMaker.raceName;
        slaveMaker.raceType;
        slaveMaker.raceID;
        slaveMaker.mother;
        slaveMaker.father;
        slaveMaker.misc;
        
        // very specific usage only
        slaveMaker.trainingStartDate;
        slaveMaker.canBeBought;
        slaveMaker.aviableForTraining;
        slaveMaker.trainingTime;
        slaveMaker.slaveName;
        slaveMaker.slavePrice;
        slaveMaker.slaveCategory;
        slaveMaker.generalSlave;
        slaveMaker.virginity;
        slaveMaker.training;
        slaveMaker.trainingTime;
        slaveMaker.owner;
        
        // relic from other classes
        slaveMaker.ID;
        slaveMaker.slaveID;
        slaveMaker.showInSlaveMarket;
        slaveMaker.listOfBool;
        slaveMaker.listOfInt;
        slaveMaker.listOfString;
        slaveMaker.minReputation;
        slaveMaker.contractOnly;
        slaveMaker.visits;
        slaveMaker.noble;
        */
    }
}
