using UnityEngine;
using System.Collections;

public class Upgrade : State {

    private StateMachine stateMachine;
    private GameController gameController;

    public GameObject buildersHut;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        Debug.Log("Entering Upgrade Phase");
        buildersHut.SetActive(true);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public override void Leave()
    {
        buildersHut.SetActive(false);
    }

    //All Upgrade Options
    public void UpgradePalace()
    {
        if (gameController.playerTurn == 1)
        {
            //If p1 money is higher than player 1's current cost of palaceUpgrade
            if (gameController.p1.money >= gameController.p1.palaceUpgradeCost[gameController.p1.palaceLevel - 1])
            {
                gameController.p1.money -= gameController.p1.palaceUpgradeCost[gameController.p1.palaceLevel - 1];
                gameController.p1.palaceLevel++;
                gameController.p1.UpdatePalaceIncome();
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= gameController.p2.palaceUpgradeCost[gameController.p2.palaceLevel - 1])
            {
                gameController.p2.money -= gameController.p2.palaceUpgradeCost[gameController.p2.palaceLevel - 1];
                gameController.p2.palaceLevel++;
                gameController.p2.UpdatePalaceIncome();
            }
        }
    }

    public void UpgradeBarracks()
    {
        if (gameController.playerTurn == 1)
        {
            //If p1 money is higher than player 1's current cost of barracksUpgrade
            if (gameController.p1.money >= gameController.p1.barracksUpgradeCost[gameController.p1.barracksLevel - 1])
            {
                gameController.p1.money -= gameController.p1.barracksUpgradeCost[gameController.p1.barracksLevel - 1];
                gameController.p1.barracksLevel++;
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= gameController.p2.barracksUpgradeCost[gameController.p2.barracksLevel - 1])
            {
                gameController.p2.money -= gameController.p2.barracksUpgradeCost[gameController.p2.barracksLevel - 1];
                gameController.p2.barracksLevel++;
            }
        }
    }

    public void UpgradeWall()
    {
        if (gameController.playerTurn == 1)
        {
            //If p1 money is higher than player 1's current cost of wallUpgrade
            if (gameController.p1.money >= gameController.p1.wallUpgradeCost[gameController.p1.wallLevel - 1])
            {
                gameController.p1.money -= gameController.p1.wallUpgradeCost[gameController.p1.wallLevel - 1];
                gameController.p1.wallLevel++;
                gameController.p1.UpdateWallBonus();
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= gameController.p2.wallUpgradeCost[gameController.p2.wallLevel - 1])
            {
                gameController.p2.money -= gameController.p2.wallUpgradeCost[gameController.p2.wallLevel - 1];
                gameController.p2.wallLevel++;
                gameController.p2.UpdateWallBonus();
            }
        }
    }
}
