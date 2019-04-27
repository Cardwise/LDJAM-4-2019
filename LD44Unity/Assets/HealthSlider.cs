using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public canChangeRatio trackedRatio;
    public Slider slider;

    public void OnEnable()
    {
        init(trackedRatio);
    }

    public void setValue(float ratio)
    {
        slider.value = ratio;
    }
    private void OnDisable()
    {
        if (trackedRatio != null)
            trackedRatio.onChangeEvent -= setValue;
    }

    public void init(canChangeRatio healthComp)
    {
        if (healthComp == null)
            return;
        this.trackedRatio = healthComp;
        healthComp.onChangeEvent += setValue;
        slider.value = healthComp.getRatio();
    }
}
