using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class UIpanelsLowerRight : MonoBehaviour
{
    private GameObject banner;
    public TextMeshProUGUI message;
    public bool bannerWorking = true;
    private  List<string> messages = new List<string>();
    private float timeBetweenMessages = 0;
    
    private void Awake()
    {
        banner = GameObject.Find("PanelsLowerRight/banner/Cover");
        MotivationalMessage();
    }
    
    

    private void Update()
    {
        if (bannerWorking && timeBetweenMessages < 0)
        {
            message.text = messages[Random.Range(0,messages.Count)];
            timeBetweenMessages = 30;
        }
        else
        {
            timeBetweenMessages -= Time.deltaTime;
        }
    }

    public void MotivationalMessage()
    {
        messages.Add("Welcome to our community of perverts.");
        messages.Add("Happy to see you again!");
        messages.Add("Soon the banner will show the right city, probably.");
        messages.Add("Nothing to see here, go along");
        messages.Add("How about a this elf with matching eyes to your latest tiara?");
        messages.Add("Remorse of selling your waifu is perfectly normal at first.");
        messages.Add("No, I'm not a slave, or are you seeing any collar on me?");
        messages.Add("SlaveMaker, WaifuMaker or HaremMaker. Which one are you?");
        messages.Add("Ready again to trample the innocence of maidens?");
        messages.Add("One whipping a day is essential to keep any pony happy");
        messages.Add("Grabbing people by their tail, either front or back, is bound to get their attention");
        messages.Add("Yes, this Dress is complete like this.");
        messages.Add("Ever asked yourself what the most played SlaveMaker gender is?");
        messages.Add("If you are suffering in combat, curse the main dev for being a fan of realistic armor.");
        messages.Add("Ever tried naming yourself mllhild?");
        messages.Add("Flat chest are the cutest? What a sacrilege! Nothing is cuter than large breast jumping around to the rhythm of the whip!");
    }
    
    

}
