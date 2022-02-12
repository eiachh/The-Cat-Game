using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrewLineupMenu : MonoBehaviour
{
    public GameObject CrewMemberObject1;
    public GameObject CrewMemberObject2;
    public GameObject CrewMemberObject3;

    private CrewMemberSpot crewMemberSpot1;
    private CrewMemberSpot crewMemberSpot2;
    private CrewMemberSpot crewMemberSpot3;
    private Image crewMemberPortrait1;
    private Image crewMemberPortrait2;
    private Image crewMemberPortrait3;

    private bool Initialized;
    private SelectedCrewMember selectedCrewMember;
    public void SetCorrespondingPortrait(Sprite sprite, SelectedCrewMember selected)
    {
        selectedCrewMember = selected;
        var portrait = GetSelectedPortrait();
        if (portrait == null)
            Init();

        portrait = GetSelectedPortrait();
        portrait.sprite = sprite;
    }

    public void DeselectMemberSpots()
    {
        crewMemberSpot1.Deselect();
        crewMemberSpot2.Deselect();
        crewMemberSpot3.Deselect();
    }
    private void Init()
    {
        if (Initialized)
            return;

        Initialized = true;

        crewMemberSpot1 = CrewMemberObject1.GetComponent<CrewMemberSpot>();
        crewMemberPortrait1 = CrewMemberObject1.GetComponent<Image>();
        crewMemberSpot1.crewMemberId = SelectedCrewMember.CrewMember1;


        crewMemberSpot2 = CrewMemberObject2.GetComponent<CrewMemberSpot>();
        crewMemberPortrait2 = CrewMemberObject2.GetComponent<Image>();
        crewMemberSpot2.crewMemberId = SelectedCrewMember.CrewMember2;

        crewMemberSpot3 = CrewMemberObject3.GetComponent<CrewMemberSpot>();
        crewMemberPortrait3 = CrewMemberObject3.GetComponent<Image>();
        crewMemberSpot3.crewMemberId = SelectedCrewMember.CrewMember3;
    }
    private void Start()
    {
        Init();
    }

    private Image GetSelectedPortrait() =>
        selectedCrewMember switch
        {
            SelectedCrewMember.CrewMember1 => crewMemberPortrait1,
            SelectedCrewMember.CrewMember2 => crewMemberPortrait2,
            SelectedCrewMember.CrewMember3 => crewMemberPortrait3,
            _ => crewMemberPortrait1,
        };
}
