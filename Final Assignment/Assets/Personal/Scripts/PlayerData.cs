using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public Transform checkpoint;

    public int totalHintUse = 0;

    public bool destroyOnLoad = false;

    void Start()
    {
        if (GameObject.Find("Player Variant") != null)
        {
            checkpoint = GameObject.Find("Player Variant").transform;
        }
    }


    private void Update()
    {
        if (destroyOnLoad == false)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SetHintUse(int hint)
    {
        totalHintUse += hint;
    }

    public void SetCheckpoint(Transform currentPoint)
    {
        checkpoint = currentPoint;
    }

    
}
