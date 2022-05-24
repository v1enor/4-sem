using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qauternion_2_same : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0.2f, 0, 0.4f);
    }
}
