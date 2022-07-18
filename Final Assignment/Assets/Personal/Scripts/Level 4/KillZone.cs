using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public PlayerData playerData;

    void Start()
    {
        if (GameObject.Find("_PlayerData") != null)
        {
            playerData = GameObject.Find("_PlayerData").GetComponent<PlayerData>();
            Destroy(GameObject.Find("TempData"));
        }
        else
        {
            playerData = GameObject.Find("TempData").GetComponent<PlayerData>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = playerData.checkpoint.position;
            other.transform.rotation = playerData.checkpoint.rotation;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        
        if (other.gameObject.GetComponent<BlockProperty>() != null)
        {
            if (other.gameObject.GetComponent<BlockProperty>().pickable == true)
            {
                other.gameObject.transform.position = other.gameObject.GetComponent<BlockProperty>().originalPos.position;
                other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}
