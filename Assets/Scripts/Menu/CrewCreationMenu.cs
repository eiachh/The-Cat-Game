using Assets.Scripts;
using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelectedCrewMember
{
    CrewMember1,
    CrewMember2,
    CrewMember3
}
public class CrewCreationMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CrewCreationMenuObject;
    public GameObject CrewLineupMenuGameObject;

    private ICrewMember CrewMember1;
    private ICrewMember CrewMember2;
    private ICrewMember CrewMember3;

    private SelectedCrewMember selectedCrewMember = SelectedCrewMember.CrewMember1;

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
        if(selectedCrewMember == SelectedCrewMember.CrewMember1)
        {
            CrewMember1.Dispose();
            CrewMember1 = Factory.Instance.CreateRandomCrewMember();
            CrewLineupMenu.SetCMPortrait1(CrewMember1.Skin.GetPortrait());
        }
        else if (selectedCrewMember == SelectedCrewMember.CrewMember2)
        {
            CrewMember2.Dispose();
            CrewMember2 = Factory.Instance.CreateRandomCrewMember();
            CrewLineupMenu.SetCMPortrait2(CrewMember2.Skin.GetPortrait());
        }
        if (selectedCrewMember == SelectedCrewMember.CrewMember3)
        {
            CrewMember3.Dispose();
            CrewMember3 = Factory.Instance.CreateRandomCrewMember();
            CrewLineupMenu.SetCMPortrait3(CrewMember3.Skin.GetPortrait());
        }
    }

    /// <summary>
    /// Starts the game with the selected crew.
    /// </summary>
    public void StartGame()
    {

    }

    public void SetSelectedCrewMember(SelectedCrewMember to)
    {
        selectedCrewMember = to;
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
