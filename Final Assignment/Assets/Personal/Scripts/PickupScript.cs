using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public GameObject wandOnHand;
    public GameObject wall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (wandOnHand.activeInHierarchy == false)
            {
                wandOnHand.SetActive(true);
                wall.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }
}
