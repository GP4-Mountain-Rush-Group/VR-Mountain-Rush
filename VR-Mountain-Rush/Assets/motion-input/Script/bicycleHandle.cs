using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bicycleHandle : MonoBehaviour
{
    public static float finalAngle = 0;
    public Transform center;
    public Transform leftHandle;
    public Transform rightHandle;
    public Vector3 handleScale = new Vector3(0.5f, 0.1f, 0.1f);
    public float handleOffset = 0.5f;
    public float maxTurningAngle = 45;

    Transform leftHandleSepa;
    Transform rightHandleSepa;
    float turnRemainAngle = 0;

    public GameObject PosRef;

    // Start is called before the first frame update
    void Start()
    {
        leftHandle.localPosition = new Vector3(-handleOffset, 0, 0);
        rightHandle.localPosition = new Vector3(handleOffset, 0, 0);
        leftHandleSepa = leftHandle.GetChild(0);
        rightHandleSepa = rightHandle.GetChild(0);
        leftHandleSepa.localScale = handleScale;
        rightHandleSepa.localScale = handleScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PosRef.transform.position;
        transform.rotation = PosRef.transform.rotation;
        if (leftHandleSepa.GetComponent<Grippable>().IsGripped)
            leftHandle.position = leftHandleSepa.position;
        else
            leftHandle.localPosition = new Vector3(-handleOffset, 0, 0);

        if (rightHandleSepa.GetComponent<Grippable>().IsGripped)
            rightHandle.position = rightHandleSepa.position;
        else
            rightHandle.localPosition = new Vector3(handleOffset, 0, 0);

        Vector3 handleDistance = leftHandle.localPosition - rightHandle.localPosition;
        turnRemainAngle = Mathf.Atan((-handleDistance.z) / handleDistance.x) * Mathf.Rad2Deg;
        center.localEulerAngles += new Vector3(0, +turnRemainAngle, 0);

        if (center.localEulerAngles.y > maxTurningAngle && center.localEulerAngles.y < 180)
            center.localEulerAngles = new Vector3(0, 45, 0);

        if ((center.localEulerAngles.y < (-maxTurningAngle) && center.localEulerAngles.y > -180) || (center.localEulerAngles.y < (360 - maxTurningAngle) && center.localEulerAngles.y > 180))
            center.localEulerAngles = new Vector3(0, -45, 0);


        finalAngle = center.localEulerAngles.y;
    }

    public static float GetTurnedAngle()
    {
        return finalAngle;
    }
}
