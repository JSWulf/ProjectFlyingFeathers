using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class LevelSelector : MonoBehaviour
{
    public GameObject levelHolder;
    public GameObject levelIcon1;
    public GameObject levelIcon2;
    public GameObject levelIcon3;
    public GameObject levelIcon4;
    public GameObject levelIcon5;
    public GameObject levelIcon6;
    public GameObject thisCanvas;
    public int numberOfLevels = 6;
    public Vector2 iconSpacing;
    private Rect panelDimensions;
    private Rect iconDimensions;
    private int amountPerPage;
    private int currentLevelCount;

    // Start is called before the first frame update
    void Start()
    {
        panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
        iconDimensions = levelIcon1.GetComponent<RectTransform>().rect;
        int maxInARow = Mathf.FloorToInt((panelDimensions.width + iconSpacing.x) / (iconDimensions.width + iconSpacing.x));
        int maxInACol = Mathf.FloorToInt((panelDimensions.height + iconSpacing.y) / (iconDimensions.height + iconSpacing.y));
        //amountPerPage = maxInARow * maxInACol;
        //int totalPages = Mathf.CeilToInt((float)numberOfLevels / amountPerPage);
        LoadPanels(2);
    }
    void LoadPanels(int numberOfPanels)
    {
        GameObject panelClone = Instantiate(levelHolder) as GameObject;
        PageSwiper swiper = levelHolder.AddComponent<PageSwiper>();
        swiper.totalPages = numberOfPanels;

        for (int i = 1; i <= numberOfPanels; i++)
        {
            GameObject panel = Instantiate(panelClone) as GameObject;
            panel.transform.SetParent(thisCanvas.transform, false);
            panel.transform.SetParent(levelHolder.transform);
            panel.name = "Page-" + (i+1);
            panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i - 1), 0);
            SetUpGrid(panel);
            //int numberOfIcons = i == numberOfPanels ? numberOfLevels - currentLevelCount : amountPerPage;
            LoadIcons(3, panel);
        }
        Destroy(panelClone);
    }
    void SetUpGrid(GameObject panel)
    {
        GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(iconDimensions.width, iconDimensions.height);
        grid.childAlignment = TextAnchor.MiddleCenter;
        grid.spacing = iconSpacing;
    }
    void LoadIcons(int numberOfIcons, GameObject parentObject)
    {
        GameObject[] levelIcons = new GameObject[numberOfLevels];
        for (int i = 0; i <= numberOfIcons; i++)
        {
            switch (i)
            {
                case 0:
                    levelIcons[i] = levelIcon1;
                    break;
                case 1:
                    levelIcons[i] = levelIcon2;
                    break;
                case 2:
                    levelIcons[i] = levelIcon3;
                    break;
                case 3:
                    levelIcons[i] = levelIcon4;
                    break;
                case 4:
                    levelIcons[i] = levelIcon5;
                    break;
                case 5:
                    levelIcons[i] = levelIcon6;
                    break;
                default:
                    levelIcons[i] = levelIcon1;
                    break;
            }
        }

        for (int i = 1; i <= numberOfIcons; i++)
        {
            currentLevelCount++;
            GameObject icon = Instantiate(levelIcons[i]) as GameObject;
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.transform.SetParent(parentObject.transform);
            icon.name = "Level " + i;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}