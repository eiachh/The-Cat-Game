using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrewLineupMenu : MonoBehaviour
{
    public Image CrewMemberPortrait1;
    public Image CrewMemberPortrait2;
    public Image CrewMemberPortrait3;

    public void SetCMPortrait1(Sprite sprite)
    {
        CrewMemberPortrait1.sprite = sprite;
    }

    public void SetCMPortrait2(Sprite sprite)
    {
        CrewMemberPortrait2.sprite = sprite;
    }

    public void SetCMPortrait3(Sprite sprite)
    {
        CrewMemberPortrait3.sprite = sprite;
    }
}
