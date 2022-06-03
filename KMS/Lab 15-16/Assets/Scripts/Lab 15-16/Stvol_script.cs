using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stvol_script : MonoBehaviour
{

    public GameObject core;
    public AudioSource shot_audio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Vector3 forwardofstvol = transform.position +
            transform.TransformDirection(0f, 0f, 30f);


            //= Quaternion.Euler(new Vector3(0, 10,       qrr0))
            GameObject newcore = Instantiate(core, forwardofstvol, transform.rotation);
            shot_audio.Play();
        }

    }

   
}

