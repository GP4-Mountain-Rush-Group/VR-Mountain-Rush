using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlePos : MonoBehaviour
{
    public GameObject PosRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PosRef.transform.position;
        transform.rotation = PosRef.transform.rotation;
    }
}
