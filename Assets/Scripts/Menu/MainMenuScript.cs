using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenuHolder;
    public GameObject CrewCreationMenu;
    public void StartGame()
    {
        MainMenuHolder.SetActive(false);
        CrewCreationMenu.SetActive(true);
    }

    public void LoadGame()
    {

    }

    public void Options()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
