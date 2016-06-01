using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Govern : State
{
    private StateMachine stateMachine;
    private GameController gameController;

    public GameObject townScreen;
    public GameObject palaceBuilding;
    public GameObject barracksBuilding;
    public GameObject academyBuilding;
    public GameObject wallBuilding;
    public GameObject builderBuilding;
    public GameObject gatheringBuilding;

    public GameObject giveUpButton;
    public GameObject EndTurnButton;

    private bool townScreenActive;
    private bool palaceBuildingActive;
    private bool barracksBuildingActive;
    private bool academyBuildingActive;
    private bool wallBuildingActive;
    private bool builderBuildingActive;
    private bool gatheringBuildingActive;

    private bool giveUpButtonActive;
    private bool endTurnButtonActive;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        Debug.Log("Entering Govern Phase");
        townScreenActive = true;
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    void SwitchTownScreen()
    {
        if (townScreenActive == true)
        {
            townScreen.SetActive(false);
            townScreenActive = false;
        }
        else { townScreen.SetActive(true); townScreenActive = true; }
    }

    public void PalaceMenu()
    {
        SwitchTownScreen();
        palaceBuildingActive = true;
        stateMachine.SetState(StateID.Palace);
    }

    public void BarracksMenu()
    {
        SwitchTownScreen();
        barracksBuildingActive = true;
        stateMachine.SetState(StateID.Train);
    }

    public void AcademyMenu()
    {
        SwitchTownScreen();
        academyBuildingActive = true;
        stateMachine.SetState(StateID.Research);
    }

    public void GatheringSquareMenu()
    {
        SwitchTownScreen();
        gatheringBuildingActive = true;
        stateMachine.SetState(StateID.GatheringSQ);
    }

    public void WallMenu()
    {
        SwitchTownScreen();
        wallBuildingActive = true;
        stateMachine.SetState(StateID.Wall);
    }

    public void BuilderMenu()
    {
        SwitchTownScreen();
        builderBuildingActive = true;
        stateMachine.SetState(StateID.Upgrade);
    }
    /*
    public void UpdateMoneyTexts()
    {
        player1Money.text = "Money: " + gameController.p1.money;
        player2Money.text = "Money: " + gameController.p2.money;
    }*/

    //General Back Button
    public void Back()
    {
        if (barracksBuildingActive == true)
        {
            barracksBuildingActive = false;
        }
        else if (builderBuildingActive == true)
        {
            builderBuildingActive = false;
        }
        else if (academyBuildingActive == true)
        {
            academyBuildingActive = false;
        }
        else if (palaceBuildingActive == true)
        {
            palaceBuildingActive = false;
        }
        else if (wallBuildingActive == true)
        {
            wallBuildingActive = false;
        }
        SwitchTownScreen();
        stateMachine.SetState(StateID.Govern);

    }
    /*
    //All Menu Items
    void DisableMainMenu()
    {
        mainMenu.SetActive(false);
        mainMenuActive = false;
        backButton.SetActive(true);
        backActive = true;
    }

    void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        mainMenuActive = true;
        backButton.SetActive(false);
        backActive = false;
    }

    public void TrainMenu()
    {
        //Enable all training menu options
        //Disable standard menu options
        DisableMainMenu();
        trainMenu.SetActive(true);
        trainMenuActive = true;
    }

    public void UpgradeMenu()
    {
        //Enable all Upgrade menu options
        //Disable standard menu options
        DisableMainMenu();
        upgradeMenu.SetActive(true);
        upgradeMenuActive = true;
    }

    public void ResearchMenu()
    {
        //Enable all Research menu options
        //Disable standard menu options
        DisableMainMenu();
        researchMenu.SetActive(true);
        researchMenuActive = true;
    }

    public void BattleMenu()
    {
        //Battle
        DisableMainMenu();
        confirmBattleMenu.SetActive(true);
        confirmBattleActive = true;
    }

    public void ConfirmBattle()
    {
        if (gameController.playerTurn == 1)
        {
            battle.attackingPlayer = 1;
            battle.defendingPlayer = 2;
        }
        else if (gameController.playerTurn == 2)
        {
            battle.attackingPlayer = 2;
            battle.defendingPlayer = 1;
        }

        DisableMainMenu();
        backButton.SetActive(false);
        backActive = false;
        confirmBattleMenu.SetActive(false);
        confirmBattleActive = false;
        battleBackground.SetActive(true);
        battleBackgroundActive = true;
        stateMachine.SetState(StateID.Battle);
    }

    public void CancelBattle()
    {
        Back();
    }

    public void SafePhase()
    {
        //InputField SafePhase string convert to int
    }

    public void EndTurn()
    {
        //Switch to other player's initialization phase
        if (gameController.playerTurn == 1)
        {
            gameController.playerTurn = 2;
        }
        else if (gameController.playerTurn == 2)
        {
            gameController.playerTurn = 1;
        }
        UpdateTurnText();
        stateMachine.SetState(StateID.Initialization);
    }

    public void GiveUp()
    {
        if (gameController.playerTurn == 1)
        {
            gameController.playerWin = 2;
        }
        else if(gameController.playerTurn == 2)
        {
            gameController.playerWin = 1;
        }
        GameOver();
    }

    public void GameOver()
    {
        
    }

    public void BackToMain()
    {
        Application.LoadLevel(0);
    }

    public void Rematch()
    {
        //Reloads current scene
        Application.LoadLevel(Application.loadedLevel);
    }

    void UpdateTurnText()
    {
        if (gameController.playerTurn == 1)
        {
            turnText.text = "Player 1's turn";
        }
        else if (gameController.playerTurn == 2)
        {
            turnText.text = "Player 2's turn";
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
        UpdateMoneyTexts();
    }

    public void UpgradeBarrack()
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
                gameController.p2.money -= gameController.p2.barracksUpgradeCost[gameController.p2.barracksLevel -1];
                gameController.p2.barracksLevel++;
            }
        }
        UpdateMoneyTexts();
    }

    public void UpgradeAcademy()
    {

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
        UpdateMoneyTexts();
    }

    //All Research Options
    public void ResearchFootman()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= footmanResearchCost)
            {
                gameController.p1.money -= footmanResearchCost;
                gameController.p1.footmanUnlocked = true;
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= footmanResearchCost)
            {
                gameController.p2.money -= footmanResearchCost;
                gameController.p2.footmanUnlocked = true;
            }
        }
        UpdateMoneyTexts();
    }

    public void ResearchBowman()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= bowmanResearchCost)
            {
                gameController.p1.money -= bowmanResearchCost;
                gameController.p1.bowmanUnlocked = true;
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= bowmanResearchCost)
            {
                gameController.p2.money -= bowmanResearchCost;
                gameController.p2.bowmanUnlocked = true;
            }
        }
        UpdateMoneyTexts();
    }

    public void ResearchKnight()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= knightResearchCost)
            {
                gameController.p1.money -= knightResearchCost;
                gameController.p1.knightUnlocked = true;
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= knightResearchCost)
            {
                gameController.p2.money -= knightResearchCost;
                gameController.p2.knightUnlocked = true;
            }
        }
        UpdateMoneyTexts();
    }

    public void ResearchLancer()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= footmanResearchCost)
            {
                gameController.p1.money -= footmanResearchCost;
                gameController.p1.footmanUnlocked = true;
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= footmanResearchCost)
            {
                gameController.p2.money -= footmanResearchCost;
                gameController.p2.footmanUnlocked = true;
            }
        }
        UpdateMoneyTexts();
    }

    public void ResearchWall()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= lancerResearchCost)
            {
                gameController.p1.money -= lancerResearchCost;
                gameController.p1.lancerUnlocked = true;
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= lancerResearchCost)
            {
                gameController.p2.money -= lancerResearchCost;
                gameController.p2.lancerUnlocked = true;
            }
        }
        UpdateMoneyTexts();
    }
    */
}