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

    VRAction vra;
    bool grip;

    HandMotionDetect handMotion;

    private void Awake()
    {
        vra = new VRAction();
    }

    private void OnEnable()
    {
        vra.Enable();
    }

    private void OnDisable()
    {
        vra.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        //List<InputDevice> listContro = new List<InputDevice>();
        //InputDeviceCharacteristics controChara;
        //if (handIsLeft)
        //    controChara = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        //else
        //    controChara = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        //InputDevices.GetDevicesWithCharacteristics(controChara, listContro);
        //contro = listContro[0];
        //
        //handMotion = GetComponent<HandMotionDetect>();
    }

    // Update is called once per frame
    void Update()
    {
        //contro.TryGetFeatureValue(CommonUsages.gripButton, out grip);
        if (handIsLeft)
            grip = (vra.hand.gripLeft.ReadValue<float>() != 0);
        else
            grip = (vra.hand.gripRight.ReadValue<float>() != 0);




        if (!grip && holdingObj != null)
        {
            if (!holdingObj.GetComponent<Grippable>().IsKinematic)
                holdingObj.GetComponent<Rigidbody>().isKinematic = false;
            holdingObj.transform.SetParent(holdingObjParent);
            if (handIsLeft)
                holdingObj.GetComponent<Rigidbody>().velocity = vra.hand.veloLeft.ReadValue<Vector3>();
            else
                holdingObj.GetComponent<Rigidbody>().velocity = vra.hand.veloRight.ReadValue<Vector3>();
            holdingObj.GetComponent<Grippable>().ReleaseObject();
            isGripping = false;
            holdingObj = null;
        }
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
                if (!isGripping && !other.GetComponent<Grippable>().IsGripped)
                {
                    holdingObj = other.gameObject;
                    holdingObjParent = holdingObj.transform.parent;
                    holdingObj.transform.SetParent(transform);
                    holdingObj.GetComponent<Grippable>().GripObject(gameObject.transform);
                    holdingObj.GetComponent<Rigidbody>().isKinematic = true;
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
        }
    }
}