using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(HealthComponent))]
public class LivingEntity : MonoBehaviour,Damagable
{
    HealthComponent healthComp;
    public Action<int> onDamageEvent;
    public bool isInvincible = false;

    public void toggleInvinciblity(int zeroIfVulnerable)
    {
        isInvincible = zeroIfVulnerable != 0;
    }

    private void Awake()
    {
        healthComp = GetComponent<HealthComponent>();      
    }

    private void OnEnable()
    {
        healthComp.onDeath += die;
    }
    private void OnDisable()
    {
        healthComp.onDeath -= die;
    }

    public void takeDamage(int damageInfo)
    {
        if (isInvincible)
            return;
        /*
        if (isInvincible && !damageInfo.isHeal && !damageInfo.canPierceInvinciblity)
        {
            Debug.Log("can't touch me");
            return;
        }*/
        healthComp.takeDamage(damageInfo);
    }
    public void die() {
        Destroy(gameObject);
    }
}



public interface Damagable
{
    void takeDamage(int damage);
}

