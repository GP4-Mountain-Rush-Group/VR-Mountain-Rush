using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRUI : MonoBehaviour
{
    public GameObject RayPointerSource;
    public Camera cam;
    public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;
    public LineRenderer lineRenderer;

    Gripping RayPointerSourceGripState;


    bool triggered;

    void Start()
    {
        RayPointerSourceGripState = RayPointerSource.GetComponent<Gripping>();
    }

    void Update()
    {

        if (RayPointerSourceGripState.preTrig)
        {
            RaycastHit hit;
            Ray ray = new Ray(RayPointerSource.transform.position, RayPointerSource.transform.forward);
            Physics.Raycast(ray, out hit);






            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, RayPointerSource.transform.position);
            if (hit.point != new Vector3(0, 0, 0))
            {
                lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                GameObject tempobj = new GameObject("Temp Obj");
                tempobj.transform.rotation = RayPointerSource.transform.rotation;
                tempobj.transform.position = RayPointerSource.transform.position;
                tempobj.transform.SetParent(RayPointerSource.transform);
                tempobj.transform.localPosition += new Vector3(0, 0, 100);
                lineRenderer.SetPosition(1, tempobj.transform.position);
                Destroy(tempobj);
            }


            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = cam.WorldToScreenPoint(hit.point);

            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);

            if (!RayPointerSourceGripState.trig)
            {
                ScanHit(results);
                if (triggered)
                    triggered = false;
            }

            if (RayPointerSourceGripState.trig && !triggered)
            {
                triggered = true;
                TriggerHit(results);
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }



    }

    public void ScanHit(List<RaycastResult> results)
    {
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.TryGetComponent(out Button a))
            {
                m_EventSystem.SetSelectedGameObject(null);
                m_EventSystem.SetSelectedGameObject(a.gameObject);
            }

        }
    }

    public void TriggerHit(List<RaycastResult> results)
    {
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.TryGetComponent(out Button a))
            {
                ExecuteEvents.Execute(result.gameObject, m_PointerEventData, ExecuteEvents.submitHandler);
            }

        }
    }
}
