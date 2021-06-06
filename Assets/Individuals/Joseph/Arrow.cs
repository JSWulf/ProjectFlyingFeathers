using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;

    private bool Fired = false;
    private float FireStr = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Fired)
        {
            //movement using transform
            //gameObject.transform.Translate(Vector3.forward * FireStr * Time.deltaTime);
            
            //movement using pysics
            //rb.velocity
        }
    }

    public void Fire(float str)
    {
        FireStr = str;
        Fired = true;
        rb.velocity = gameObject.transform.forward*str;
        //rb.AddRelativeForce(new Vector3(0, 100, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hit");
        Fired = false;
        rb.velocity = new Vector3(0,0,0);
    }

    private void OnCollisionEnter(Collision other)
    {
        print("hit2");
        Fired = false;
        rb.velocity = new Vector3(0, 0, 0);
    }
}
