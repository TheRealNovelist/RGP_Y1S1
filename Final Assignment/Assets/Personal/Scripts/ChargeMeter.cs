using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeMeter : MonoBehaviour
{
    public Slider chargeSlider;
    public Gradient chargeGradient;
    public PickBlock chargeScript;
    public Image chargeFill;
    public Image chargeBorder;

    private void Start()
    {
        chargeScript = GameObject.Find("Player Variant").GetComponentInChildren<PickBlock>();
        chargeSlider.maxValue = chargeScript.chargeLimit;
        chargeFill.enabled = false;
        chargeBorder.enabled = false;
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            chargeFill.enabled = true;
            chargeBorder.enabled = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            chargeFill.enabled = false;
            chargeBorder.enabled = false;
        }
        chargeSlider.value = chargeScript.chargeTime;
        chargeFill.color = chargeGradient.Evaluate(chargeSlider.normalizedValue);
    }
}
