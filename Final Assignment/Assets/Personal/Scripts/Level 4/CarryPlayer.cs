using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryPlayer : MonoBehaviour
{
    public Transform platform;

    private void OnTriggerEnter(Collider collision)
    {
        collision.transform.SetParent(platform.transform);
    }
    private void OnTriggerExit(Collider collision)
    {
        collision.transform.SetParent(null);
    }

}
