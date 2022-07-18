using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Event : MonoBehaviour
{
   

    public DoorScript door1;
    public DoorScript door2;

    public PressurePlate plate1;
    public PressurePlate plate2;

    public bool isActivated;

    void Start()
    {
        door1.DoorOpen();
    }
    private void Update()
    {
        DoorActivation();
    }
    
    void DoorActivation()
    {
        if (plate1.isClicked == true && plate2.isClicked == true && isActivated == false)
        {
            door2.DoorOpen();
            isActivated = true;
        }
        else if ((plate1.isClicked == false || plate2.isClicked == false) && isActivated == true)
        {
            door2.DoorClose();
            isActivated = false;
        }
    }
    
}
