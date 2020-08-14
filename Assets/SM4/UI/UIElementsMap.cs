using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementsMap : MonoBehaviour
{
    public static UIElementsMap instance = null;
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


    public SM4MapFromXml mapFromXml;
    public void LoadMapsFromXml() { mapFromXml.GetWorld("World"); }
    
    public List<SM4Map> maps = new List<SM4Map>();

    

    public void HideMaps()
    {
        foreach (var map in maps)
        {
            map.gameObject.SetActive(false);
        }
    }

    public void ShowMap(string mapName)
    {
        foreach (var map in maps)
        {
            if(mapName == map.mapName)
            {
                map.gameObject.SetActive(true);
                break;
            }
            
        }
    }
    
}
