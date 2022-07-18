using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTransition : MonoBehaviour
{
    public GameObject frontWall;
    public GameObject backWall;
    public void Start()
    {
        frontWall.SetActive(false);
        backWall.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        frontWall.SetActive(true);
        backWall.SetActive(false);
    }
}
