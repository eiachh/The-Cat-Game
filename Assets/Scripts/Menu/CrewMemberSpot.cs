using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CrewMemberSpot : MonoBehaviour, IPointerClickHandler
{
    public CrewCreationMenu crewCreationMenu;
    public Image SelectionImage;
    public SelectedCrewMember crewMemberId;

    public void OnPointerClick(PointerEventData eventData)
    {
        crewCreationMenu.DeselectMemberSpots();

        crewCreationMenu.SetSelectedCrewMember(crewMemberId);
        SelectionImage.sprite = crewCreationMenu.SelectedIndicator;
    }

    /// <summary>
    /// Should be called when the current member spot is deselected.
    /// </summary>
    public void Deselect()
    {
        SelectionImage.sprite = crewCreationMenu.NotSelectedIndicator;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
