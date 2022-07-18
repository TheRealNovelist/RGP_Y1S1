using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public Animator targetAnim;

    public string tagToActivate;

    public bool playerActivation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playerActivation == true)
        {
            targetAnim.SetBool("activated", true);
        }

        if (other.gameObject.GetComponentInChildren<BlockProperty>() != null)
        {
            if (other.gameObject.GetComponentInChildren<BlockProperty>().objectiveTag == tagToActivate)
            {
                if (targetAnim != null)
                {
                    targetAnim.SetBool("activated", true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInChildren<BlockProperty>() != null)
        {
            if (other.gameObject.GetComponentInChildren<BlockProperty>().objectiveTag == tagToActivate)
            {
                if (targetAnim != null)
                {
                    targetAnim.SetBool("activated", false);
                }
            }
        }
    }
}
