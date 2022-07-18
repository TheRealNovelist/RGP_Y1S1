using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDisk : MonoBehaviour
{
    public GameObject teleportTarget;
    public bool canTeleport = true;
    void Start()
    {
            
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player") 
        {
            if(canTeleport == true)
            {
                StartCoroutine(TeleportDelay());
            }
            if(teleportTarget.GetComponent<TeleportDisk>().canTeleport == false)
            {
                other.transform.position = new Vector3(teleportTarget.transform.position.x, teleportTarget.transform.position.y + 1, teleportTarget.transform.position.z);
            }
            

        }
        
        
    }
    IEnumerator TeleportDelay()
    {
        teleportTarget.GetComponent<TeleportDisk>().canTeleport = false;
        yield return new WaitForSeconds(2f);
        teleportTarget.GetComponent<TeleportDisk>().canTeleport = true;
    }
}
