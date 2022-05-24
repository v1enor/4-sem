using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Free_rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        transform.RotateAround(new Vector3(2, 15, 5), 0.05f);
    }
}
