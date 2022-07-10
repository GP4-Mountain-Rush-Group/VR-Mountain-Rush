using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionInput : MonoBehaviour
{
    
    public GameObject left;
    public GameObject right;
    HandMotionDetect speedL;
    HandMotionDetect speedR;
    public float averageHandSpeed;

    // Start is called before the first frame update
    void Start()
    {
        speedL = left.GetComponent<HandMotionDetect>();
        speedR = right.GetComponent<HandMotionDetect>();
    }

    // Update is called once per frame
    void Update()
    {
        averageHandSpeed = (speedL.avgSpeedSeg + speedR.avgSpeedSeg)/2;
    }

    public float GetAverageHandSpeed()
    {
        return averageHandSpeed;
    }
}
