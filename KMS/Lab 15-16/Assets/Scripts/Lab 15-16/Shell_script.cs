using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_script : MonoBehaviour
{
   
    public float speedShell;
    public GameObject explosion1;
    public AudioSource src;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward * speedShell);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "goal")
        {
            Instantiate(explosion1, gameObject.transform);
            GetComponent<Renderer>().enabled = false;
            col.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);


            var audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
