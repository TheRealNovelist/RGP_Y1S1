using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSetter : MonoBehaviour
{
    public Transform setPoint;
    PlayerData playerData;
    Objective objectiveHolder;

    public int objectiveNumber;

    private void Start()
    {
        objectiveHolder = GameObject.Find("_EventManager").GetComponent<Objective>();
        if (GameObject.Find("_PlayerData") != null)
        {
            playerData = GameObject.Find("_PlayerData").GetComponent<PlayerData>();
            Destroy(GameObject.Find("TempData"));
        }
        else
        {
            playerData = GameObject.Find("TempData").GetComponent<PlayerData>();
        }
        this.gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            objectiveHolder.SetCurrentObjective(objectiveNumber);
            playerData.checkpoint = setPoint;
            this.gameObject.SetActive(false);
        }
    }
}
