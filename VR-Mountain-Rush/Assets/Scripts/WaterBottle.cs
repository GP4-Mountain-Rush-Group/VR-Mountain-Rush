using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottle : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    bool isDrink = false;
    public AudioClip drink;
    AudioSource audioSource;
    public static GameObject cover;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cover = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (top.transform.position.y - bottom.transform.position.y < 0)
        {
            WaterController.addWater(Time.deltaTime * 10);
            cover.SetActive(false);
            isDrink = true;
        }
        else 
        {
            isDrink = false;
            cover.SetActive(true);
        }
            

        if (isDrink && !audioSource.isPlaying)
            audioSource.PlayOneShot(drink, 0.7F);
    }
}
