using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
    public GameObject ReturnPanel;
    public Text LvlPointsText;

    public void OpenPanel()
    {
        if(ReturnPanel != null)
        {
            ReturnPanel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        if(ReturnPanel != null)
        {
            ReturnPanel.SetActive(false);
        }
    }

    public void UpdatePoints()
    {
        //PointsText.GPoints = PointsText.GPoints + int.Parse(LvlPointsText.text);
    }
}
