using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionDetect : MonoBehaviour
{

    float dFinal = 0;

    bool xIsNeg = false;
    int xOppCount = 0;
    float xSlot1 = 0;
    float xSlot2 = 0;
    float xFinal = 0;

    bool yIsNeg = false;
    int yOppCount = 0;
    float ySlot1 = 0;
    float ySlot2 = 0;
    float yFinal = 0;

    bool zIsNeg = false;
    int zOppCount = 0;
    float zSlot1 = 0;
    float zSlot2 = 0;
    float zFinal = 0;

    GameObject obj;
    float DeltaLocalX;
    float oldLocalX;
    float DeltaLocalY;
    float oldLocalY;
    float DeltaLocalZ;
    float oldLocalZ;

    private void Start()
    {
        StartCoroutine(waitToCheckDistance());
    }

    private void Update()
    {

        DeltaLocalX = obj.transform.localPosition.x - oldLocalX;
        oldLocalX = obj.transform.localPosition.x;
        getPosFinal(ref xSlot1,ref xSlot2,ref xFinal,ref xOppCount,ref xIsNeg,DeltaLocalX);




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
                isNeg = false;
            }
        }
    }

    IEnumerator waitToCheckDistance(){
        while(true){
            if (xFinal != 0 && yFinal != 0 && zFinal != 0){
                dFinal = Mathf.Sqrt(xFinal * xFinal + yFinal * yFinal + zFinal * zFinal);
                xFinal = 0;
                yFinal = 0;
                zFinal = 0;
            }

            yield return new WaitForSeconds(2);
        }
    }
}
