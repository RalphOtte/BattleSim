using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Battle : State
{
    private StateMachine stateMachine;
    private GameController gameController;
    private Govern govern;
    public Player p1;
    public Player p2;

    public int attackingPlayer; //Each number corresponds to player number, 1 = P1 etc.
    public int defendingPlayer; //Each number corresponds to player number, 2 = P2 etc.

    //Attacking Troops
    private int atkTroopCount; //How many troops the attacking player has
    private int atkTroopPower; //How many power the troops of the attacking player has
    private float atkTroopDifferential; //How many times more/less troops the attacking player has over the defending player
    private float atkTotalPower; //Total power of the attacking player after all calculations
    private int atkTotalHealth;
    //These integers will subtract the losses from the player after the battle is done
    private int atkPeasantLost;
    private int atkFootmanLost;
    private int atkBowmanLost;
    private int atkKnightLost;
    private int atkLancerLost;

    //Defending Troops
    private int defTroopCount; //How many troops the defending player has
    private int defTroopPower; //How many power the troops of the defending player has
    private int defDefenseBonus; //WallBonus
    private int defTotalPower; //Total power of the defending player after all calculations
    private int defTotalHealth;
    //These integers will subtract the losses from the player after the battle is done
    private int defPeasantLost;
    private int defFootmanLost;
    private int defBowmanLost;
    private int defKnightLost;
    private int defLancerLost;

    private List<int> atkList;
    private List<int> defList;

    //Player 1 unit texts
    public GUIText p1PeasantText;
    public GUIText p1FootmanText;
    public GUIText p1BowmanText;
    public GUIText p1KnightText;
    public GUIText p1LancerText;

    //Player 2 unit texts
    public GUIText p2PeasantText;
    public GUIText p2FootmanText;
    public GUIText p2BowmanText;
    public GUIText p2KnightText;
    public GUIText p2LancerText;

    private int selectedUnit; // In the list

    public override void Enter()
    {
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"

        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        Debug.Log("Entering Battle Phase");
        //Show Empty Board
        ImportArmies();
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public void UpdateBoard()
    {
        p1PeasantText.text = "" + p1.peasantCount;
        p1FootmanText.text = "" + p1.footmanCount;
        p1BowmanText.text = "" + p1.bowmanCount;
        p1KnightText.text = "" + p1.knightCount;
        p1LancerText.text = "" + p1.lancerCount;

        p2PeasantText.text = "" + p2.peasantCount;
        p2FootmanText.text = "" + p2.footmanCount;
        p2BowmanText.text = "" + p2.bowmanCount;
        p2KnightText.text = "" + p2.knightCount;
        p2LancerText.text = "" + p2.lancerCount;

        Debug.Log("Troop Board Updated");
    }

    void ImportArmies()
    {
        if (attackingPlayer == 1)
        {
            //Import Player 1's Troop data and place it in attacking players variables
            atkTroopCount = gameController.p1.armySize;
            atkTroopPower = gameController.p1.armyPower;
            Debug.Log("atk Count " + atkTroopCount);
            Debug.Log("atkPow " + atkTroopPower);
            //Import player 2's troop data and place it in defending players variables
            defTroopCount = gameController.p2.armySize;
            defTroopPower = gameController.p2.armyPower;
            defDefenseBonus = gameController.p2.wallCurrentBonus;
            Debug.Log("def Count " + defTroopCount);
            Debug.Log("defPow " + defTroopPower);
            Debug.Log("defWall " + defDefenseBonus);
        }
        else if (attackingPlayer == 2)
        {
            //Import Player 1's Troop data and place it in attacking players variables
            atkTroopCount = gameController.p2.armySize;
            atkTroopPower = gameController.p2.armyPower;
            Debug.Log("atk Count " + atkTroopCount);
            Debug.Log("atkPow " + atkTroopPower);
            //Import player 2's troop data and place it in defending players variables
            defTroopCount = gameController.p1.armySize;
            defTroopPower = gameController.p1.armyPower;
            defDefenseBonus = gameController.p1.wallCurrentBonus;
            Debug.Log("def Count " + defTroopCount);
            Debug.Log("defPow " + defTroopPower);
            Debug.Log("defWall " + defDefenseBonus);
        }
        //When this method is done:
        CalculateArmyPowers();
    }

    void CalculateArmyPowers()
    {
        //Determine Attacking troops power
        atkTroopDifferential = atkTroopCount / defTroopCount;
        atkTotalPower = atkTroopCount * atkTroopDifferential;
        Debug.Log("atkTotPow" + atkTotalPower);
        Debug.Log("atk troop diff" + atkTroopDifferential);

        //When this method is done:
        //Fill ArmyLists
        
    }

    void FillArmyLists()
    {
        //Copy army lists directly from player
        if (attackingPlayer == 1)
        {
            atkList = new List<int>(gameController.p1.armyList);
            defList = new List<int>(gameController.p2.armyList);
        }
        else if (attackingPlayer == 2)
        {
            atkList = new List<int>(gameController.p2.armyList);
            defList = new List<int>(gameController.p1.armyList);
        }
        //When this method is done:
        BattleSequence();
    }

    void BattleSequence()
    {
        //This method handles all numbers and math, and posts the result in variables

        //Subtract attackingtroops
        //Checks if the remaining DefPower is higher than the lowest int in the list
        //If the Defpower is higher and there are still list items left. Subtract
        if (defTotalPower > atkList[0] && atkList.Count >= 1)
        {
            int randomIndex = Random.Range(0, atkList.Count);
            defTotalPower -= randomIndex;
        }

        //Checks if the remaining AtkPower is higher than the lowest int in the list
        //If the Atkpower is higher and there are still list items left. Subtract
        if (atkTotalPower > defList[0] && defList.Count >= 1)
        {
            int randomIndex = Random.Range(0, defList.Count);
            atkTotalPower -= randomIndex;
        }
        
        
        

        //When this method is done:
        //ShowBattleResults();
    }

    void ShowBattleResults()
    {
        //Shows battle results with a projected "winner" of the battle.
        //When this method is done:
        //EndBattle();
    }

    void EndBattle()
    {
        //If defending player still has troops:
        //govern.EndTurn();

        //If defending player has no troops left:
        //govern.GameOver();
    }
}