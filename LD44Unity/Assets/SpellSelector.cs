using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSelector : MonoBehaviour
{
    [SerializeField] private int curSpellIndex = 0;
    public List<BloodSpell> spells;
    public float mouseScrollthreshold = .1f;
    public float mouseScrollTracker = 0;
    public BloodSpell curSpell
    {
        get
        {
            if (curSpellIndex >= 0 && curSpellIndex < spells.Count)
                return spells[curSpellIndex];
            else
                return null;
        }
    }

    private void Update()
    {
        mouseScrollTracker += Input.GetAxis("Mouse ScrollWheel");
        if (mouseScrollTracker > mouseScrollthreshold) {
            curSpellIndex = (curSpellIndex + 1 + spells.Count) % spells.Count;
            Debug.Log("up");
        }else if (mouseScrollTracker < (-mouseScrollthreshold))
        {
            curSpellIndex = (curSpellIndex - 1 + spells.Count) % spells.Count;
            Debug.Log("down");
        }
    }

}
