using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptor : MonoBehaviour
{
    public bool isActivated = false;

    public GameObject currentLaser;

    public void Start()
    {
        if (isActivated == true)
        {
            ReceptorOn();
        }
        else if (isActivated == false)
        {
            ReceptorOff();
        }
    }

    public void Update()
    {
        if (currentLaser == null)
        {
            ReceptorOff();
        }
    }

    public void ReceptorOn()
    {
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        isActivated = true;

    }

    public void ReceptorOff()
    {
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        isActivated = false;
    }
}
