using Assets.Scripts;
using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewCreationMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CrewCreationMenuObject;
    public GameObject CrewLineupMenuGameObject;

    private ICrewMember CrewMember1;
    private ICrewMember CrewMember2;
    private ICrewMember CrewMember3;

    private CrewLineupMenu CrewLineupMenu;
    /// <summary>
    /// Goes back to the main menu.
    /// </summary>
    public void BackToMainMenu()
    {
        MainMenu.SetActive(true);
        CrewCreationMenuObject.SetActive(false);
    }

    /// <summary>
    /// Rerolls the selected crew member.
    /// </summary>
    public void RerollSelectedMember()
    {

    }

    /// <summary>
    /// Starts the game with the selected crew.
    /// </summary>
    public void StartGame()
    {

    }

    private void Start()
    {
        CrewMember1 = Factory.Instance.CreateRandomCrewMember();
        CrewMember2 = Factory.Instance.CreateRandomCrewMember();
        CrewMember3 = Factory.Instance.CreateRandomCrewMember();

        CrewLineupMenu = CrewLineupMenuGameObject.GetComponent<CrewLineupMenu>();

        CrewLineupMenu.SetCMPortrait1(CrewMember1.Skin.GetPortrait());
        CrewLineupMenu.SetCMPortrait2(CrewMember2.Skin.GetPortrait());
        CrewLineupMenu.SetCMPortrait3(CrewMember3.Skin.GetPortrait());
    }
}
