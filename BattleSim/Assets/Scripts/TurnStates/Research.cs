using UnityEngine;
using System.Collections;

public class Research : State {

    private StateMachine stateMachine;
    private GameController gameController;
    private TextController textController;

    //Research Costs
    [SerializeField]private int footmanResearchCost;
    [SerializeField]private int bowmanResearchCost;
    [SerializeField]private int knightResearchCost;
    [SerializeField]private int lancerResearchCost;
    [SerializeField]private int wallResearchCost;


    public GameObject academy;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        textController = GetComponent<TextController>();
        Debug.Log("Entering Research Phase");
        academy.SetActive(true);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public override void Leave()
    {
        academy.SetActive(false);
    }

    public void ResearchFootman()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.footmanUnlocked == false)
            {
                if (gameController.p1.money >= footmanResearchCost)
                {
                    gameController.p1.footmanUnlocked = true;
                    gameController.p1.money -= footmanResearchCost;
                    textController.UpdateP1Money();
                }
            }
        }

        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.footmanUnlocked == false)
            {
                if (gameController.p2.money >= footmanResearchCost)
                {
                    gameController.p2.footmanUnlocked = true;
                    gameController.p2.money -= footmanResearchCost;
                    textController.UpdateP2Money();
                }
            }
        }
    }

    public void ResearchBowman()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.bowmanUnlocked == false)
            {
                if (gameController.p1.money >= bowmanResearchCost)
                {
                    gameController.p1.bowmanUnlocked = true;
                    gameController.p1.money -= bowmanResearchCost;
                    textController.UpdateP1Money();
                }
            }
        }

        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.bowmanUnlocked == false)
            {
                if (gameController.p2.money >= bowmanResearchCost)
                {
                    gameController.p2.bowmanUnlocked = true;
                    gameController.p2.money -= bowmanResearchCost;
                    textController.UpdateP2Money();
                }
            }
        }
    }

    public void ResearchKnight()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.knightUnlocked == false)
            {
                if (gameController.p1.money >= knightResearchCost)
                {
                    gameController.p1.knightUnlocked = true;
                    gameController.p1.money -= knightResearchCost;
                    textController.UpdateP1Money();
                }
            }
        }

        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.knightUnlocked == false)
            {
                if (gameController.p2.money >= knightResearchCost)
                {
                    gameController.p2.knightUnlocked = true;
                    gameController.p2.money -= knightResearchCost;
                    textController.UpdateP2Money();
                }
            }
        }
    }

    public void ResearchLancer()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.lancerUnlocked == false)
            {
                if (gameController.p1.money >= lancerResearchCost)
                {
                    gameController.p1.lancerUnlocked = true;
                    gameController.p1.money -= lancerResearchCost;
                    textController.UpdateP1Money();
                }
            }
        }

        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.lancerUnlocked == false)
            {
                if (gameController.p2.money >= lancerResearchCost)
                {
                    gameController.p2.lancerUnlocked = true;
                    gameController.p2.money -= lancerResearchCost;
                    textController.UpdateP2Money();
                }
            }
        }
    }

    public void ResearchWall()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.wallUnlocked == false)
            {
                if (gameController.p1.money >= wallResearchCost)
                {
                    gameController.p1.wallUnlocked = true;
                    gameController.p1.money -= wallResearchCost;
                    gameController.p1.wallLevel++;
                    gameController.p1.UpdateWallBonus();
                    textController.UpdateP1Money();
                }
            }
        }

        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.wallUnlocked == false)
            {
                if (gameController.p2.money >= wallResearchCost)
                {
                    gameController.p2.wallUnlocked = true;
                    gameController.p2.money -= wallResearchCost;
                    gameController.p2.wallLevel++;
                    gameController.p2.UpdateWallBonus();
                    textController.UpdateP2Money();
                }
            }
        }
    }
}
