using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TargetBehavior : MonoBehaviour
{
    public bool moving = false;
    public Points pointsToAdd;

    public static int pts = 0;

    public bool AlwaysFaceMe = false;
    private Camera Cam;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (AlwaysFaceMe)
        {
            var cR = Cam.transform;
            gameObject.transform.LookAt(cR);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //When the target gets hit by an arrow
        if(col.collider.gameObject.CompareTag("Arrow"))
        {
            pointsToAdd.AddPoints(CalculatePoints(col));
            transform.parent.GetComponent<TargetDestroy>().ArrowHit(this, col.gameObject);
        }
    }

    //TODO Logic for point calculation
    private int CalculatePoints(Collision col)
    {
        int points = 0;

        //Calculate based on position of collision on target as well as distance from character when the target is hit.
        Thread.Sleep(10);
        //points += 100;
        points += pts;
        PointsText.GPoints += pts;
        pts = 0;
        

        return points;
    }

    
}
