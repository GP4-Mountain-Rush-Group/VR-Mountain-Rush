using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grippable : MonoBehaviour
{
    public bool autoSetLocPosRot = true;
    public Vector3 origLocPos;
    public Quaternion origLocRot;

    public Quaternion gripRotation;
    public bool IsOnGripRotate = true;
    public bool IsOffGripReset = true;
    public bool IsReleased = false;
    float t;

    private void Start()
    {
        tag = "grippable";
        if (autoSetLocPosRot == true)
        {
            origLocPos = gameObject.transform.localPosition;
            origLocRot = gameObject.transform.localRotation;
        }
    }

    private void Update()
    {
        if (IsOffGripReset == true && IsReleased == true){
            t += Time.deltaTime;
            
        }
    }

    public void offGripReset()
    {
        
        gameObject.transform.localPosition = origLocPos;
        gameObject.transform.localRotation = origLocRot;
    }

    2*x(2-x)\-1
}