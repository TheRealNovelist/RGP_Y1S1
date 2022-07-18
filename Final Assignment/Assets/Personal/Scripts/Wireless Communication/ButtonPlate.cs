using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlate : MonoBehaviour
{
    public string tagToActivate;

    public Material clicked;
    public Material unclicked;

    public Animator targetAnim;

    public bool isClicked;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<BlockProperty>() != null) { }
        {
            if (other.gameObject.GetComponent<BlockProperty>().objectiveTag == tagToActivate)
            {
                if (isClicked == false)
                {
                    isClicked = true;
                    this.gameObject.GetComponent<Renderer>().material = clicked;
                    if (targetAnim != null)
                    {
                        targetAnim.SetBool("activated", true);
                    }
                }
                else
                {
                    isClicked = false;
                    this.gameObject.GetComponent<Renderer>().material = unclicked;
                    if (targetAnim != null)
                    {
                        targetAnim.SetBool("activated", false);
                    }
                }
            }
        }
    }
}
