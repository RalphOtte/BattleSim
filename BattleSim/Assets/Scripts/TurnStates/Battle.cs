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

    //ALL UNIT STATS COME HERE

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
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        Debug.Log("Enter Battle");
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

        Debug.Log("Board Updated");
    }

    void ImportArmies()
    {
        //When import is done:
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

        //When this method is done:
        ShowBattleResults();
    }

    void ShowBattleResults()
    {
        //Shows battle results with a projected "winner" of the battle.
        //When this method is done:
        EndBattle();
    }

    void EndBattle()
    {
        govern.EndTurn();
    }
}