using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionDetect : MonoBehaviour
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


    float DeltaLocalX;
    float oldLocalX;
    float DeltaLocalY;
    float oldLocalY;
    float DeltaLocalZ;
    float oldLocalZ;

    public GameObject obj;
    public float freqAvgSpeed = 0f;
    float preSpeed = 0f;
    public float avgSpeed = 0f;

    public float minDistLimit = 0.3f;


    void Start()
    {
        StartCoroutine(waitToCheckDistance());
        StartCoroutine(averageSpeed());
        StartCoroutine(get3AxisFinal());
    }

    IEnumerator get3AxisFinal()
    {
        oldLocalX = obj.transform.localPosition.x;
        oldLocalY = obj.transform.localPosition.y;
        oldLocalZ = obj.transform.localPosition.z;

        while (true)
        {
            DeltaLocalX = obj.transform.localPosition.x - oldLocalX;
            oldLocalX = obj.transform.localPosition.x;
            getPosFinal(ref xSlot1, ref xSlot2, ref xFinal, ref xOppCount, ref xIsNeg, DeltaLocalX);

            DeltaLocalY = obj.transform.localPosition.y - oldLocalY;
            oldLocalY = obj.transform.localPosition.y;
            getPosFinal(ref ySlot1, ref ySlot2, ref yFinal, ref yOppCount, ref yIsNeg, DeltaLocalY);

            DeltaLocalZ = obj.transform.localPosition.z - oldLocalZ;
            oldLocalZ = obj.transform.localPosition.z;
            getPosFinal(ref zSlot1, ref zSlot2, ref zFinal, ref zOppCount, ref zIsNeg, DeltaLocalZ);

            yield return new WaitForSeconds(0.03f);
        }

    }



    void getPosFinal(ref float slot1, ref float slot2, ref float final, ref int oppCount, ref bool isNeg,float DeltaLocalP)
    {

        if (!isNeg)
        {
            if (oppCount < 2)
            {
                if (DeltaLocalP> 0)
                {
                    oppCount = 0;
                    slot1 += DeltaLocalP;
                    Debug.Log(slot1);
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
                    Debug.Log(slot1);
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

    IEnumerator waitToCheckDistance()
    {
        while(true){
            if ((xFinal != 0 && yFinal != 0 )|| (yFinal != 0 && zFinal != 0)|| (xFinal != 0 && zFinal != 0)) {//&& zFinal != 0){
                dFinal = Mathf.Sqrt(xFinal * xFinal + yFinal * yFinal + zFinal * zFinal);
                if (dFinal > minDistLimit)
                {
                    xFinal = 0;
                    yFinal = 0;
                    zFinal = 0;
                    preSpeed += 0.5f;
                }
            }
            
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator averageSpeed()
    {
        while (true) {
            avgSpeed = (float)preSpeed / (float) freqAvgSpeed;
            preSpeed = 0;

            yield return new WaitForSeconds(freqAvgSpeed);
        }
    }
}
