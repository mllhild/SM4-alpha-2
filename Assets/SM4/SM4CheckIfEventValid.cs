using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM4CheckIfEventValid : MonoBehaviour
{
    public SM4SlaveMaker slaveMaker = new SM4SlaveMaker();
    public List<SM4Slave> listOfSlaves = new List<SM4Slave>();
    public List<SM4Character> listOfNpcs = new List<SM4Character>();
    
    public static SM4CheckIfEventValid instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            ErrorLogger.LogErrorInFile("Error in " + this.name);
            Destroy(gameObject);   
        }
    }

    public bool CheckIfEventValid(SM4Event sm4Event)
    {
        foreach (var attribute in sm4Event.attributes)
            if (!CheckAttribute(attribute.Key, attribute.Value))
                return false;
        
        return true;
    }
    
    // Example: <if gender = '2+'>
    // key = "gender"
    // value = "2+"
    public bool CheckAttribute(string key, string value)
     {
         bool checkIsTrue = true;

         string[] keyParts = key.Split('-');
         //bool greaterThan = value.EndsWith("+");
         //bool lesserThan = value.EndsWith("-");
         
         
         switch (keyParts[0])
         {
             case "sm":
                 CheckAttributeSM(keyParts, value, checkIsTrue);
                 break;
             case "slave":
                 //CheckAttributeSlave(keyParts, value, checkIsTrue);
                 break;
             case "npc":
                 //CheckAttributeNPC(keyParts, value, checkIsTrue);
                 break;
             case "event":
                 //CheckAttributeEvent(keyParts, value, checkIsTrue);
                 break;
             case "item":
                 //CheckAttributeItem(keyParts, value, checkIsTrue);
                 break;
             default:
                 ErrorLogger.LogErrorInFile("Key not recognized: " + key);
                 break;
         }
         
         
         return checkIsTrue;
     }

     private void CheckAttributeSM(string[] keyParts, string value, bool checkIsTrue)
     {
         switch (keyParts[1])
         {
             case "supervise":
                 checkIsTrue = slaveMaker.generalSM.supervise == true;
                 break;
             case "stats":
                 CheckAttributeSMstats(keyParts, value, checkIsTrue);
                 break;
             default:
                 ErrorLogger.LogErrorInFile("Key not recognized: " + keyParts.ToString());
                 break;
         }
         
     }

     private void CheckAttributeSMstats(string[] keyParts, string value, bool checkIsTrue)
     {
         switch (keyParts[3])
         {
             case "agility":
                 CheckAttributeSMstatsAgility(keyParts, value, checkIsTrue);
                 break;

             default:
                 ErrorLogger.LogErrorInFile("Key not recognized: " + keyParts.ToString());
                 break;
         }
     }

     private void CheckAttributeSMstatsAgility(string[] keyParts, string value, bool checkIsTrue)
     {
         bool greaterThan = value.EndsWith("+");
         bool lesserThan = value.EndsWith("-");
         int numValue = Int32.Parse(value.Remove(value.Length - 1, 1));
         switch (keyParts[4])
         {
             case "current":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.agility.current >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.agility.current <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.agility.current == numValue;
                 break;
             case "last":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.agility.last >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.agility.last <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.agility.last == numValue;
                 break;
             case "max":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.agility.max >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.agility.max <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.agility.max == numValue;
                 break;
             case "min":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.agility.min >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.agility.min <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.agility.min == numValue;
                 break;
             case "start":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.agility.start >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.agility.start <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.agility.start == numValue;
                 break;
             case "modifier":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.agility.modifier >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.agility.modifier <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.agility.modifier == numValue;
                 break;
             default:
                 ErrorLogger.LogErrorInFile("Key not recognized: " + keyParts.ToString());
                 break;
         }
     }
     
     private void CheckAttributeSMstatsblowjob(string[] keyParts, string value, bool checkIsTrue)
     {
         bool greaterThan = value.EndsWith("+");
         bool lesserThan = value.EndsWith("-");
         int numValue = Int32.Parse(value.Remove(value.Length - 1, 1));
         switch (keyParts[4])
         {
             case "current":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.blowjob.current >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.blowjob.current <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.blowjob.current == numValue;
                 break;
             case "last":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.blowjob.last >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.blowjob.last <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.blowjob.last == numValue;
                 break;
             case "max":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.blowjob.max >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.blowjob.max <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.blowjob.max == numValue;
                 break;
             case "min":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.blowjob.min >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.blowjob.min <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.blowjob.min == numValue;
                 break;
             case "start":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.blowjob.start >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.blowjob.start <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.blowjob.start == numValue;
                 break;
             case "modifier":
                 if (greaterThan)
                     checkIsTrue = slaveMaker.stats.blowjob.modifier >= numValue;
                 else if (lesserThan)
                     checkIsTrue = slaveMaker.stats.blowjob.modifier <= numValue;
                 else
                     checkIsTrue = (int) slaveMaker.stats.blowjob.modifier == numValue;
                 break;
             default:
                 ErrorLogger.LogErrorInFile("Key not recognized: " + keyParts.ToString());
                 break;
         }
     }
}
