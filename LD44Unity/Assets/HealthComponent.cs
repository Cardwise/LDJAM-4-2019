using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthComponent : MonoBehaviour,canChangeRatio
{
    public int curHealth { get { return _curHealth; } }

    public event Action<float> onChangeEvent;
    public event Action onDeath;

    public int maxHealth = 30;
    int _curHealth;

    public bool isDead()
    {
        return _curHealth <= 0;
    }

    private void Awake()
    {
        FullyRecover();
    }

    public void takeDamage(int damage)
    {
        _curHealth = Mathf.Clamp(curHealth - damage, 0, maxHealth);

        if (onChangeEvent != null)
            onChangeEvent(getRatio());
        if (isDead() && onDeath != null)
            onDeath();
    }

    public void FullyRecover()
    {
        _curHealth = maxHealth;
        if (onChangeEvent != null)
            onChangeEvent(getRatio());
    }

    public float getMax()
    {
        return maxHealth;
    }

    public float getCur()
    {
        return _curHealth;
    }
    public float getRatio()
    {
        return ((float)_curHealth) / maxHealth;
    }
}
public interface canChangeRatio
{
    event Action<float> onChangeEvent;
    float getRatio();
}
