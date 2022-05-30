using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionDetect : MonoBehaviour
{
    bool xIsNeg = false;
    int xOppCount = 0;
    float xSlot1 = 0;
    float xSlot2 = 0;
    float xFinal = 0;

    GameObject obj;
    float localX;

    private void Start()
    {
        StartCoroutine(waitToCheckDistance());
    }

    private void Update()
    {
        localX = obj.transform.localPosition.x;
        getPosFinal(ref xSlot1,ref xSlot2,ref xFinal,ref xOppCount,ref xIsNeg,localX);




    }



    void getPosFinal(ref float slot1, ref float slot2, ref float final, ref int oppCount, ref bool isNeg,float localP)
    {

        if (!isNeg)
        {
            if (oppCount < 2)
            {
                if (localP> 0)
                {
                    oppCount = 0;
                    slot1 += localP;
                }
                else
                {
                    oppCount++;
                    slot2 += localP;
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
                if (localP < 0)
                {
                    oppCount = 0;
                    slot1 += localP;
                }
                else
                {
                    oppCount++;
                    slot2 += localP;
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


            yield return new WaitForSeconds(2);
        }
    }
}
