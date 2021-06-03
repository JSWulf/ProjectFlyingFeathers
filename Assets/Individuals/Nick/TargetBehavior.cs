using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public bool moving;
    public Points pointsToAdd;

    void OnCollisionEnter(Collision col)
    {
        //When the target gets hit by an arrow
        if(col.gameObject.name == "Arrow")  //TODO Verify object name
        {
            pointsToAdd.AddPoints(CalculatePoints());
        }
    }

    //TODO Logic for point calculation
    private int CalculatePoints()
    {
        //Calculate based on position of collision on target as well as distance from character when the target is hit.
        return 100; //calculates all points as 100
    }
}
