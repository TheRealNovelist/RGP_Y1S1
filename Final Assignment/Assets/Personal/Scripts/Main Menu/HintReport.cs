using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HintReport : MonoBehaviour
{
    public PlayerData playerData;
    public Text hintReport;

    public void Start()
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
        hintReport.text = "You used " + playerData.totalHintUse + " hint(s)!";
    }
    
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
