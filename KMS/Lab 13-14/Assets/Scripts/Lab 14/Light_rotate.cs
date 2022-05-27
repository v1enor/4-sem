using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public Light Spot;
    public float SpedLightRotate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.name == "player") Spot.transform.Rotate(0, SpedLightRotate, 0);
    }


}
