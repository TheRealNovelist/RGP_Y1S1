using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Event : MonoBehaviour
{
    public GameObject[] buildTutorialObject;

    public GameObject frontWall1;
    public GameObject backWall1;

    public GameObject frontWall2;
    public GameObject backWall2;

    private void Start()
    {
        foreach (GameObject objectInArray in buildTutorialObject)
        {
            objectInArray.SetActive(false);
        }
        frontWall1.SetActive(false);
        backWall1.SetActive(true);
        frontWall2.SetActive(false);
        backWall2.SetActive(true);
    }

    public void LevelEvent(string defineEvent)
    {
        switch (defineEvent)
        {
            case "StartArea1":
                StartArea1();
                break;
            case "StartArea2":
                StartArea2();
                break;
            case "StartArea3":
                StartArea3();
                break;
        }
    }

    public void StartArea1()
    {
        foreach (GameObject objectInArray in buildTutorialObject)
        {
            objectInArray.SetActive(true);
        }
    }

    public void StartArea2()
    {
        frontWall1.SetActive(true);
        backWall1.SetActive(false);
    }
    public void StartArea3()
    {
        frontWall2.SetActive(true);
        backWall2.SetActive(false);
    }
}
