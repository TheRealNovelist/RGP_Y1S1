using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBehaviour : MonoBehaviour
{
    public void Collapse()
    {
        this.gameObject.SetActive(false);
    }
}
