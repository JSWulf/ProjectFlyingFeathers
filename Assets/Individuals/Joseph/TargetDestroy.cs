using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TargetDestroy : MonoBehaviour
{

    //hit count and destroy for JSWLEVEL
    /// <summary>
    /// Set to 0 for no destroy
    /// </summary>
    public int MaxHit=5;
    private int Hits = 0;

    public List<GameObject> Arrows { get; private set; } = new List<GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ArrowHit(TargetBehavior col, GameObject a)
    {
        if (MaxHit > 0)
        {
            Arrows.Add(a);

            a.transform.parent = transform;

            Hits++;
            if (Hits >= MaxHit)
            {
                
                Destroy(gameObject);

                foreach (var ar in Arrows)
                {
                    Destroy(ar);
                }
            }
        }
    }


}
