using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekinesisCon : MonoBehaviour
{
    public GameObject selectedObject;
    public Rigidbody selectedRig;

    public BuildZone buildZone;

    public Camera fpsCam;
    public float travelTime = 1f;

    public string[] selectableTags = { "Pickable", "Explosive" };

    public float chargeTime = 1f;
    public float chargeRate;
    public float chargeLimit;
    public float force = 10;
    public float blockMass;

    public float range = 12f;

    public bool holding = false;
    bool launching = false;

    void Update()
    {
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.yellow);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitObject;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitObject, range) && holding == false)
            {
                foreach (string tagToText in selectableTags)
                {
                    if (hitObject.transform.gameObject.tag == tagToText)
                    {
                        holding = true;
                    } 
                    else if (hitObject.transform.gameObject.tag == "Built")
                    {
                        buildZone = hitObject.transform.gameObject.GetComponentInParent<BuildZone>();
                        StartCoroutine(BuildingBlockReturn());
                    }
                }
            }
            else if (holding == true)
            {
                holding = false;
            }
        }
        if (holding == true)
        {
             if (Input.GetMouseButton(1))
             {
                if (chargeTime <= chargeLimit)
                {
                chargeTime += chargeRate;
                }
             }
            if (Input.GetMouseButtonUp(1))
            {
                launching = true;
                holding = false;
            }
        }
    }
    void FixedUpdate()
    {
        if (holding == true)
        {
            Picking();
            
        }
        else
        {
            StartCoroutine(Release());
        }

        if (launching == true)
        {
            StartCoroutine(ChargeShot());
            chargeTime = 1f;
        }
    }
    void Picking()
    {
        float speed = travelTime * Time.deltaTime;
        if (selectedObject == null)
        {
            RaycastHit hitObject;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitObject, range))
            {
                foreach (string tagToText in selectableTags)
                {
                    if (hitObject.transform.tag == tagToText)
                    {
                        selectedObject = hitObject.transform.gameObject;
                        selectedRig = hitObject.transform.GetComponent<Rigidbody>();
                        selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position, this.gameObject.transform.position, speed);
                        selectedRig.useGravity = false;
                        selectedObject.GetComponent<Collider>().enabled = false;
                        blockMass = selectedRig.mass;
                    }
                }
            }
        }
        else
        {
            selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position, this.gameObject.transform.position, travelTime);
        }
    }
    
    IEnumerator Release()
    {
        if (selectedObject != null)
        {
            selectedRig.useGravity = true;
            selectedObject.GetComponent<Collider>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            selectedObject = null;
        }
    }
    IEnumerator ChargeShot()
    {
        if (selectedRig != null)
        {
            selectedRig.useGravity = true;
            selectedRig.AddForce(this.gameObject.transform.forward * force * chargeTime * blockMass, ForceMode.Impulse);
            selectedObject.GetComponent<Collider>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            selectedObject = null;
            launching = false;
        }
    }
    IEnumerator BuildingBlockReturn()
    {
        selectedObject = buildZone.storedBlock;
        selectedObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        holding = true;
        
        buildZone.storedBlock = null;
        buildZone.Deactivate();
    }
}
