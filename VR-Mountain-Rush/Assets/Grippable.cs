using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grippable : MonoBehaviour
{
    public bool autoSetLocPosRot = true;
    public Vector3 origLocPos;
    public Quaternion origLocRot;

    public Vector3 gripPosition;
    public Quaternion gripRotation;
    public bool onGripRotate = true;
    public bool offGripReset = true;
    public bool IsReleased = false;

    private void Start()
    {
        tag = "grippable";
        if (autoSetLocPosRot == true)
        {
            origLocPos = gameObject.transform.localPosition;
            origLocRot = gameObject.transform.localRotation;
        }

        StartCoroutine(resetAnimation());
    }

    private void Update()
    {
    }

    //2*x(2-x)\-1

    public void GripObject(Transform handTransform)
    {
        IsReleased = false;
        transform.position = handTransform.position + gripPosition;
        transform.rotation = handTransform.rotation * gripRotation;
    }



    public void ReleaseObject()
    {
        IsReleased = true;
    }

    IEnumerator resetAnimation()
    {
        while (true)
        {
            
            if (offGripReset == true && IsReleased == true)
            {
                Vector3 dfiV = origLocPos - gameObject.transform.localPosition;
                Quaternion dfiQ = origLocRot;

                Vector3 diV = gameObject.transform.localPosition;
                Quaternion diQ = gameObject.transform.localRotation;

                for (float t = 0; t <= 1; t += Time.deltaTime)
                {
                    if (IsReleased == false)
                        break;

                    gameObject.transform.localPosition = diV + dfiV * (2 * t * (2 - t)/2);
                    gameObject.transform.localRotation = Quaternion.Slerp(diQ, dfiQ, (2 * t * (2 - t) / 2));

                    yield return 0;
                }
                
                IsReleased = false;
                

            }
            yield return 0;

        }
    }
}

/*
Vector3 dfiV = origLocPos - gameObject.transform.localPosition;
                Vector3 dfiQ = origLocRot.eulerAngles + Quaternion.Inverse(gameObject.transform.rotation).eulerAngles;

                Vector3 diV = gameObject.transform.localPosition;
                Vector3 diQ = gameObject.transform.localRotation.eulerAngles;

                for (float t = 0; t < 1; t += Time.deltaTime)
                {
                    if (IsReleased == false)
                        break;

                    gameObject.transform.localPosition = diV + dfiV*(2*t*(2-t)/-1);
                    gameObject.transform.localRotation = diQ + dfiQ * (2 * t * (2 - t) / -1);

                    yield return 0;
                }
*/