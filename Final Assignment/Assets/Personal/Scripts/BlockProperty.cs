using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockProperty : MonoBehaviour
{
    public bool pickable;
    public bool buildBlock;

    public string objectiveTag;

    public Transform originalPos;

    void Start()
    {
        originalPos = this.transform;
    }
}
