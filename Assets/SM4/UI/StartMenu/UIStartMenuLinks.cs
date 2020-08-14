using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class UIStartMenuLinks : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private bool isOver = false;
    private bool canMove = false;
    private GameObject banner;
    private GameObject banner2;
    private float speed = 10;
    private float size;
    private float lastChangeInDistance;
    private UIpanelsLowerRight messages;
    private void Awake()
    {
        banner2 = this.gameObject;
        banner = GameObject.Find("PanelsLowerRight/banner/Cover");
        messages = GetComponentInParent<UIpanelsLowerRight>();
    }

    private void Update()
    {
        if (isOver && Input.GetKeyDown(KeyCode.Y))
        {
            UpdateConfig(true);
            
        }
        if (isOver && Input.GetKeyDown(KeyCode.N))
        {
            UpdateConfig(false);
            messages.bannerWorking = true;
        }
        if (canMove)
        {
            if (isOver)
            {
                if (speed < 30)
                    speed += 1;
                SlideFunction(size);
            }
            else
            {
                SlideFunction(0);
                
                var number = Math.Abs(banner.transform.localPosition.y - banner2.transform.localPosition.y);
                if (number < 1)
                {
                    canMove = false;
                    messages.bannerWorking = true;
                    messages.MotivationalMessage();
                }
            }
            
        }
    }

    private void SlideFunction(float deslocation)
    {
        banner.transform.localPosition =
            Vector3.MoveTowards(
                banner.transform.localPosition,
                new Vector3(
                    banner2.transform.localPosition.x
                    , banner2.transform.localPosition.y + deslocation
                    , banner2.transform.localPosition.z
                ),
                speed * Time.deltaTime
            );
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
        messages.bannerWorking = false;
        Question();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        if(!canMove)
            messages.bannerWorking = true;
    }

    private void Question()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = "Cuteness is Justice?  Y/N";
        size = this.gameObject.GetComponent<RectTransform>().sizeDelta.y*0.9f;
    }
    
    private void UpdateConfig(bool p0)
    {
        GetComponentInParent<UIControlerSceneStartMenu>()
            .optionMenu
            .GetComponent<SM4UIOptions>()
            .LoliShotaEnabled.isOn = p0;
        GetComponentInParent<UIControlerSceneStartMenu>()
            .optionMenu
            .GetComponent<SM4UIOptions>().MenuToClass();
        canMove = p0;
    }
}
