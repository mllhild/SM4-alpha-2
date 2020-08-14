using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SM4CharacterPortrait : MonoBehaviour
{
    public RawImage portrait;
    public TextMeshProUGUI nameOfCharacter;
    public Image backgroundPortrait;
    public Image backgroundName;

    public void LoadCharacterImage(string path) => SM4ImageLoader.instance.LoadRawImage(path,portrait,true,false);
    
}
