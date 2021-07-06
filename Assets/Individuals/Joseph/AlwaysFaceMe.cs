using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFaceMe : MonoBehaviour
{

    private Camera Cam;
    public bool UseTargetBehaviorInstead;

    // Start is called before the first frame update
    void Start()
    {
        ////Cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        //var cR = Cam.transform;

        ////gameObject.transform.rotation.SetEulerAngles(cR.x, cR.y, cR.z);
        ////gameObject.transform.rotation.SetLookRotation(cR);
        //gameObject.transform.LookAt(cR);
    }
}
