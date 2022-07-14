using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class Gripping : MonoBehaviour
{
    public bool handIsLeft;
    public Animator handAnimator;

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
    public bool grip;
    public bool trig;
    public bool preTrig;

    HandMotionDetect handMotion;

    public GameObject menuObj;
    public GameObject leftButtonObj;
    public GameObject rightButtonObj;



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

    void FixedUpdate()
    {
        if (handIsLeft)
        {
            grip = (vra.hand.gripLeft.ReadValue<float>() != 0);
            trig = (vra.hand.TrigLeft.ReadValue<float>() != 0);
            preTrig = (vra.hand.PreTrigLeft.ReadValue<float>() != 0);
        }
        else
        {
            grip = (vra.hand.gripRight.ReadValue<float>() != 0);
            trig = (vra.hand.TrigRight.ReadValue<float>() != 0);
            preTrig = (vra.hand.PreTrigRight.ReadValue<float>() != 0);
        }

        handAnimator.SetBool("Gripped", grip);
        handAnimator.SetBool("PreTrigger",preTrig);
        handAnimator.SetBool("Triggered", trig);
    }

    // Update is called once per frame
    void Update()
    {
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

        if (handIsLeft)
        {
            if (leftButtonObj != null)
            {
                if (vra.hand.leftButton.ReadValue<float>() != 0 && !leftButtonObj.activeSelf)
                {
                    leftButtonObj.SetActive(true);
                }
                else if (vra.hand.leftButton.ReadValue<float>() == 0)
                {
                    leftButtonObj.SetActive(false);
                }
            }
        }
        else 
        {
            if (rightButtonObj != null)
            {
                if (vra.hand.rightButton.ReadValue<float>() != 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }

        if (menuObj != null)
        {
            if (vra.hand.Menu.ReadValue<float>() != 0 && !menuObj.activeSelf)
            {
                menuObj.SetActive(true);
                GetComponent<VRUI>().enabled = true;
            }
            else if (vra.hand.Menu.ReadValue<float>() == 0)
            {
                menuObj.SetActive(false);
                GetComponent<VRUI>().enabled = false;
            }
        }

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
                    if (trig)
                        holdingObj.GetComponent<Grippable>().IsTriggered = true;
                    else
                        holdingObj.GetComponent<Grippable>().IsTriggered = false;

                    if (preTrig)
                        holdingObj.GetComponent<Grippable>().IsPreTrigger = true;
                    else
                        holdingObj.GetComponent<Grippable>().IsPreTrigger = false;

                    //holdingObj.transform.position = transform.position + beforeGripObjDistance;
                    //holdingObj.transform.rotation = transform.rotation * Quaternion.Inverse(beforeGripHandRotation) * beforeGripObjRotation;
                }
                    

            }
        }
    }
}
