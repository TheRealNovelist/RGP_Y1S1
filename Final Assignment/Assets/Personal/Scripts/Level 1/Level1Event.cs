using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Event : MonoBehaviour
{
    public GameObject wand;

    public PressurePlate plate1;
    public PressurePlate plate2;
    public ButtonPlate plate3;
    public ButtonPlate plate4;

    public bool allPlateActivated = false;

    public Animator doorAnim;
    // Start is called before the first frame update
    void Start()
    {
        wand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (plate1.isClicked && plate2.isClicked && plate3.isClicked && plate4.isClicked && allPlateActivated == false)
        {
            doorAnim.SetBool("activated", true);
            allPlateActivated = true;
        }
    }
}
