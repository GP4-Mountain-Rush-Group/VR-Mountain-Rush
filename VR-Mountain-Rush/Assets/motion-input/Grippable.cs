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
    public bool GripRotate = true;
    public bool GripPosit = true;
    public bool releaseReset = true;
    public bool IsGripped = false;
    public bool IsKinematic = true;
    bool resetCompleted = true;

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
        IsGripped = true;
        if (GripPosit)
        transform.position = handTransform.position + gripPosition;
        
        if (GripRotate)
        transform.rotation = handTransform.rotation * gripRotation;

        resetCompleted = false;
    }



    public void ReleaseObject()
    {
        IsGripped = false;
    }

    IEnumerator resetAnimation()
    {
        while (true)
        {
            
            if (releaseReset == true && IsGripped == false && resetCompleted == false)
            {
                Vector3 dfiV = origLocPos - gameObject.transform.localPosition;
                Quaternion dfiQ = origLocRot;

                Vector3 diV = gameObject.transform.localPosition;
                Quaternion diQ = gameObject.transform.localRotation;

                for (float t = 0; t <= 1; t += Time.deltaTime)
                {
                    if (IsGripped)
                        break;

                    gameObject.transform.localPosition = diV + dfiV * (2 * t * (2 - t)/2);
                    gameObject.transform.localRotation = Quaternion.Slerp(diQ, dfiQ, (2 * t * (2 - t) / 2));

                    yield return 0;
                }
                if (!IsGripped)
                    resetCompleted = true;



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
                    if (IsGripped == true)
                        break;

                    gameObject.transform.localPosition = diV + dfiV*(2*t*(2-t)/-1);
                    gameObject.transform.localRotation = diQ + dfiQ * (2 * t * (2 - t) / -1);

                    yield return 0;
                }
*/