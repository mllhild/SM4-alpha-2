using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM4SaveLoad : MonoBehaviour
{
    public static SM4SaveLoad instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            ErrorLogger.LogErrorInFile("Error in SM4SaveLoad " + this.name);
            Destroy(gameObject);   
        }
    }

    public void SaveToAutosave(SM4SlaveMaker slaveMaker)
    {
        
    }
}
