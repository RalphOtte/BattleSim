using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    //General
    public int armyStartSize;
    public int armySize;
    public int totalArmyStrenght;
    public int money;

    //Units
    public int peasantCount;
    public int footmanCount;
    public int bowmanCount;
    public int knightCount;
    public int lancerCount;

    //Buildings
    //ResearchTexts
    public string palaceLevelText;
    public string barracksLevelText;
    public string academyLevelText;
    public string wallLevelText;
    public string palaceUpgradeCostText;
    public string barracksUpgradeCostText;
    public string academyUpgradeCostText;
    public string wallUpgradeCostText;
    //Palace
    public int palaceLevel;
    public int palaceMaxLevel;
    public int palaceCurrentIncome;
    public int[] palaceUpgradeCost;
    public int[] palaceIncome;
    //Barracks
    public int barracksLevel;
    public int barracksMaxLevel;
    public int[] barracksUpgradeCost;
    //Academy
    public int academyLevel;
    public int academyMaxLevel;
    public int[] academyUpgradeCost;
    //Wall
    public int wallLevel;
    public int wallMaxLevel;
    public int wallCurrentBonus;
    public int[] wallUpgradeCost;
    public int[] wallBonus;

    //Unlocks
    //Units
    public bool footmanUnlocked;
    public bool bowmanUnlocked;
    public bool knightUnlocked;
    public bool lancerUnlocked;
    //Buildings
    public bool wallUnlocked;

    void Start()
    {
        palaceLevel = 1;
        barracksLevel = 1;
        academyLevel = 1;
        wallLevel = 1;
        peasantCount = 10;
        UpdatePalaceIncome();
    }

    public void UpdateArmySize()
    {
        armySize = peasantCount + footmanCount + bowmanCount + knightCount + lancerCount;
    }

    public void UpdateResearchIntToString()
    {
        //Converts all building levels to strings for use in other elements
        palaceLevelText = palaceLevel.ToString();
        barracksLevelText = barracksLevel.ToString();
        academyLevelText = academyLevel.ToString();
        wallLevelText = wallLevel.ToString();

        palaceUpgradeCostText = palaceUpgradeCost.ToString();
        barracksUpgradeCostText = barracksUpgradeCost.ToString();
        academyUpgradeCostText = academyUpgradeCost.ToString();
        wallUpgradeCostText = wallUpgradeCost.ToString();
    }

    public void UpdatePalaceIncome()
    {
        if (palaceLevel == 1)
        {
            palaceCurrentIncome = palaceIncome[0];
        }
        else if (palaceLevel == 2)
        {
            palaceCurrentIncome = palaceIncome[1];
        }
        else if (palaceLevel == 3)
        {
            palaceCurrentIncome = palaceIncome[2];
        }
        else if (palaceLevel == 4)
        {
            palaceCurrentIncome = palaceIncome[3];
        }
        else if (palaceLevel == 5)
        {
            palaceCurrentIncome = palaceIncome[4];
        }
    }

    public void UpdateWallBonus()
    {
        if (wallLevel == 1)
        {
            wallCurrentBonus = wallBonus[0];
        }
        else if (wallLevel == 2)
        {
            wallCurrentBonus = wallBonus[1];
        }
        else if (wallLevel == 3)
        {
            wallCurrentBonus = wallBonus[2];
        }
        else if (wallLevel == 4)
        {
            wallCurrentBonus = wallBonus[2];
        }
    }

}
