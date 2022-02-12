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

    public void SetCMPortrait1(Sprite sprite)
    {
        crewMemberPortrait1.sprite = sprite;
    }

    public void SetCMPortrait2(Sprite sprite)
    {
        crewMemberPortrait2.sprite = sprite;
    }

    public void SetCMPortrait3(Sprite sprite)
    {
        crewMemberPortrait3.sprite = sprite;
    }

    private void Start()
    {
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
}
