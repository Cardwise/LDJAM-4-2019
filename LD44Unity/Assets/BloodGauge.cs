﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodGauge : MonoBehaviour,canChangeRatio
{
    public int  maxAmount = 100;
    public int CurAmount { get => curAmount; }
    int curAmount;

    public event Action<float> onChangeEvent;

    private void Awake()
    {
        curAmount = maxAmount;
        if (onChangeEvent != null)
            onChangeEvent(getRatio());
    }
    public void addBlood(int amount) {
        curAmount = Mathf.Clamp(curAmount + amount, 0, maxAmount);
        if (onChangeEvent != null)
            onChangeEvent(getRatio());
    }

    public bool canCast(int reqBlood) {
        return curAmount >= reqBlood;
    }
    public float getRatio()
    {
        return ((float)curAmount) / maxAmount;
    }
}
