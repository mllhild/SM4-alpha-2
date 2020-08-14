using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SM4Scroller : MonoBehaviour
{
    public Scrollbar scrollbar;
    public float scrollspeed = 0.1f;

    private void Start()
    {
        scrollbar = this.gameObject.GetComponent<Scrollbar>();
    }

    private void Update()
    {
        //ResizeContentField();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scrollbar.value -= scrollbar.size;
            if (scrollbar.value < 0)
                scrollbar.value = 0;
        }

        scrollbar.value += Input.mouseScrollDelta.y * scrollspeed;

    }
}
