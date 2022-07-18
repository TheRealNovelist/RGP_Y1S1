using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickBlock : MonoBehaviour
{
    public GameObject checkObject;
    GameObject holdObject;
    Rigidbody holdObjectRig;
    public Camera playerCam;

    BuildZone buildZone;
    PopUpBehaviour popUpScript;
    public Text popUp;

    public float range = 10f;
    public float speed = 1f;
    public float force = 10f;
    public float chargeTime = 1f;
    public float chargeRate;
    public float chargeLimit;

    public bool holding = false;
    public bool launching = false;

    private void Start()
    {
        popUp.enabled = false;
    }

    private void Update()
    {
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * range, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            checkObject = hit.transform.gameObject;
            if (hit.transform.gameObject.GetComponent<PopUpBehaviour>() != null)
            {
                popUpScript = hit.transform.gameObject.GetComponent<PopUpBehaviour>();
                popUp.enabled = true;
                popUp.text = popUpScript.popUpText;
            }
            else
            {
                popUpScript = null;
                popUp.enabled = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range) && holding == false && checkObject != null)
            {
                BlockDetection();
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
    private void FixedUpdate()
    {
        if (holding == true)
        {
            Picking();
        }
        else if (holding == false)
        {
            StartCoroutine(Release());
        }

        if (launching == true)
        {
            StartCoroutine(ChargeShot());
            chargeTime = 0f;
        }
    }
    void BlockDetection()
    {
        if (checkObject.GetComponent<BlockProperty>() != null) 
        {
            if (checkObject.GetComponent<BlockProperty>().pickable == true)
            {
                holdObject = checkObject;
                checkObject = null;
                holding = true;
            }
        }
        else if (checkObject.GetComponent<BuildZone>() != null)
        {
            if (checkObject.GetComponent<BuildZone>().isBuild == true)
            {
                buildZone = checkObject.gameObject.GetComponent<BuildZone>();
                checkObject = null;
                BuildingReset();
            }
        }
        else if (checkObject.GetComponent<SwitchScript>() != null)
        {
            if(checkObject.GetComponent<SwitchScript>().isToggle == true)
            {
                if (checkObject.GetComponent<SwitchScript>().isPressed == false)
                {
                    checkObject.GetComponent<SwitchScript>().OnPressed();
                }
                else
                {
                    checkObject.GetComponent<SwitchScript>().OnReleased();
                }
            }
            else
            {
                if (checkObject.GetComponent<SwitchScript>().isPressed == false)
                {
                    checkObject.GetComponent<SwitchScript>().OnPressed();
                }
            }
            
        }
    }
    void Picking()
    {
        holdObject.transform.position = Vector3.Lerp(holdObject.transform.position, this.gameObject.transform.position, speed * Time.deltaTime);
        holdObjectRig = holdObject.GetComponent<Rigidbody>();
        holdObjectRig.useGravity = false;
        holdObject.GetComponent<Collider>().enabled = false;
        holdObjectRig.velocity = Vector3.zero;
        holdObject.transform.parent = this.transform;
    }
    IEnumerator Release()
    {
        if(holdObject != null)
        {
            holdObjectRig.useGravity = true;
            holdObject.GetComponent<Collider>().enabled = true;
            holdObject.transform.parent = null;
            yield return new WaitForSeconds(0.01f);
            holdObject = null;
        }
    }
    IEnumerator ChargeShot()
    {
        if (holdObject != null)
        {
            holdObjectRig.useGravity = true;
            holdObject.GetComponent<Collider>().enabled = true;
            holdObjectRig.AddForce(this.gameObject.transform.forward * force * chargeTime, ForceMode.Impulse);
            holdObject.transform.parent = null;
            yield return new WaitForSeconds(0.01f);
            holdObject = null;
            launching = false;
        }
    }
    void BuildingReset()
    {
        buildZone.storedBlock.SetActive(true);
        holdObject = buildZone.storedBlock;
        holdObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        holding = true;
        buildZone.storedBlock = null;
        buildZone.Deactivate();
        buildZone = null;
    }
}
