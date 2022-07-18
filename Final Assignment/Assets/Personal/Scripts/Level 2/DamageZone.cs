using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public Health healthScript;
    public float rate = 0.01f;
    private IEnumerator OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            healthScript.Damage(0.1f);
            yield return new WaitForSeconds(rate);
        }
    }
}
