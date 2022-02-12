using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrewMemberSpot : MonoBehaviour, IPointerClickHandler
{
    public CrewCreationMenu crewCreationMenu;
    public SelectedCrewMember crewMemberId;
    public void OnPointerClick(PointerEventData eventData)
    {
        crewCreationMenu.SetSelectedCrewMember(crewMemberId);
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
