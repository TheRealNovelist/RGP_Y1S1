using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public Animator switchAnim;
    public Animator targetAnim;
    public bool isPressed = false;

    public bool isToggle = true;

    private void Start()
    {
        if (isPressed == true)
        {
            OnPressed();
        }
    }

    public void OnPressed()
    {
        if (isToggle == true)
        {
            isPressed = true;
            targetAnim.SetBool("activated", true);
            switchAnim.SetBool("isPressed", true);
        }
        else
        {
            StartCoroutine(PressAndRelease());
        }
    }

    public void OnReleased()
    {
        if (isToggle == true)
        {
            isPressed = false;
            targetAnim.SetBool("activated", false);
            switchAnim.SetBool("isPressed", false);
        }
    }

    public IEnumerator PressAndRelease()
    {
        isPressed = true;
        switchAnim.SetBool("isPressed", true);
        targetAnim.SetBool("activated", true);
        yield return new WaitForSeconds(1f);
        isPressed = false;
        switchAnim.SetBool("isPressed", false);
        targetAnim.SetBool("activated", false);
    }
}
