using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenuHolder;
    public GameObject CrewCreationMenuGameObject;

    private CrewCreationMenu crewCreationMenu;
    public void StartGame()
    {
        MainMenuHolder.SetActive(false);
        crewCreationMenu.ShowMenu();
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

    private void Start()
    {
        crewCreationMenu = CrewCreationMenuGameObject.GetComponent<CrewCreationMenu>();
    }
}
