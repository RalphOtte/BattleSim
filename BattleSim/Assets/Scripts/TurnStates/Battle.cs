using UnityEngine;
using System.Collections;

public class Battle : State
{
    private StateMachine stateMachine;
    private GameController gameController;
    private Govern govern;
    public Player p1;
    public Player p2;

    public int attackingPlayer; //Each number corresponds to player number, 1 = P1 etc.
    public int defendingPlayer; //Each number corresponds to player number, 2 = P2 etc.

    //All bools are used to flag whether player has higher than 0 of a kind of unit
    bool p1HasPeasant;
    bool p1HasFootman;
    bool p1HasBowman;
    bool p1HasKnight;
    bool p1HasLancer;
    bool p1HasWall;

    bool p2HasPeasant;
    bool p2HasFootman;
    bool p2HasBowman;
    bool p2HasKnight;
    bool p2HasLancer;
    bool p2HasWall;

    private int peasantCountAtk;
    private int footmanCountAtk;
    private int bowmanCountAtk;
    private int knightCountAtk;
    private int lancerCountAtk;

    private int peasantCountDef;
    private int footmanCountDef;
    private int bowmanCountDef;
    private int knightCountDef;
    private int lancerCountDef;
    private int wallBonusDef;

    private int peasantStronger; //1 = player 1, 2 = player 2 etc.
    private int footmanStronger;
    private int bowmanStronger;
    private int knightStronger;
    private int lancerStronger;

    //ALL UNIT STATS COME HERE
    public int peasantAtk;
    public int footmanAtk;
    public int bowmanAtk;
    public int knightAtk;
    public int lancerAtk;

    public int peasantDef;
    public int footmanDef;
    public int bowmanDef;
    public int knightDef;
    public int lancerDef;

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

    public override void Enter()
    {
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        Debug.Log("Entering Battle");
        //ImportArmies();
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
            peasantCountAtk = gameController.p1.peasantCount;
            footmanCountAtk = gameController.p1.footmanCount;
            bowmanCountAtk = gameController.p1.bowmanCount;
            knightCountAtk = gameController.p1.knightCount;
            lancerCountAtk = gameController.p1.lancerCount;

            peasantCountDef = gameController.p2.peasantCount;
            footmanCountDef = gameController.p2.footmanCount;
            bowmanCountDef = gameController.p2.bowmanCount;
            knightCountDef = gameController.p2.knightCount;
            lancerCountDef = gameController.p2.lancerCount;
        }
        else if (attackingPlayer == 2)
        {
            peasantCountAtk = gameController.p2.peasantCount;
            footmanCountAtk = gameController.p2.footmanCount;
            bowmanCountAtk = gameController.p2.bowmanCount;
            knightCountAtk = gameController.p2.knightCount;
            lancerCountAtk = gameController.p2.lancerCount;

            peasantCountDef = gameController.p1.peasantCount;
            footmanCountDef = gameController.p1.footmanCount;
            bowmanCountDef = gameController.p1.bowmanCount;
            knightCountDef = gameController.p1.knightCount;
            lancerCountDef = gameController.p1.lancerCount;
        }
        //When import is done
        BattleSequence();
    }

    void BattleSequence()
    {
        /* <Summary>
            This method handles all numbers and math, and posts the result in variables
            Currently all battles are a 1:1 power subtraction from each unit type
            IDEA: Fill lists with all able unit types and subtract 1:1.
            IDEA: Show power of armies and make a calculation based off of that
        </Summary> */

        if (peasantCountAtk >= peasantCountDef)
        {
            peasantStronger = 1;
        }
        else { peasantStronger = 2; }

        if (footmanCountAtk >= footmanCountDef)
        {
            footmanStronger = 1;
        }
        else { footmanStronger = 2; }

        if (bowmanCountAtk >= bowmanCountDef)
        {
            bowmanStronger = 1;
        }
        else { bowmanStronger = 2; }

        if (knightCountAtk >= knightCountDef)
        {
            knightStronger = 1;
        }
        else { knightStronger = 2; }

        if (lancerCountAtk >= lancerCountDef)
        {
            lancerStronger = 1;
        }
        else { lancerStronger = 2; }

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

        //If defending player has no troops lef:
        //govern.GameOver();
    }
}