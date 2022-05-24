using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eulerAngles_2_same : MonoBehaviour
{

    private Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        v += new Vector3(0.2f, 0, 0.4f);
        transform.eulerAngles = v;
    }
}
