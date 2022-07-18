using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSetter : MonoBehaviour
{
    public int objectiveNum;
    public Objective objectiveScript;
    public GameObject another;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectiveScript.SetCurrentObjective(objectiveNum);
            this.gameObject.SetActive(false);
            if (another != null)
            {
                another.SetActive(true);
            }
        }
    }
}
