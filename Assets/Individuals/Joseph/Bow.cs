using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    public GameObject LP { get; set; }

    public GameObject NockedArrow { get; set; }

    private bool BowFired { get; set; } = false;
    private int Redraw = 0;

    // Start is called before the first frame update
    void Start()
    {
        LP = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (BowFired)
        {
            if (Redraw >= 50)
            {
                BowFired = false;
                Redraw = 0;
            }
            Redraw++;
        }

        if(NockedArrow != null)
        {
            //NockedArrow.transform.SetPositionAndRotation(LP.transform.position, LP.transform.rotation);
            //NockedArrow.transform.position = LP.transform.position;
            //NockedArrow.transform.rotation = LP.transform.rotation;
            
        }
    }

    /// <summary>
    /// Pull the bow back - include arrow
    /// </summary>
    public void Draw(GameObject a)
    {
        if (!BowFired)
        {
            if (NockedArrow == null)
            {
                NockedArrow = (GameObject)Instantiate(a, LP.transform.position, LP.transform.rotation);

            } 
        }

    }

    /// <summary>
    /// Release the arrow
    /// </summary>
    public void Fire(float str)
    {
        //print("Fire!!");

        if (!BowFired && NockedArrow != null)
        {
            Vector3 end = LP.transform.forward * 10000;

            //Debug.DrawRay(LP.transform.position, end, Color.red, 2, true);

            NockedArrow.GetComponent<Arrow>().Fire(str);
            NockedArrow = null;
            BowFired = true; 
        }

        //print(LP.transform.position.x + " " +
        //    LP.transform.position.y + " " +
        //    LP.transform.position.z);

        //print(end.x + " " +
        //        end.y + " " +
        //        end.z);

    }
}
