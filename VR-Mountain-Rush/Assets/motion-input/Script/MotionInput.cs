using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionInput : MonoBehaviour
{
    
    public GameObject left;
    public GameObject right;
    HandMotionDetect speedL;
    HandMotionDetect speedR;
    [SerializeField]private static float averageHandSpeed;
    public float avgHandSpeed;

    // Start is called before the first frame update
    void Start()
    {
        speedL = left.GetComponent<HandMotionDetect>();
        speedR = right.GetComponent<HandMotionDetect>();
    }

    // Update is called once per frame
    void Update()
    {
        //averageHandSpeed = (speedL.avgSpeedSeg + speedR.avgSpeedSeg)/2;
        AvgSpeed();
        avgHandSpeed = averageHandSpeed;
    }

    public static float GetAverageHandSpeed()
    {
        return averageHandSpeed;
    }

    private void AvgSpeed()
    {
        if (speedL.avgSpeedSeg > 0 && speedR.avgSpeedSeg < 0.5)
            averageHandSpeed = speedL.avgSpeedSeg * 0.8f;
        else if (speedL.avgSpeedSeg < 0.5 && speedR.avgSpeedSeg > 0)
            averageHandSpeed = speedR.avgSpeedSeg * 0.8f;
        else if (speedR.avgSpeedSeg > 0.5 && speedL.avgSpeedSeg > 0.5)
            averageHandSpeed = (speedL.avgSpeedSeg + speedR.avgSpeedSeg) / 2;
        else
            averageHandSpeed = 0;
    }
}
