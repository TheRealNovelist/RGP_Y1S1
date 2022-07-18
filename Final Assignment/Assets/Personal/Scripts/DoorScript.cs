using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator doorComponent;
    public bool isTriggered = false;
    public bool closeOnPass = false;

    public bool signalReceived = false;
    
    public Receptor receptor;

    public void LateUpdate()
    {
        if (receptor != null)
        {
            if (receptor.isActivated == true && signalReceived == false)
            {
                DoorOpen();
                signalReceived = true;
            }
            else if (receptor.isActivated == false && signalReceived == true)
            {
                DoorClose();
                signalReceived = false;
            }
        }
    }

    public void DoorOpen()
    {
        doorComponent.SetBool("activated", true);
    }
    public void DoorClose()
    {
        doorComponent.SetBool("activated", false);
    }
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (closeOnPass == true)
        {
            if (other.gameObject.tag == "Player")
            {
                isTriggered = true;
                yield return new WaitForSeconds(0.01f);
                DoorClose();
                isTriggered = false;
            }
        }
    }
}
