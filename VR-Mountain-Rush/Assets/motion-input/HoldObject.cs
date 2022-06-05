using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HoldObject : MonoBehaviour
{
    public bool handIsLeft;

    Vector3 oldPos;
    Vector3 nowPos;
    Vector3 deltaPos;

    bool isGripping = false;
    GameObject holdingObj;
    Vector3 beforeGripDistance;
    Quaternion beforeGripRotation;


    InputDevice contro;

    bool grip;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        contro.TryGetFeatureValue(CommonUsages.gripButton, out grip);

        //nowPos = transform.position;
        //deltaPos = nowPos - oldPos;
        //oldPos = nowPos;
    }

    void LateUpdate()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("grippable"))
        {
            Debug.Log(other);
            if (grip)
            {
                if (!isGripping)
                {
                    holdingObj = other.gameObject;
                    beforeGripDistance = holdingObj.transform.position - transform.position;
                    beforeGripRotation = holdingObj.transform.rotation;
                    isGripping = true;

                }
                else
                {
                    holdingObj.transform.position = transform.position + beforeGripDistance;
                    holdingObj.transform.rotation = transform.rotation * Quaternion.Inverse(beforeGripRotation);
                }
                    

            }
            else if (!grip)
            {
                isGripping = false;
                holdingObj = null;
            }
        }
    }
}
