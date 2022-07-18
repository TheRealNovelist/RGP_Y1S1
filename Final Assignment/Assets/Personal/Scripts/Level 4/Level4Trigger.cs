using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Trigger : MonoBehaviour
{
    public Level4Event eventScript;
    public string functionCall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            eventScript.LevelEvent(functionCall);
        }
    }
}
