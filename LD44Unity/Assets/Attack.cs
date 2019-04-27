using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public float bloodRecoveryOnSuccess;

    public abstract void use(float angle, out int bloodCost, out int bloodRecovery);
    public abstract bool canUse(int curBlood);
}
