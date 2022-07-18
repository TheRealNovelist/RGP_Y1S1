using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer laserLine;
    ReflectPane reflectPane;
    Receptor receptor;
    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawLine(transform.position, transform.forward, Color.yellow);
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                laserLine.SetPosition(1, new Vector3(0f, 0f, hit.distance));
            }
            
            if (hit.collider.gameObject.GetComponent<ReflectPane>() != null)
            {
                reflectPane = hit.collider.gameObject.GetComponent<ReflectPane>();
                reflectPane.hitLine = this.gameObject;
            }
            else if (hit.collider.gameObject.GetComponent<ReflectPane>() == null)
            {
                if (reflectPane != null)
                {
                    reflectPane.hitLine = null;
                    reflectPane = null;
                }
            }

            if (hit.collider.gameObject.GetComponent<Receptor>() != null)
            {
                receptor = hit.collider.gameObject.GetComponent<Receptor>();
                receptor.currentLaser = this.gameObject;
                receptor.ReceptorOn();
            }
            else if (hit.collider.gameObject.GetComponent<Receptor>() == null)
            {
                if (receptor != null)
                {
                    if (receptor.currentLaser == this.gameObject)
                    {
                        receptor.currentLaser = null;
                        receptor = null;
                    }
                }
            }
        }
        else
        {
            laserLine.SetPosition(1, new Vector3(0f, 0f, 5000f)); ;
        }
    }

    private void OnDisable()
    {
        if (reflectPane != null)
        {
            reflectPane.hitLine = null;
            reflectPane = null;
        }

        if (receptor != null)
        {
            if (receptor.currentLaser == this.gameObject)
            {
                receptor.currentLaser = null;
                receptor = null;
            }
        }
    }
}
