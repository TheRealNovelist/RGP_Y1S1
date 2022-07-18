using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Trigger : MonoBehaviour
{
    public Level3Event eventFunction;
    public string eventName;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            eventFunction.LevelEvent(eventName);
        }
    }
}
