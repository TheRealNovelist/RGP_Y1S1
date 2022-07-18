using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveController : MonoBehaviour
{
    public Animator objectiveAnim;

    public Text mainObjectiveText;
    public Text sub1Text;
    public Text sub2Text;

    public string[] mainObjective;
    public string[] subtitle1;
    public string[] subtitle2;

    void Start()
    {
        objectiveAnim.SetBool("MainObjective", false);
        objectiveAnim.SetBool("Subtitle1", false);
        objectiveAnim.SetBool("Subtitle2", false);
    }
    public void ChangeObjective(string objectiveType, int objectiveNum)
    {
        DisableObjective(objectiveType);
        StartCoroutine(ShowObjective(objectiveType, objectiveNum));
    }
    public void DisableObjective(string objectiveType)
    {
        if (objectiveAnim.GetBool(objectiveType) == true)
        {
            objectiveAnim.SetBool(objectiveType, false);
        }
    }
    public IEnumerator ShowObjective(string objectiveType, int objectiveNum)
    {
        yield return new WaitForSeconds(1f);
        if (objectiveType == "MainObjective")
        {
            mainObjectiveText.color = Color.white;
            mainObjectiveText.text = mainObjective[objectiveNum];
        }
        else if (objectiveType == "Subtitle1")
        {
            sub1Text.color = Color.white;
            sub1Text.text = subtitle1[objectiveNum];
        }
        else if (objectiveType == "Subtitle2")
        {
            sub2Text.color = Color.white;
            sub2Text.text = subtitle2[objectiveNum];
        }
        objectiveAnim.SetBool(objectiveType, true);
    }
}
