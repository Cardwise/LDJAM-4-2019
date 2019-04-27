using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    public int meleeBloodRecovery = 10;
    public int meleeDamage = 10;
    public Vector2 meleeHitboxSize = new Vector2(1.11f,1.42f);
    public FiniteTimer meleeCooldown = new FiniteTimer(0, .5f);
    public LayerMask meleeDamageLayer;

    private void Update()
    {
        if (!meleeCooldown.isComplete())
            meleeCooldown.updateTimer(Time.deltaTime);
    }

    public override bool canUse(int curBlood)
    {
        return meleeCooldown.isComplete();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, meleeHitboxSize);
    }

    public override void use(float angle,out int bloodCost, out int bloodRecovery)
    {
        bloodCost = 0;
        bloodRecovery = 0;
        Collider2D[] results = Physics2D.OverlapBoxAll(transform.position, meleeHitboxSize, angle, meleeDamageLayer);
        for (int i = 0; i < results.Length; i++)
        {
            Damagable damagee = results[i].GetComponent<Damagable>();
            if (damagee != null)
            {
                damagee.takeDamage(meleeDamage);
                bloodRecovery += meleeBloodRecovery;
            }
        }
    }
}
