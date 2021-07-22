using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    //Main menu panels
    public GameObject MainMenu_Panel;
    public GameObject BowBrowser_Panel;
    public GameObject Settings_Panel;
    public GameObject QuitConfirmation_Panel;
    public static int Points;


    void Start()
    {
        //Set points display
        if (Points != null)
        {

        }

    }

    public void LoadGame()
    {
        //Load game scene
        SceneManager.LoadScene("LoadGameScene");
    }

    public void NewGame()
    {
        //New game scene
        SceneManager.LoadScene("Level_Select");
    }

    public void ToggleBowBrowser()
    {
        //Enable or disable Bow Browser Scene
       
        if (BowBrowser_Panel.activeInHierarchy)
        {
            MainMenu_Panel.SetActive(true);
            BowBrowser_Panel.SetActive(false);
        }
        else
        {
            MainMenu_Panel.SetActive(false);
            BowBrowser_Panel.SetActive(true);
        }
    }

    public void ToggleSettings()
    {
        //Enable or disable settings menu
        if (Settings_Panel.activeInHierarchy)
        {
            MainMenu_Panel.SetActive(true);
            Settings_Panel.SetActive(false);
        }
        else
        {
            MainMenu_Panel.SetActive(false);
            Settings_Panel.SetActive(true);
        }
    }

    public void ToggleQuitConfirmation()
    {
        //Enable or disable quit confirmation menu
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
