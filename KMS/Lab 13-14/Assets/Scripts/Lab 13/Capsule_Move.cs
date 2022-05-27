using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule_Move : MonoBehaviour
{
    // Start is called before the first frame update

    float speed = 0.03f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Cube")
        {
            col.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 0);
        }
        if (col.gameObject.name == "Cube (1)")
        {
            col.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1);
        }
    }
}
