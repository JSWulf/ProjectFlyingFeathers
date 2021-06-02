using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    private GameObject LP;

    public GameObject arrow;

    private bool BowFired = false;

    // Start is called before the first frame update
    void Start()
    {
        LP = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(arrow != null)
        {
            //arrow.transform.position = LP.transform.position;
            //arrow.transform.rotation = LP.transform.rotation;
            //arrow.transform.SetPositionAndRotation(LP.transform.position, LP.transform.rotation);
            //arrow.transform.SetPositionAndRotation(LP.transform.position, LP.transform.rotation);


            //arrow.transform.Translate(LP.transform.position);
            arrow.GetComponent<Arrow>().Move(LP.transform.position);
            print(LP.transform.position);
        }
    }

    /// <summary>
    /// Pull the bow back - include arrow
    /// </summary>
    public void Draw(GameObject a)
    {
        if (arrow == null)
        {
            arrow = a;
            Instantiate(arrow, LP.transform.position, LP.transform.rotation);
        }

    }

    /// <summary>
    /// Release the arrow
    /// </summary>
    public void Fire()
    {
        print("Fire!!");

        Vector3 end = LP.transform.forward * 10000 ;

        Debug.DrawRay(LP.transform.position, end, Color.red, 2, true);

        arrow = null;

        //print(LP.transform.position.x + " " +
        //    LP.transform.position.y + " " +
        //    LP.transform.position.z);

        //print(end.x + " " +
        //        end.y + " " +
        //        end.z);

    }
}
