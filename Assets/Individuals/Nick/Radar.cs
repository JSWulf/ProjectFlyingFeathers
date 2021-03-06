using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Used from tutorial at https://www.youtube.com/watch?v=LP2XHHeQuvg&t=156s by Holistic3d

public class RadarObject
{
    public Image icon { get; set; }
    public GameObject owner { get; set; }
}

public class Radar : MonoBehaviour   
{
    private int rTargets;
    private int tTargets;
    public TextMeshProUGUI RemainingTargetsText;

    public Transform playerPos;
    float mapScale = 2.0f;
    private bool parentSet;

    public GameObject LevelEndPanel;

    public static List<RadarObject> radarObjects = new List<RadarObject>();

    public static void RegisterRadarObject(GameObject o, Image i)
    {
        Image image = Instantiate(i);
        radarObjects.Add(new RadarObject() { owner = o, icon = image });
    }

    public static void RemoveRadarObject(GameObject o)
    {
        List<RadarObject> newList = new List<RadarObject>();
        for (int i=0; i < radarObjects.Count; i++)
        {
            if (radarObjects[i].owner == o)
            {
                DestroyImmediate(radarObjects[i].icon, true);
                continue;
            }
            else
                newList.Add(radarObjects[i]);
        }

        radarObjects.RemoveRange(0, radarObjects.Count);
        radarObjects.AddRange(newList);
    }

    void DrawRadarIcons()
    {
        foreach (RadarObject ro in radarObjects)
        {
            Vector3 radarPos = (ro.owner.transform.position - playerPos.position);
            float distToObject = Vector3.Distance(playerPos.position, ro.owner.transform.position) * mapScale;
            float deltaY = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - playerPos.eulerAngles.y;
            radarPos.x = distToObject * Mathf.Cos(deltaY * Mathf.Deg2Rad) * -1;
            radarPos.z = distToObject * Mathf.Sin(deltaY * Mathf.Deg2Rad);

            if (!parentSet)
            {   
                ro.icon.transform.SetParent(this.transform);
            }
            
            ro.icon.transform.position = new Vector3(radarPos.x/2, radarPos.z/2, 0) + this.transform.position;
        }

        //after the first run, no longer set parent for each radar transform
        if (!parentSet)
        {
            tTargets = radarObjects.Count;
            parentSet = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rTargets = radarObjects.Count;
        RemainingTargetsText.SetText(rTargets + "/" + tTargets + " Targets");
        DrawRadarIcons();

        if (rTargets == 0)
        {
            if (LevelEndPanel != null)
            {
                LevelEndPanel.SetActive(true);
            }
        }
    }
}
