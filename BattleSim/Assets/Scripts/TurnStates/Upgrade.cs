using UnityEngine;
using System.Collections;

public class Upgrade : State {

    private StateMachine stateMachine;
    private GameController gameController;
    private TextController textController;

    public GameObject buildersHut;
    public GameObject moneyAnimation;
    public GameObject palaceUpgradeAnimation;
    public GameObject barracksUpgradeAnimation;
    public GameObject wallUpgradeAnimation;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        textController = GetComponent<TextController>();
        Debug.Log("Entering Upgrade Phase");
        buildersHut.SetActive(true);
        gameController.p1.UpdateInfoIntToString();
        gameController.p2.UpdateInfoIntToString();
        UpdateBuildersHutInfo();
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

    private void UpdateBuildersHutInfo()
    {
        if (gameController.playerTurn == 1)
        {
            textController.UpdateBuildersHutP1();
        }

        else if (gameController.playerTurn == 2)
        {
            textController.UpdateBuildersHutP2();
        }
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
                gameController.p1.UpdateUpgradeCosts();
                gameController.p1.UpdateInfoIntToString();
                Instantiate(moneyAnimation, palaceUpgradeAnimation.transform.position, Quaternion.identity);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= gameController.p2.palaceUpgradeCost[gameController.p2.palaceLevel - 1])
            {
                gameController.p2.money -= gameController.p2.palaceUpgradeCost[gameController.p2.palaceLevel - 1];
                gameController.p2.palaceLevel++;
                gameController.p2.UpdatePalaceIncome();
                Instantiate(moneyAnimation, palaceUpgradeAnimation.transform.position, Quaternion.identity);
                gameController.p2.UpdateUpgradeCosts();
                gameController.p2.UpdateInfoIntToString();
            }
        }
        UpdateBuildersHutInfo();
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
                textController.UpdateBarracksProductionP1();
                Instantiate(moneyAnimation, barracksUpgradeAnimation.transform.position, Quaternion.identity);
                gameController.p1.UpdateUpgradeCosts();
                gameController.p1.UpdateInfoIntToString();
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= gameController.p2.barracksUpgradeCost[gameController.p2.barracksLevel - 1])
            {
                gameController.p2.money -= gameController.p2.barracksUpgradeCost[gameController.p2.barracksLevel - 1];
                gameController.p2.barracksLevel++;
                textController.UpdateBarracksProductionP2();
                Instantiate(moneyAnimation, barracksUpgradeAnimation.transform.position, Quaternion.identity);
                gameController.p2.UpdateUpgradeCosts();
                gameController.p2.UpdateInfoIntToString();
            }
        }
        UpdateBuildersHutInfo();
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
                gameController.p1.UpdateUpgradeCosts();
                gameController.p1.UpdateInfoIntToString();
                Instantiate(moneyAnimation, wallUpgradeAnimation.transform.position, Quaternion.identity);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= gameController.p2.wallUpgradeCost[gameController.p2.wallLevel - 1])
            {
                gameController.p2.money -= gameController.p2.wallUpgradeCost[gameController.p2.wallLevel - 1];
                gameController.p2.wallLevel++;
                gameController.p2.UpdateWallBonus();
                Instantiate(moneyAnimation, wallUpgradeAnimation.transform.position, Quaternion.identity);
                gameController.p2.UpdateUpgradeCosts();
                gameController.p2.UpdateInfoIntToString();
            }
        }
        UpdateBuildersHutInfo();
    }
}
