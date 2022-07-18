using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildZone : MonoBehaviour
{
    public GameObject zone;
    public GameObject platform;
    public GameObject storedBlock;
    public bool isBuild;

    // Start is called before the first frame update
    void Start()
    {
        if (storedBlock != null)
        {
            Activate();
            storedBlock.SetActive(false);
        }
        else if (storedBlock == null)
        {
            Deactivate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<BlockProperty>() != null && other.gameObject.GetComponent<BlockProperty>().buildBlock == true)
        {
            if(storedBlock == null)
            {
                Activate();
                storedBlock = other.gameObject;
                storedBlock.SetActive(false);
            }
        }
    }
    public void Deactivate()
    {
        isBuild = false;
        platform.SetActive(false);
        zone.SetActive(true);
    }
    public void Activate()
    {
        isBuild = true;
        platform.SetActive(true);
        zone.SetActive(false);
    }
}
