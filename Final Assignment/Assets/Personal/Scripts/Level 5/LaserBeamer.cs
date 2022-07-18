using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamer : MonoBehaviour
{
    public GameObject laserBase;
    public GameObject laserRotator;
    public float speed;

    Quaternion fromRotation;
    Quaternion toRotation;

    public void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            laserRotator.transform.rotation = Quaternion.Lerp(laserRotator.transform.rotation, Quaternion.Euler(laserRotator.transform.localRotation.x, -90f, 90f), speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.K))
        {
            laserRotator.transform.rotation = Quaternion.Lerp(laserRotator.transform.rotation, Quaternion.Euler(laserRotator.transform.localRotation.x, 90f, 90f), speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.U))
        {
            laserRotator.transform.rotation = Quaternion.Lerp(laserRotator.transform.rotation, Quaternion.Euler(90f, laserRotator.transform.localRotation.y, 90f), speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.J))
        {
            laserRotator.transform.rotation = Quaternion.Lerp(laserRotator.transform.rotation, Quaternion.Euler(-90f, laserRotator.transform.localRotation.y, 90f), speed * Time.deltaTime);
        }
    }
}
