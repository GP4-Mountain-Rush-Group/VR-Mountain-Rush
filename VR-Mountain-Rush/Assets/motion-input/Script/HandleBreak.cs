using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBreak : MonoBehaviour
{
    public Grippable handleLeft;
    public Grippable handleRight;
    public bool breakBicycle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (handleLeft.IsTriggered || handleRight.IsTriggered)
            breakBicycle = true;
        else
            breakBicycle = false;
    }
}
