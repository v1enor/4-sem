using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_on : MonoBehaviour
{
    // Start is called before the first frame update
    public Light lightPoint;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Tank")
        { 
            lightPoint.intensity = 5;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Tank")
        {
            lightPoint.intensity = 0;
        }
    }
}
