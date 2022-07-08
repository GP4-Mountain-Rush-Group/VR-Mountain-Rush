using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bicycleHandleOld : MonoBehaviour
{
    public float finalAngle = 0;
    public GameObject center;
    public GameObject leftHandle;
    public GameObject rightHandle;
    public Vector3 handleScale = new Vector3(0.5f,0.1f,0.1f);
    public float handleOffset = 0.5f;
    
    
    Transform leftHandleSepa;
    Transform rightHandleSepa;

    float leftDistance = 0;
    float rightDistance = 0;

    float leftAngle = 0;
    float rightAngle = 0;

    Vector3 leftSepaPos = new Vector3();
    Vector3 rightSepaPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        leftHandleSepa = leftHandle.transform.GetChild(0);
        rightHandleSepa = rightHandle.transform.GetChild(0);
        leftHandleSepa.localScale = handleScale;
        rightHandleSepa.localScale = handleScale;

        leftHandle.transform.localPosition = new Vector3(-handleOffset,0,0);
        rightHandle.transform.localPosition = new Vector3(handleOffset,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        //leftSepaPos = leftHandleSepa.position-

        leftDistance = Mathf.Sqrt(leftHandleSepa.localPosition.x * leftHandleSepa.localPosition.x + leftHandleSepa.localPosition.y * leftHandleSepa.localPosition.y + leftHandleSepa.localPosition.z * leftHandleSepa.localPosition.z);
        rightDistance = Mathf.Sqrt(rightHandleSepa.localPosition.x * rightHandleSepa.localPosition.x + rightHandleSepa.localPosition.y * rightHandleSepa.localPosition.y + rightHandleSepa.localPosition.z * rightHandleSepa.localPosition.z);

        if (leftHandleSepa.localPosition.z != 0 && (leftHandleSepa.localPosition.x - handleOffset) != 0)
            leftAngle = -Mathf.Atan((-leftHandleSepa.localPosition.z) / (leftHandleSepa.localPosition.x - handleOffset)) * Mathf.Rad2Deg;
        else
            leftAngle = 0;

        if (rightHandleSepa.localPosition.z != 0 && (rightHandleSepa.localPosition.x + handleOffset) != 0)
            rightAngle = Mathf.Atan((-rightHandleSepa.localPosition.z) / (rightHandleSepa.localPosition.x + handleOffset)) * Mathf.Rad2Deg;
        else
            rightAngle = 0;

        if (rightAngle != 0 || leftAngle != 0)
        {
            RotateHandle();
        }
            

    }
    void RotateHandle()
    {
        float totalDistance = leftDistance + rightDistance;
        float angleNeedToRotate = ((rightAngle * rightDistance / totalDistance) - (leftAngle * leftDistance / totalDistance));//+ finalAngle;
        //finalAngle = angleNeedToRotate;
        center.transform.localEulerAngles = new Vector3(0, angleNeedToRotate, 0);

        Debug.Log("||   totalDistance:" + totalDistance + "||   angleNeedToRotate:" + angleNeedToRotate + "||   RA:" + rightAngle);
    }
}
