using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class HandMotionDetect : MonoBehaviour
{

    public float dFinal = 0;

    bool xIsNeg = false;
    int xOppCount = 0;
    float xSlot1 = 0;
    float xSlot2 = 0;
    public float xFinal = 0;

    bool yIsNeg = false;
    int yOppCount = 0;
    float ySlot1 = 0;
    float ySlot2 = 0;
    public float yFinal = 0;

    bool zIsNeg = false;
    int zOppCount = 0;
    float zSlot1 = 0;
    float zSlot2 = 0;
    public float zFinal = 0;


    public float DeltaLocalX;
    float oldLocalX;
    public float DeltaLocalY;
    float oldLocalY;
    public float DeltaLocalZ;
    float oldLocalZ;

    public Quaternion DeltaRotation;
    public Quaternion oldRotation;

    public GameObject obj;

    public float freqAvgSpeed = 0.5f;
    float preSpeedSeg = 0f;
    public float avgSpeedSeg = 0f;
    public float avgSpeed = 0f;

    public float minDistLimit = 0.3f;

    Queue<float> queueAverageSpeed = new Queue<float>(4);

    public SkinnedMeshRenderer thisMeshRenderer;
    public TrailRenderer thisTrailRenderer;

    void Start()
    {
        obj = this.gameObject;

        thisTrailRenderer.time = 1;
        thisTrailRenderer.startWidth = 0.05f;
        thisTrailRenderer.endWidth = 0f;
        thisTrailRenderer.endColor = new Color(1,1,1,0);

        queueAverageSpeed.Enqueue(0);
        queueAverageSpeed.Enqueue(0);
        queueAverageSpeed.Enqueue(0);
        queueAverageSpeed.Enqueue(0);


        StartCoroutine(WaitToCheckDistance());
        StartCoroutine(AverageSpeed());
        StartCoroutine(Get3AxisFinal());
        StartCoroutine(GetDeltaRotation());

    }

    private void Update()
    {
        Debug.Log(avgSpeedSeg);
        if ( avgSpeedSeg > 1 && (thisMeshRenderer.enabled == true || thisTrailRenderer == false)){
            thisMeshRenderer.enabled = false;
            thisTrailRenderer.enabled = true;
        }
        else if (avgSpeedSeg <= 1 && (thisMeshRenderer.enabled == false || thisTrailRenderer == true))
        {
            thisMeshRenderer.enabled = true;
            thisTrailRenderer.enabled = false;
        }
    }

    IEnumerator Get3AxisFinal()
    {
        oldLocalX = obj.transform.localPosition.x;
        oldLocalY = obj.transform.localPosition.y;
        oldLocalZ = obj.transform.localPosition.z;

        while (true)
        {
            DeltaLocalX = obj.transform.localPosition.x - oldLocalX;
            oldLocalX = obj.transform.localPosition.x;
            GetPosFinal(ref xSlot1, ref xSlot2, ref xFinal, ref xOppCount, ref xIsNeg, DeltaLocalX);

            DeltaLocalY = obj.transform.localPosition.y - oldLocalY;
            oldLocalY = obj.transform.localPosition.y;
            GetPosFinal(ref ySlot1, ref ySlot2, ref yFinal, ref yOppCount, ref yIsNeg, DeltaLocalY);

            DeltaLocalZ = obj.transform.localPosition.z - oldLocalZ;
            oldLocalZ = obj.transform.localPosition.z;
            GetPosFinal(ref zSlot1, ref zSlot2, ref zFinal, ref zOppCount, ref zIsNeg, DeltaLocalZ);

            yield return new WaitForFixedUpdate();
        }

    }
    IEnumerator GetDeltaRotation()
    {
        oldRotation = obj.transform.rotation;

        while (true)
        {
            DeltaRotation = obj.transform.rotation * Quaternion.Inverse(oldRotation);
            oldRotation = obj.transform.rotation;

            yield return new WaitForFixedUpdate();
        }
    }


    void GetPosFinal(ref float slot1, ref float slot2, ref float final, ref int oppCount, ref bool isNeg,float DeltaLocalP)
    {

        if (!isNeg)
        {
            if (oppCount < 2)
            {
                if (DeltaLocalP> 0)
                {
                    oppCount = 0;
                    slot1 += DeltaLocalP;
                }
                else
                {
                    oppCount++;
                    slot2 += DeltaLocalP;
                }
            }
            else
            {
                final = slot1;
                slot1 = slot2;
                slot2 = 0;
                oppCount = 0;
                isNeg = true;
            }
        }
        else
        {
            if (oppCount < 2)
            {
                if (DeltaLocalP < 0)
                {
                    oppCount = 0;
                    slot1 += DeltaLocalP;
                }
                else
                {
                    oppCount++;
                    slot2 += DeltaLocalP;
                }
            }
            else
            {
                final = slot1;
                slot1 = slot2;
                slot2 = 0;
                oppCount = 0;
                isNeg = false;
            }
        }
    }

    IEnumerator WaitToCheckDistance()
    {
        while(true){
            if ((xFinal != 0 && yFinal != 0 )|| (yFinal != 0 && zFinal != 0)|| (xFinal != 0 && zFinal != 0)) {//&& zFinal != 0){
                dFinal = Mathf.Sqrt(xFinal * xFinal + yFinal * yFinal + zFinal * zFinal);
                if (dFinal > minDistLimit)
                {
                    xFinal = 0;
                    yFinal = 0;
                    zFinal = 0;
                    preSpeedSeg += 0.5f;
                }
            }
            
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator AverageSpeed()
    {
        while (true) {
            avgSpeedSeg = (float)preSpeedSeg / (float) freqAvgSpeed;
            preSpeedSeg = 0;


            thisTrailRenderer.startColor = new Color(1, 1 / (avgSpeedSeg * 3f), 1 / (avgSpeedSeg * 3f), 1);

            queueAverageSpeed.Dequeue();
            queueAverageSpeed.Enqueue(avgSpeedSeg);

            avgSpeed = 0;
            foreach (float speedSeg in queueAverageSpeed)
            {
                avgSpeed += speedSeg;
            }
            avgSpeed /= 4;

            yield return new WaitForSeconds(freqAvgSpeed);
        }
    }
}
