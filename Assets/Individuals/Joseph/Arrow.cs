using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private bool Fired = false;
    private float FireStr = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Fired)
        {
            gameObject.transform.Translate(Vector3.forward * FireStr * Time.deltaTime);
        }
    }

    public void Fire(float str)
    {
        FireStr = str;
        Fired = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Fired = false;
    }
}
