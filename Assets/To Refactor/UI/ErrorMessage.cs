using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorMessage : MonoBehaviour
{
    public TextMeshProUGUI message;
    // Start is called before the first frame update

    void Start()
    {
        Destroy(gameObject, 10f);
    }
    public void DestroyOnClick()
    {
        Destroy(gameObject);
    }

    
    

    
}
