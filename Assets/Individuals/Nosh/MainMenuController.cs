using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenu_Panel;
    public GameObject BowBrowswer_Panel;
    public GameObject Settings_Panel;
    public GameObject QuitConfirmation_Panel;

    //added this variable to fix compiler error - jw
    public GameObject BowBrowser_Panel;


    public void LoadGame()
    {
        //Load game scene
        SceneManager.LoadScene("GameScene");
    }

    public void ToggleBowBrowswer()
    {
        //Enable or disable Bow Browser Scene
        //Enable or disable settings menu
        if (BowBrowser_Panel.activeInHierarchy)
        {
            MainMenu_Panel.SetActive(false);
            BowBrowser_Panel.SetActive(true);
        }
        else
        {
            MainMenu_Panel.SetActive(true);
            BowBrowser_Panel.SetActive(false);
        }
    }

    public void ToggleSettings()
    {
        //Enable or disable settings menu
        if (Settings_Panel.activeInHierarchy)
        {
            MainMenu_Panel.SetActive(false);
            Settings_Panel.SetActive(true);
        }
        else
        {
            MainMenu_Panel.SetActive(true);
            Settings_Panel.SetActive(false);
        }
    }

    public void ToggleQuitConfirmation()
    {
        //Enable or disable settings menu
        if (QuitConfirmation_Panel.activeInHierarchy)
        {
            QuitConfirmation_Panel.SetActive(false);
            MainMenu_Panel.SetActive(true);
        }
        else
        {
            QuitConfirmation_Panel.SetActive(true);
            MainMenu_Panel.SetActive(false);
        }
    }

    // To be called by main menu Quit_Button
    public void Quit()
    {
        //Quit the application
        Application.Quit();

    }
    
}
