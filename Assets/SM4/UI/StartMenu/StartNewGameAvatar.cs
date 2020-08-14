using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartNewGameAvatar : MonoBehaviour
{
    public GameObject smAvatar;
    public Image smAvatarImage;
    public GameObject coatOfArms;
    public Image coatOfArmsImage;
    
    public GameObject namePanel;
    public TMP_InputField smNameInputField;
    public GameObject familynamePanel;
    public TMP_InputField smFamiliyNameInputField;
    
    private List<string> smAvatarImagesPaths = new List<string>();
    private int currentNumberAvatar = 0;

    public RawImage smAvatarRawImage;
    
    private List<string> smCoAList = new List<string>();
    private int currentCoA = 0;
    public RawImage coatOfArmsRawImage;


    public SM4SlaveMaker sm;
    private void Start()
    {
        sm = SM4SlaveMakerControler.instance.slaveMaker;
        smAvatarUpdate();
    }

    public void smAvatarUpdate()
    {
        GetAvatars(sm.gender.current, sm.raceID);
        LoadNextAvatartImage();
    }

    public void GetAvatars(int gender, int race)
    {
        smAvatarImagesPaths.Clear();
        
        string path = "/SM/Avatar";
        
        switch (race)
        {
            case 1:
                path += "/Human";
                break;
            case 2:
                path += "/Vampire";
                break;
            default:
                path += "/Human";
                break;
        }
        
        switch (gender)
        {
            case 1:
                path += "/Male";
                break;
            case 2:
                path += "/Female";
                break;
            case 3:
                path += "/Futa";
                break;
            default:
                path += "/Female";
                break;
        }
        
        
        Debug.Log(path);
        Debug.Log(Application.streamingAssetsPath);

        path = Application.streamingAssetsPath + path;
        Debug.Log(path);
        var directories = Directory.GetDirectories(@path);
        foreach (var directory in directories)
        {
            Debug.Log(directory + "/Portrait (0).png");
            smAvatarImagesPaths.Add(directory + "/Portrait (0).png");
        }
        
    }

    public void LoadNextAvatartImage()
    {
        currentNumberAvatar++;
        if (currentNumberAvatar == smAvatarImagesPaths.Count)
            currentNumberAvatar = 0;
        
        UIStartMenuTools.instance.LoadImageUnityWebRequestv2(smAvatarImagesPaths[currentNumberAvatar],smAvatarRawImage);
        sm.path = Directory.GetParent(@smAvatarImagesPaths[currentNumberAvatar]).FullName;
        Debug.Log(sm.path);
    }
    public void PreviousAvatartImage()
    {
        currentNumberAvatar--;
        if (currentNumberAvatar < 0)
            currentNumberAvatar = 0;
        UIStartMenuTools.instance.LoadImageUnityWebRequestv2(smAvatarImagesPaths[currentNumberAvatar],smAvatarRawImage);
        sm.path = Directory.GetParent(@smAvatarImagesPaths[currentNumberAvatar]).FullName;
    }

    public void GetCoatOFArms()
    {
        smCoAList.Clear();
        string path = "/SM/CoatOfArms/";
        path = Path.Combine(Application.streamingAssetsPath, path);
        var files = Directory.GetFiles(@path,"*.png");
        foreach (var file in files)
        {
            smCoAList.Add(file);
        }
    }
    public void LoadNextCoA()
    {
        currentCoA++;
        if (currentCoA == smCoAList.Count)
            currentCoA = 0;
        UIStartMenuTools.instance.LoadImageUnityWebRequestv2(smCoAList[currentCoA],coatOfArmsRawImage);
    }
    public void LoadPreviousCoA()
    {
        currentCoA--;
        if (currentCoA == smCoAList.Count)
            currentCoA = 0;
        UIStartMenuTools.instance.LoadImageUnityWebRequestv2(smCoAList[currentCoA],coatOfArmsRawImage);
    }
    
    
    
    
    
    
    
}
