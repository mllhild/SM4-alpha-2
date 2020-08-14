using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanningButton : MonoBehaviour
{

    public Button button;
    public TextMeshProUGUI actName;
    public TextMeshProUGUI keyShortcut;
    public int eventNumber;

    public PlanningField field;
    public void PassEventNumberToPlanningField()
    {
        field.ReceiveEventNumber(this.eventNumber);
        //this.actName.alpha = 0;
        //this.button.interactable = false;
        //Origin = new Point(10, Origin.Y);
    }
}
