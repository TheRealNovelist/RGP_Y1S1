using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectPane : MonoBehaviour
{
    GameObject reflectLine;
    public GameObject primaryLine;
    public GameObject secondaryLine;
    public GameObject hitLine;
    public bool isHit;

    private void Start()
    {
        reflectLine = primaryLine;
        if (isHit == false)
        {
            reflectLine.SetActive(false);
            if (secondaryLine != null)
            {
                secondaryLine.SetActive(false);
            }
        }
        else
        {
            reflectLine.SetActive(true);
            if (secondaryLine != null)
            {
                secondaryLine.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (hitLine != null)
        {
            if (hitLine.tag == "StaticLine" && secondaryLine != null)
            {         
                reflectLine = secondaryLine;  
            }
            else
            {
                reflectLine = primaryLine;
            }
            EnableLine();
        }
        else
        {
            DisableLine();
        }
    }

    public void EnableLine()
    {
        reflectLine.SetActive(true);
    }

    public void DisableLine()
    {
        reflectLine.SetActive(false);
    }
}
