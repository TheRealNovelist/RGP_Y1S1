using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeAnimation : MonoBehaviour
{
    public Animator bridgeAnimation;

    public void BridgeToNewPos(string position)
    {
        bridgeAnimation.SetBool("To"+position, true);
        //this.gameObject.transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler(0f,90f,0f), 5f * Time.deltaTime);
    }
    
    public void BridgeReturn(string position)
    {
        bridgeAnimation.SetBool("To" + position, false);
        //this.gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, -90f, 0f), 5f * Time.deltaTime);
    }
}
