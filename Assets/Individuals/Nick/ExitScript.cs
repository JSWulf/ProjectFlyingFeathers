using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
    public GameObject ReturnPanel;

    public void OpenReturnPanel()
    {
        if(ReturnPanel != null)
        {
            ReturnPanel.SetActive(true);
        }
    }

    public void CloseReturnPanel()
    {
        if(ReturnPanel != null)
        {
            ReturnPanel.SetActive(false);
        }
    }
}
