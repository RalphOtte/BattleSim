using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Govern : State
{
    private StateMachine stateMachine;
    private GameController gameController;
    private Battle battle;

    public GameObject mainMenu;
    public GameObject trainMenu;
    public GameObject upgradeMenu;
    public GameObject researchMenu;
    public GameObject ConfirmBattleMenu;
    public GameObject battleBackground;
    public GameObject backButton;
    public GameObject gameOverMenu;
    public Text turnText;
    public Text player1Money;
    public Text player2Money;

    //Upgrade Texts
    public Text palaceUpgradeCurrentLevel;
    public Text barracksUpgradeCurrentLevel;
    public Text academyUpgradeCurrentLevel;
    public Text wallUpgradeCurrentLevel;

    public Text palaceUpgradeCostText;
    public Text barracksUpgradeCostText;
    public Text academyUpgradeCostText;
    public Text wallUpgradeCostText;

    private bool mainMenuActive;
    private bool trainMenuActive;
    private bool upgradeMenuActive;
    private bool researchMenuActive;
    private bool ConfirmBattleActive;
    private bool battleBackgroundActive;
    private bool backActive;
    private bool gameOverActive;

    //Unit Train Costs
    [SerializeField]private int peasantTrainCost;
    [SerializeField]private int footmanTrainCost;
    [SerializeField]private int bowmanTrainCost;
    [SerializeField]private int knightTrainCost;
    [SerializeField]private int lancerTrainCost;
    //Research Money Cost
    [SerializeField]private int footmanResearchCost;
    [SerializeField]private int bowmanResearchCost;
    [SerializeField]private int knightResearchCost;
    [SerializeField]private int lancerResearchCost;
    [SerializeField]private int wallResearchCost;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        battle = GetComponent<Battle>();

        battle.UpdateBoard();
        Debug.Log("Enter Govern");
        mainMenu.SetActive(true);
        mainMenuActive = true;
        backButton.SetActive(false);
        backActive = false;
        UpdateTurnText();
        UpdateMoneyTexts();

        //Quick Solution
        if (gameController.playerTurn == 1)
        {
            UpdateResearchTextsP1();
        }
        else if (gameController.playerTurn == 2)
        {
            UpdateResearchTextsP2();
        }
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public void UpdateMoneyTexts()
    {
        player1Money.text = "Money: " + gameController.p1.money;
        player2Money.text = "Money: " + gameController.p2.money;
    }

    public void UpdateResearchTextsP1()
    {
        palaceUpgradeCurrentLevel.text = gameController.p1.palaceLevelText;
        barracksUpgradeCurrentLevel.text = gameController.p1.barracksLevelText;
        academyUpgradeCurrentLevel.text = gameController.p1.academyLevelText;
        wallUpgradeCurrentLevel.text = gameController.p1.wallLevelText;

        palaceUpgradeCostText.text = gameController.p1.palaceUpgradeCostText;
        barracksUpgradeCostText.text = gameController.p1.barracksUpgradeCostText;
        academyUpgradeCostText.text = gameController.p1.academyUpgradeCostText;
        wallUpgradeCostText.text = gameController.p1.wallUpgradeCostText;
    }

    public void UpdateResearchTextsP2()
    {
        palaceUpgradeCurrentLevel.text = gameController.p2.palaceLevelText;
        barracksUpgradeCurrentLevel.text = gameController.p2.barracksLevelText;
        academyUpgradeCurrentLevel.text = gameController.p2.academyLevelText;
        wallUpgradeCurrentLevel.text = gameController.p2.wallLevelText;

        palaceUpgradeCostText.text = gameController.p2.palaceUpgradeCostText;
        barracksUpgradeCostText.text = gameController.p2.barracksUpgradeCostText;
        academyUpgradeCostText.text = gameController.p2.academyUpgradeCostText;
        wallUpgradeCostText.text = gameController.p2.wallUpgradeCostText;
    }

    //General Back Button
    public void Back()
    {
        if (trainMenuActive == true)
        {
            trainMenu.SetActive(false);
            trainMenuActive = false;
        }
        else if (upgradeMenuActive == true)
        {
            upgradeMenu.SetActive(false);
            upgradeMenuActive = false;
        }
        else if (researchMenuActive == true)
        {
            researchMenu.SetActive(false);
            researchMenuActive = false;
        }
        else if (ConfirmBattleActive == true)
        {
            ConfirmBattleMenu.SetActive(false);
            ConfirmBattleActive = false;
        }
        EnableMainMenu();

    }

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
        ConfirmBattleMenu.SetActive(true);
        ConfirmBattleActive = true;
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
        ConfirmBattleMenu.SetActive(false);
        ConfirmBattleActive = false;
        battleBackground.SetActive(true);
        battleBackgroundActive = true;
        stateMachine.SetState(StateID.Battle);
    }

    public void CancelBattle()
    {
        Back();
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

    //All Training Options
    public void TrainPeasant()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= peasantTrainCost)
            {
                gameController.p1.money -= peasantTrainCost;
                gameController.p1.peasantCount = gameController.p1.peasantCount + (1 * gameController.p1.barracksLevel);
            }
        }
        else if(gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= peasantTrainCost)
            {
                gameController.p2.money -= peasantTrainCost;
                gameController.p2.peasantCount = gameController.p2.peasantCount + (1 * gameController.p2.barracksLevel);
            }
        }
        UpdateMoneyTexts();
        battle.UpdateBoard();
    }

    public void TrainFootman()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= footmanTrainCost && gameController.p1.footmanUnlocked)
            {
                gameController.p1.money -= footmanTrainCost;
                gameController.p1.footmanCount = gameController.p1.footmanCount + (1 * gameController.p1.barracksLevel);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= footmanTrainCost && gameController.p2.footmanUnlocked)
            {
                gameController.p2.money -= footmanTrainCost;
                gameController.p2.footmanCount = gameController.p2.footmanCount + (1 * gameController.p2.barracksLevel);
            }
        }
        UpdateMoneyTexts();
        battle.UpdateBoard();
    }

    public void TrainBowman()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= bowmanTrainCost && gameController.p1.bowmanUnlocked)
            {
                gameController.p1.money -= bowmanTrainCost;
                gameController.p1.bowmanCount = gameController.p1.bowmanCount + (1 * gameController.p1.barracksLevel);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= bowmanTrainCost && gameController.p2.bowmanUnlocked)
            {
                gameController.p2.money -= bowmanTrainCost;
                gameController.p2.bowmanCount = gameController.p2.bowmanCount + (1 * gameController.p2.barracksLevel);
            }
        }
        UpdateMoneyTexts();
        battle.UpdateBoard();
    }

    public void TrainKnight()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= knightTrainCost && gameController.p1.knightUnlocked)
            {
                gameController.p1.money -= knightTrainCost;
                gameController.p1.knightCount = gameController.p1.knightCount + (1 * gameController.p1.barracksLevel);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= knightTrainCost && gameController.p2.knightUnlocked)
            {
                gameController.p2.money -= knightTrainCost;
                gameController.p2.knightCount = gameController.p2.knightCount + (1 * gameController.p2.barracksLevel);
            }
        }
        UpdateMoneyTexts();
        battle.UpdateBoard();
    }

    public void TrainLancer()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= lancerTrainCost && gameController.p1.lancerUnlocked)
            {
                gameController.p1.money -= lancerTrainCost;
                gameController.p1.lancerCount = gameController.p1.lancerCount + (1 * gameController.p1.barracksLevel);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= lancerTrainCost && gameController.p2.lancerUnlocked)
            {
                gameController.p2.money -= lancerTrainCost;
                gameController.p2.lancerCount = gameController.p2.lancerCount + (1 * gameController.p2.barracksLevel);
            }
        }
        UpdateMoneyTexts();
        battle.UpdateBoard();
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
}