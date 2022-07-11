using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeColldiders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
   
        transform.GetComponent<TerrainCollider>().enabled= false;

        transform.GetComponent<TerrainCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
