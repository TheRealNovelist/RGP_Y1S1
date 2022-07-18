using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Event : MonoBehaviour
{
    public Animator midLevel;

    public Animator rotateRay;
    
    public void LevelEvent(string defineEvent)
    {
        switch (defineEvent)
        {
            case "RotateMidLevel":
                RotateMidLevel();
                break;
        }
    }

    public void RotateMidLevel()
    {
        if(midLevel.GetBool("Rotate") == true)
        {
            midLevel.SetBool("Rotate", false);
        }
        else
        {
            midLevel.SetBool("Rotate", true);
        }
    }
}
