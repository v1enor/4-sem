using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anigilation : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime = 10f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                Destruction();
            }
        }
    }

    void Destruction()
    {
        Destroy(this.gameObject);
    }
}
