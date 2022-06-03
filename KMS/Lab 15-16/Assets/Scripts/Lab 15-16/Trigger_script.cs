using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_script : MonoBehaviour
{

    public GameObject wall;
    public float RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Tank")
        {
            wall.transform.Rotate(RotationSpeed,0, 0);
        }
    }

}
