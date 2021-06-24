using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public bool moving = false;
    public Points pointsToAdd;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        points += 100;

        

        return points;
    }

    
}
