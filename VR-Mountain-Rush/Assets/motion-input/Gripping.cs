using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Gripping : MonoBehaviour
{
    public bool handIsLeft;

    Vector3 oldPos;
    Vector3 nowPos;
    Vector3 deltaPos;

    bool isGripping = false;
    GameObject holdingObj;
    Transform holdingObjParent;
    Vector3 beforeGripObjDistance;
    Quaternion beforeGripObjRotation;
    Quaternion beforeGripHandRotation;

    InputDevice contro;

    bool grip;

    HandMotionDetect handMotion;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> listContro = new List<InputDevice>();
        InputDeviceCharacteristics controChara;
        if (handIsLeft)
            controChara = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        else
            controChara = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(controChara, listContro);
        contro = listContro[0];

        handMotion = GetComponent<HandMotionDetect>();
    }

    // Update is called once per frame
    void Update()
    {
        contro.TryGetFeatureValue(CommonUsages.gripButton, out grip);

        //nowPos = transform.position;
        //deltaPos = nowPos - oldPos;
        //oldPos = nowPos;
    }

    void FixedUpdate()
    {
        //if (grip && isGripping)
        //{
        //    holdingObj.GetComponent<Rigidbody>().MovePosition(transform.position + beforeGripObjDistance);
        //    holdingObj.GetComponent<Rigidbody>().MoveRotation(transform.rotation * Quaternion.Inverse(beforeGripHandRotation) * beforeGripObjRotation);
        //}
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("grippable"))
        {
            if (grip)
            {
                if (!isGripping)
                {
                    holdingObj = other.gameObject;
                    holdingObj.GetComponent<Rigidbody>().isKinematic = true;
                    holdingObjParent = holdingObj.transform.parent;
                    holdingObj.transform.SetParent(transform);
                    beforeGripObjDistance = holdingObj.transform.position - transform.position;
                    beforeGripObjRotation = holdingObj.transform.rotation;
                    beforeGripHandRotation = transform.rotation;
                    isGripping = true;

                }
                else
                {
                    //holdingObj.transform.position = transform.position + beforeGripObjDistance;
                    //holdingObj.transform.rotation = transform.rotation * Quaternion.Inverse(beforeGripHandRotation) * beforeGripObjRotation;
                }
                    

            }
            else if (!grip && holdingObj != null)
            {
                holdingObj.GetComponent<Rigidbody>().isKinematic = false;
                holdingObj.transform.SetParent(holdingObjParent);
                holdingObj.GetComponent<Rigidbody>().velocity = OVRInput.
                isGripping = false;
                holdingObj = null;
            }
        }
    }
}
