using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePlate : MonoBehaviour
{
    public string position;
    public BridgeAnimation bridgeAnimation;
    public DoorScript doorScript;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Objective Block")
        {
            bridgeAnimation.BridgeToNewPos(position);
            doorScript.DoorOpen();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Objective Block")
        {
            bridgeAnimation.BridgeReturn(position);
            doorScript.DoorClose();
        }
    }
}
