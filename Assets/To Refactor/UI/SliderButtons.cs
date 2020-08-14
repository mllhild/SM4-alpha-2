using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderButtons : MonoBehaviour
{
    public void OnButtonPress(int x)
    {
        this.gameObject.GetComponent<Slider>().value += x;
    }
}
