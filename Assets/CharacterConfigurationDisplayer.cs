using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Assets.Scripts.Characters.Info;

public class CharacterConfigurationDisplayer : MonoBehaviour
{
    public TextMeshProUGUI NameDisplayer;

    public TextMeshProUGUI HarvestDisplayer;
    public TextMeshProUGUI PlantingDisplayer;
    public TextMeshProUGUI BuildingDisplayer;
    public TextMeshProUGUI MiningDisplayer;
    public TextMeshProUGUI CraftingDisplayer;
    public TextMeshProUGUI HandlingDisplayer;
    public TextMeshProUGUI TradingDisplayer;

    public void DisplayCharacterConfiguration(CharacterConfiguration charConfig)
    {
        NameDisplayer.text = charConfig.Name;

        if (HarvestDisplayer != null)
            HarvestDisplayer.text = charConfig.Skills.Harvest.ToString();

        if (PlantingDisplayer != null)
            PlantingDisplayer.text = charConfig.Skills.Planting.ToString();

        if (BuildingDisplayer != null)
            BuildingDisplayer.text = charConfig.Skills.Building.ToString();

        if (MiningDisplayer != null)
            MiningDisplayer.text = charConfig.Skills.Mining.ToString();

        if (CraftingDisplayer != null)
            CraftingDisplayer.text = charConfig.Skills.Crafting.ToString();

        if (HandlingDisplayer != null)
            HandlingDisplayer.text = charConfig.Skills.Handling.ToString();

        if (TradingDisplayer != null)
            TradingDisplayer.text = charConfig.Skills.Trade.ToString();
    }
}
