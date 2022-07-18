using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnimation : MonoBehaviour
{
    public Animator menuAnimation;
    public Text title;
    public void Start()
    {
        title.text = "The Test";
    }
    public void LevelSelect()
    {
        menuAnimation.SetBool("LevelSelect", true);
        StartCoroutine(TitleChange("Select a Level"));
    }
    public void ReturnToTitle()
    {
        menuAnimation.SetBool("LevelSelect", false);
        StartCoroutine(TitleChange("The Test"));
    }
    IEnumerator TitleChange(string titleChange)
    {
        yield return new WaitForSeconds(0.9f);
        title.text = titleChange;
    }
}
