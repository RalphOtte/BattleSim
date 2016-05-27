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
    public int palaceLevel;
    public int palaceCurrentIncome;
    public int[] palaceIncome;
    public int barracksLevel;
    public int academyLevel;
    public int wallLevel;

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

}
