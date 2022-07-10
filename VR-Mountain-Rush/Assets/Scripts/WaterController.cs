using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterController : MonoBehaviour
{
    [SerializeField] GameObject waterFeild;
    [SerializeField] private static float water;
    [SerializeField] private static float waterSpeed;
    [SerializeField] private float wTime;
    // Start is called before the first frame update
    void Start()
    {
        water = 20f;
        waterSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWater(waterSpeed);
        TipToDrink();
    }

    public static void setWaterSpeed(float x)
    {
        waterSpeed = x;
        Debug.Log(x);
    }

    public static void addWater(float x)
    {
        water = water + x;
    }
    private void UpdateWater(float x)
    {
        if (water > 0)
        {
            water -= Time.deltaTime * x;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    private void TipToDrink()
    {
        var color = waterFeild.GetComponent<Image>().color;
        
        if (water > 0 && water < 15)
        {
            wTime += Time.deltaTime;
            if (wTime < 1 && wTime > 0.5)
            {
                color.a = 0.2f;
                waterFeild.GetComponent<Image>().color = color;
            }
            else if (wTime > 1)
            {
                color.a = 0.0f;
                waterFeild.GetComponent<Image>().color = color;
                wTime = 0;
            }
        }
        else if (water > 15)
        {
            color.a -= 0.01f;
            waterFeild.GetComponent<Image>().color = color;
        }
        else
        {
            color.a = 0.0f;
            waterFeild.GetComponent<Image>().color = color;
        }
    }
}
