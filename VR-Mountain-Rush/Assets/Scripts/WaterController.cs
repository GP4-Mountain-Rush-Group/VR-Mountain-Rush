using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaterController : MonoBehaviour
{
    [SerializeField] GameObject waterFeild;
    [SerializeField] private static float water;
    [SerializeField] private float maxWater = 50f;
    [SerializeField] private float currentwater;
    [SerializeField] private static float waterSpeed;
    [SerializeField] private float wTime;
    public GameObject deadMenu;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = waterFeild.GetComponent<Image>().color;
        water = 30f;
        waterSpeed = 1;
        color.a = 0f;
        waterFeild.GetComponent<Image>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (water > maxWater)
            water = maxWater;
        currentwater = water;
        UpdateWater(waterSpeed);
        TipToDrink();
    }

    public static void setWaterSpeed(float x)
    {
        waterSpeed = x;
        //Debug.Log(x);
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
            if (SceneManager.GetActiveScene().name != "level 0")
            {
                deadMenu.SetActive(true);
            }
        }
    }

    private void TipToDrink()
    {           
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
