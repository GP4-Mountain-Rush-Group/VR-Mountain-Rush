using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bicycleHandle : MonoBehaviour
{
    public float finalAngle = 0;
    public GameObject center;
    public GameObject leftHandle;
    public GameObject rightHandle;
    public Vector3 handleScale = new Vector3(0.5f,0.1f,0.1f);
    
    
    Transform leftHandleSepa;
    Transform rightHandleSepa;

    float leftDistance = 0;
    float rightDistance = 0;

    float leftAngle = -90;
    float rightAngle = 90;

    // Start is called before the first frame update
    void Start()
    {
        leftHandleSepa = leftHandle.transform.GetChild(0);
        rightHandleSepa = rightHandle.transform.GetChild(0);
        leftHandleSepa.localScale = handleScale;
        rightHandleSepa.localScale = handleScale;
    }

    // Update is called once per frame
    void Update()
    {
        leftDistance = Mathf.Sqrt(leftHandleSepa.localPosition.x * leftHandleSepa.localPosition.x + leftHandleSepa.localPosition.y * leftHandleSepa.localPosition.y + leftHandleSepa.localPosition.z * leftHandleSepa.localPosition.z);
        rightDistance = Mathf.Sqrt(rightHandleSepa.localPosition.x * rightHandleSepa.localPosition.x + rightHandleSepa.localPosition.y * rightHandleSepa.localPosition.y + rightHandleSepa.localPosition.z * rightHandleSepa.localPosition.z);

        
    }
}
