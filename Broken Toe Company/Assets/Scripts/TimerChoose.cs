using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerChoose : MonoBehaviour
{
    public Slider slider;

    public void ResetSlider(float maxval)
    {
        slider.maxValue = maxval;
    }

    public void setSliderVal(float val)
    {
        slider.value = val;
    }

}
