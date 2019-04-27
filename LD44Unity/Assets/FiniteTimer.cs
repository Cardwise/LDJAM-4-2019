using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class FiniteTimer 
{
    public float timer;
    public float maxValue;

    public void init(float maxval, float startVal = 0)
    {
        this.timer = startVal;
        this.maxValue = maxval;
    }
    public FiniteTimer()
    {
        init(10, 0);
    }

    public FiniteTimer(float timer, float maxValue)
    {
        init(maxValue, timer);
    }

    public void updateTimer(float delta)
    {
        timer += delta;
    }

    public void reset()
    {
        timer = 0;
    }
    public void reset(float newMax)
    {
        maxValue = newMax;
        reset();
    }
    public void complete()
    {
        timer = maxValue;
    }

    public bool isComplete()
    {
        return timer >= maxValue;
    }

    public bool isComplete(float externalMaxVal)
    {
        return timer >= externalMaxVal;
    }

    public float getRatio()
    {
        return Mathf.Clamp01(timer / maxValue);
    }

    public float getReverseRatio()
    {
        return 1 - getRatio();
    }

}
