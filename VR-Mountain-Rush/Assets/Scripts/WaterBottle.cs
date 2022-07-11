using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottle : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (top.transform.position.y - bottom.transform.position.y < 0)
        {
            WaterController.addWater(Time.deltaTime * 10);
        }
    }
}
