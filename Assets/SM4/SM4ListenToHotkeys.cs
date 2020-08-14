using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM4ListenToHotkeys : MonoBehaviour
{

    public GameObject optionMenu;
    public GameObject pauseMenu;
    public GameObject testbuttons;
    
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
                pauseMenu.SetActive(false);
            else
                if (optionMenu.activeSelf)
                    optionMenu.GetComponent<SM4UIOptions>().CloseOptionMenu();
                else
                    pauseMenu.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.F1))
            testbuttons.SetActive(!testbuttons.activeSelf);
    }
}
