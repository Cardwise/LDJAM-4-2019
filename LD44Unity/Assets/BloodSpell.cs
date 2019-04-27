using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSpell : Attack
{

    public int bloodCostPerShot = 5;
    public GameObject bulletPrefab;
    public Transform shotPoint;

    public override bool canUse(int curBlood)
    {
        return curBlood >= bloodCostPerShot;
    }

    public override void use(float angle, out int bloodCost, out int bloodRecovery)
    {
        bloodCost = bloodCostPerShot;
        bloodRecovery = 0;

        Instantiate(bulletPrefab, shotPoint.position, Quaternion.AngleAxis(angle, Vector3.forward));
    }
}
