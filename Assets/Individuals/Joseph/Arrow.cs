using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider BC;
    private CapsuleCollider CC;
    private Camera Cam;

    private bool Fired = false;
    private float FireStr = 0;
    private bool StartTimer = false;
    private float Timer = 0f;
    public float AirTime { get; private set; } = 0f;

    private bool Grav = false;

    private TrailRenderer Trail;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.detectCollisions = false;
        rb.useGravity = false;
        BC = GetComponent<BoxCollider>();
        CC = GetComponent<CapsuleCollider>();
        Cam = Camera.main;

        CC.enabled = false;

        Trail = GetComponentInChildren<TrailRenderer>();
        //Trail.enabled = false;
        //Trail.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Fired)
        {
            //movement using transform
            //gameObject.transform.Translate(Vector3.forward * FireStr * Time.deltaTime);
            AirTime += Time.deltaTime;

            //if (AirTime > 0.01)
            //{
            //    rb.detectCollisions = true;

            //}

            var dis = Vector3.Distance(Cam.transform.position, transform.position);
            print(dis);
            if (dis > 30)
            {
                Trail.endWidth = dis * 0.005f;
            }
            
            if (AirTime > FireStr/500 && !Grav)
            {
                //print(AirTime + " " + FireStr / 500);
                rb.useGravity = true;
                Grav = true;
            }

            if (AirTime > 100)
            {
                Destroy(gameObject);
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

    public float GetAirTime()
    {
        return AirTime;
    }

    public void Fire(float str)
    {
        //high speed collider
        if (str > 20f)
        {
            CC.enabled = true;
        }

        //Trail.enabled = true;
        //Trail.emitting = true;
        FireStr = str;
        Fired = true;
        rb.velocity = gameObject.transform.forward*str;

        var c = Mathf.Clamp(str / 30, 0.7f, 1.5f);
        //print(str + " " + c + " " + c/4.5f);
        //BC.size = new Vector3(BC.size.x, BC.size.y, c);
        //BC.center = new Vector3(BC.center.x, BC.center.y, c/4.5f);
        //rb.detectCollisions = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("hit");
        //Fired = false;
        rb.velocity = gameObject.transform.forward*10;
        CC.enabled = false;
        rb.useGravity = false;

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Target")
        {
            var t = Convert.ToInt32(AirTime * 100);
            TargetBehavior.pts = Convert.ToInt32(t);
            //TargetBehavior.pointsToAdd.AddPoints(t);
        }

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
