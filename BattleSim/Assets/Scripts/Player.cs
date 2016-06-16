using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour{

    //General
    public int armySize;
    public int armyPower;
    public int startMoney;
    public int money;
    public string moneyString;
    public int safePhaseTurns;
    public bool wantsSafePhase;
    public bool tooltipsEnabled;

    //Units
    public int peasantCount;
    public int footmanCount;
    public int bowmanCount;
    public int knightCount;
    public int lancerCount;

    //Unit Health
    public int peasantHealth;
    public int footmanHealth;
    public int bowmanHealth;
    public int knightHealth;
    public int lancerHealth;

    //Unit AttackPower
    public int peasantPower;
    public int footmanPower;
    public int bowmanPower;
    public int knightPower;
    public int lancerPower;

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
    public int palaceNextIncome;
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
    public int wallNextBonus;
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
    [SerializeField]
    public List<int> armyList = new List<int>();

    void Start()
    {
        palaceLevel = 1;
        barracksLevel = 1;
        academyLevel = 1;
        peasantCount = 10;
        money += startMoney;
        tooltipsEnabled = true;
        UpdatePalaceIncome();
        UpdateWallBonus();
        UpdateArmy();
    }

    public void convertInfoIntToString()
    {
        moneyString = money.ToString();
    }

    public void ToggleTooltips()
    {
        if (tooltipsEnabled)
        {
            tooltipsEnabled = false;
        }else { tooltipsEnabled = true; }
    }


    public void UpdateArmy()
    {
        UpdateArmySize();
        UpdateArmyPower();
    }

    public void UpdateArmySize()
    {
        armySize = peasantCount + footmanCount + bowmanCount + knightCount + lancerCount;
    }

    public void UpdateArmyPower()
    {
        armyPower =
        (peasantCount * peasantPower) +
        (footmanCount * footmanPower) +
        (bowmanCount * bowmanPower) +
        (knightCount * knightPower) +
        (lancerCount * lancerPower);
    }

    public void EmptyArmyList()
    {
        armyList.Clear();
    }

    public void FillArmyList()
    {
        Debug.Log("Filling armyList");

        //Fill list list with int(peasantAtk) * peasantCount
        for (int i = 0; i < peasantCount; i++)
        {
            armyList.Add(peasantHealth);
            Debug.Log("Added Peasant To List");
        }
        for (int j = 0; j < footmanCount; j++)
        {
            armyList.Add(footmanHealth);
            Debug.Log("Added Footman to list");
        }
        for (int k = 0; k < bowmanCount; k++)
        {
            armyList.Add(bowmanHealth);
            Debug.Log("Added Bowman to list");
        }
        for (int l = 0; l < knightCount; l++)
        {
            armyList.Add(knightHealth);
            Debug.Log("Added Knight to list");
        }
        for (int m = 0; m < lancerCount; m++)
        {
            armyList.Add(lancerHealth);
            Debug.Log("Added Lancer to List");
        }
        Debug.Log(armyList.Count + "armyList Count");

    }

    public void UpdateInfoIntToString()
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
            palaceNextIncome = palaceIncome[1];
        }
        else if (palaceLevel == 2)
        {
            palaceCurrentIncome = palaceIncome[1];
            palaceNextIncome = palaceIncome[2];
        }
        else if (palaceLevel == 3)
        {
            palaceCurrentIncome = palaceIncome[2];
            palaceNextIncome = palaceIncome[3];
        }
        else if (palaceLevel == 4)
        {
            palaceCurrentIncome = palaceIncome[3];
            palaceNextIncome = palaceIncome[4];
        }
        else if (palaceLevel == 5)
        {
            palaceCurrentIncome = palaceIncome[4];
            palaceNextIncome = 0;
        }
    }

    public void UpdateWallBonus()
    {
        if (wallLevel == 1)
        {
            wallCurrentBonus = wallBonus[0];
            wallNextBonus = wallBonus[1];
        }
        else if (wallLevel == 2)
        {
            wallCurrentBonus = wallBonus[1];
            wallNextBonus = wallBonus[2];
        }
        else if (wallLevel == 3)
        {
            wallCurrentBonus = wallBonus[2];
            wallNextBonus = wallBonus[3];
        }
        else if (wallLevel == 4)
        {
            wallCurrentBonus = wallBonus[3];
            wallNextBonus = wallBonus[4];
        }
        else if (wallLevel == 5)
        {
            wallCurrentBonus = wallBonus[4];
            wallNextBonus = 0;
        }
    }

}
