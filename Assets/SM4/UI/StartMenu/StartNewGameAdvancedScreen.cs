using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartNewGameAdvancedScreen : MonoBehaviour
{
    // advanced screens
    public GameObject advancedScreen;
    public GameObject advTopPanel;
    public GameObject advMain;
    public TextMeshProUGUI advMainTtitle;
    public GameObject advOrigin;
    public GameObject advSpecialEvents;
    public GameObject advAdvantages;
    public GameObject advSkills;
    public GameObject advInitialItems;
    public GameObject advStats;
    public GameObject advOverview;
    public GameObject advInitialHouse;
    
    // points
    public GameObject advPointsScreen;
    public TextMeshProUGUI pointDisplay;
    public int points;
    public int initialPoints = 100;
    public int statsPoints = 0;
}
