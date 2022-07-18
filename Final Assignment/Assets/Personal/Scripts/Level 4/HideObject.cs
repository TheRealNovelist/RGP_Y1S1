using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public GameObject[] objectToHide;
    public bool hide = false;
    public void Start()
    {
        if (hide == false)
        {
            foreach (GameObject hide in objectToHide)
            {
                hide.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject hide in objectToHide)
            {
                hide.SetActive(false);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (hide == true)
            {
                foreach (GameObject hide in objectToHide)
                {
                    hide.SetActive(true);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
