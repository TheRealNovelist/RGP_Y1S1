using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public int currentObjective = 0;
    PlayerData playerData;

    int gotHint = 0;
    int allowedHint = 0;

    public bool hintTieToObj = false;

    public string[] objectiveText;
    public string[] hintText;

    public GameObject[] objectiveInJournal;
    public Text objectiveOnHUD;

    public GameObject[] hintInJournal;

    public Text hintTaunt;

    public void Start()
    {
        // Get number of hint use from playerData
        
        if (GameObject.Find("_PlayerData") != null)
        {
            playerData = GameObject.Find("_PlayerData").GetComponent<PlayerData>();
            Destroy(GameObject.Find("TempData"));
        }
        else
        {
            playerData = GameObject.Find("TempData").GetComponent<PlayerData>();
        }
        
        // Do not reveal objective until call
        foreach (GameObject temp in objectiveInJournal)
        {
            temp.SetActive(false);
        }

        foreach (GameObject temp in hintInJournal)
        {
            temp.SetActive(false);
        }

        if (hintTieToObj == true)
        {
            allowedHint = 1;
        }
        else
        {
            allowedHint = hintText.Length;
        }
    }

    public void Update()
    {
        ApplyText(); // Actively set objective
    }

    public void SetCurrentObjective(int objective)
    {
        currentObjective = objective;
        gotHint = 0; // Revert hint status every objective change
    }

    public void ApplyText()
    {
        // Change both hint and objective in journal on call
        objectiveInJournal[currentObjective].GetComponent<Text>().text = objectiveText[currentObjective];
       

        // Change objective on HUD on call
        objectiveOnHUD.text = objectiveText[currentObjective];

        // Reveal objective on call
        objectiveInJournal[currentObjective].SetActive(true);



        // Reveal hint if press H
        if (Input.GetKeyDown(KeyCode.H) && gotHint < allowedHint)
        {
            if (hintTieToObj == true)
            {
                hintInJournal[currentObjective].SetActive(true);
                hintInJournal[currentObjective].GetComponent<Text>().text = hintText[currentObjective];
            }
            else
            {
                hintInJournal[gotHint].SetActive(true);
                hintInJournal[gotHint].GetComponent<Text>().text = hintText[gotHint];
            }
            playerData.SetHintUse(1);
            gotHint += 1;
        }

        hintTaunt.text = "Total Hint Used: " + playerData.totalHintUse;
    }
}
