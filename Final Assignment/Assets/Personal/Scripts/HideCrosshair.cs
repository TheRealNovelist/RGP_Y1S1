using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideCrosshair : MonoBehaviour
{
    public PickBlock holdingCheck;
    public Image crosshair;
    void Update()
    {
        if (holdingCheck.holding == true)
        {
            crosshair.enabled = false;
        }
        else
        {
            crosshair.enabled = true;
        }
    }
}
