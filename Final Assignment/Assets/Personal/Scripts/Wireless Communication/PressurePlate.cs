using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public string tagToActivate;

    public Animator targetAnim;

    public bool isClicked;

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponentInChildren<BlockProperty>() != null)
        {
            if (other.gameObject.GetComponentInChildren<BlockProperty>().objectiveTag == tagToActivate)
            {
                isClicked = true;
                if (targetAnim != null)
                {
                    targetAnim.SetBool("activated", true);
                }
                    
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.GetComponentInChildren<BlockProperty>() != null)
        {
            if (other.gameObject.GetComponentInChildren<BlockProperty>().objectiveTag == tagToActivate)
            {
                isClicked = false;
                if (targetAnim != null)
                {
                    targetAnim.SetBool("activated", false);
                }
            }
        }
    }
}
