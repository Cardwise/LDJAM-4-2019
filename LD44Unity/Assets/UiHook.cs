using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHook : MonoBehaviour
{
    public HealthSlider healthUIPrefab;
    public HealthSlider bloodUIprefab;
    public HealthComponent healthComponent;
    public BloodGauge bloodGauge;

    // Start is called before the first frame update
    private void Awake()
    {
        Transform UICanvas = GameObject.FindGameObjectWithTag("UICanvas").transform;
        if (UICanvas != null)
        {
            HealthSlider newHealthUI = Instantiate(healthUIPrefab, UICanvas);
            newHealthUI.init(healthComponent);
            HealthSlider bloodUI = Instantiate(bloodUIprefab, UICanvas);
            bloodUI.init(bloodGauge);
        }
        else
        {
            Debug.Log("NO UI canvas");
        }
    }
}
