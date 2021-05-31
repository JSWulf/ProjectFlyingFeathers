using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    private GameObject LP;

    // Start is called before the first frame update
    void Start()
    {
        LP = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Pull the bow back
    /// </summary>
    public void Draw()
    {

    }

    /// <summary>
    /// Release the arrow
    /// </summary>
    public void Fire()
    {
        print("Fire!!");

        Vector3 end = LP.transform.up * 10000 ;

        Debug.DrawRay(LP.transform.position, end, Color.red, 2, true);

        //print(LP.transform.position.x + " " +
        //    LP.transform.position.y + " " +
        //    LP.transform.position.z);

        //print(end.x + " " +
        //        end.y + " " +
        //        end.z);

    }
}
