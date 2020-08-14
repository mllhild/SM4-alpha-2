using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SlaveFilesController : MonoBehaviour
{
    public SlaveContainer slaveContainer;
    public List<SlaveContainer> listOfSlaves = new List<SlaveContainer>();

    public static SlaveFilesController instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            ErrorLogger.LogErrorInFile("Error in SlaveFilesController");
            Destroy(gameObject);   
        }
    }

    public void GetAllSlaves()
    {
        string path = Application.streamingAssetsPath;
        string[] slaveDirectories = Directory.GetDirectories(Path.Combine(path, "Slaves"));
        foreach (var slaveDirectory in slaveDirectories)
        {
            var newSlaveContainer = Instantiate(slaveContainer, transform);
            newSlaveContainer.name = new DirectoryInfo(slaveDirectory).Name;
            newSlaveContainer.LoadSlave(slaveDirectory, newSlaveContainer.name);
            newSlaveContainer.gameObject.SetActive(true);
            listOfSlaves.Add(newSlaveContainer);
            
        }
        
        
    }
    
    

    

}
