using Assets.Scripts;
using Assets.Scripts.Characters;
using Assets.Scripts.Map;
using Assets.Scripts.Providers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public CharacterConfigurationDisplayer charConfigurationDisplayer;

    public Sprite NotSelectedIndicator;
    public Sprite SelectedIndicator;

    private ICrewMember CrewMember1;
    private ICrewMember CrewMember2;
    private ICrewMember CrewMember3;

    private SelectedCrewMember selectedCrewMember = SelectedCrewMember.CrewMember1;

    private CrewLineupMenu crewLineupMenu;

    private string sceneNameToLoad = "SampleScene";

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
        var selectedMember = GetSelectedMember();
        selectedMember.Dispose();
        selectedMember = Factory.Instance.CreateRandomCrewMember();
        crewLineupMenu.SetCorrespondingPortrait(CrewMember1.Skin.GetPortrait(),selectedCrewMember);
    }

    /// <summary>
    /// Starts the game with the selected crew.
    /// </summary>
    public void StartGame()
    {
        //GameObject crewGameObject = new GameObject("CrewGameObject");
        //CrewMember1.
        var crew = Factory.Instance.CreateCrew(new[] { CrewMember1, CrewMember2, CrewMember3 });
        //MapLoadManager loadManager = new MapLoadManager(crew, sceneNameToLoad);
        SceneManager.LoadScene(sceneNameToLoad, LoadSceneMode.Single);
    }

    public void SetSelectedCrewMember(SelectedCrewMember to)
    {
        selectedCrewMember = to;
        charConfigurationDisplayer.DisplayCharacterConfiguration(GetSelectedMember().CharacterConfiguration);
    }

    /// <summary>
    /// Deselects all the crewmembers from the <see cref="crewLineupMenu"/>
    /// </summary>
    public void DeselectMemberSpots()
    {
        crewLineupMenu.DeselectMemberSpots();
    }

    public void ShowMenu()
    {
        CrewCreationMenuObject.SetActive(true);
        FillMenu();
    }

    private void FillMenu()
    {
        CrewMember1 = Factory.Instance.CreateRandomCrewMember();
        CrewMember2 = Factory.Instance.CreateRandomCrewMember();
        CrewMember3 = Factory.Instance.CreateRandomCrewMember();

        crewLineupMenu = CrewLineupMenuGameObject.GetComponent<CrewLineupMenu>();

        crewLineupMenu.SetCorrespondingPortrait(CrewMember1.Skin.GetPortrait(), SelectedCrewMember.CrewMember1);
        crewLineupMenu.SetCorrespondingPortrait(CrewMember2.Skin.GetPortrait(), SelectedCrewMember.CrewMember2);
        crewLineupMenu.SetCorrespondingPortrait(CrewMember3.Skin.GetPortrait(), SelectedCrewMember.CrewMember3);
    }

    private ICrewMember GetSelectedMember() =>
        selectedCrewMember switch
        {
            SelectedCrewMember.CrewMember1 => CrewMember1,
            SelectedCrewMember.CrewMember2 => CrewMember2,
            SelectedCrewMember.CrewMember3 => CrewMember3,
            _ => CrewMember1,
        };
}
