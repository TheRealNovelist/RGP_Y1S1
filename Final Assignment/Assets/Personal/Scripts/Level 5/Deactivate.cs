using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public Receptor receptor;

    public bool thisActivated = false;

    public void Update()
    {
        if (receptor.isActivated == true && thisActivated == false)
        {
            this.gameObject.SetActive(false);
            thisActivated = true;
        }
    }
}
