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
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (top.transform.position.y - bottom.transform.position.y < 0)
        {
            WaterController.addWater(Time.deltaTime * 10);
            isDrink = true;
        }
        else
            isDrink = false;

        if (isDrink && !audioSource.isPlaying)
            audioSource.PlayOneShot(drink, 0.7F);
    }
}
