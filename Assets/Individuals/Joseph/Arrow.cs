using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider BC;

    private bool Fired = false;
    private float FireStr = 0;
    private bool StartTimer = false;
    private float Timer = 0f;
    private float AirTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.detectCollisions = false;
        rb.useGravity = false;
        BC = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Fired)
        {
            //movement using transform
            //gameObject.transform.Translate(Vector3.forward * FireStr * Time.deltaTime);
            AirTime += Time.deltaTime;

            if (AirTime > 0.01)
            {
                rb.detectCollisions = true;
                
            }
            if (AirTime > FireStr/1000)
            {
                rb.useGravity = true;
            }


            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }

        if (StartTimer)
        {
            Timer += Time.deltaTime;
            if (Timer > 60)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Fire(float str)
    {

        
        FireStr = str;
        Fired = true;
        rb.velocity = gameObject.transform.forward*str;

        var c = Mathf.Clamp(str / 30, 0.7f, 1.5f);
        print(str + " " + c + " " + c/4.5f);
        BC.size = new Vector3(BC.size.x, BC.size.y, c);
        BC.center = new Vector3(BC.center.x, BC.center.y, c/4.5f);
        //rb.detectCollisions = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("hit");
        Fired = false;
        rb.velocity = new Vector3(0,0,0);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag != "Arrow" &&
            other.collider.tag != "Rock")
        {
            //print("hit2");
            
            //rb.velocity = new Vector3(0, 0, 0);
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.detectCollisions = false;
            Fired = false;

        }
        if (other.collider.tag != "Target" &&
            other.collider.tag != "Terrain")
        {
            StartTimer = true;
        }
    }
    
}
