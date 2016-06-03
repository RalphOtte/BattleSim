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
    public GameObject playerTurnText;
    public GameObject moneyText;
    public GameObject gameOverScreen;

    private bool townScreenActive;
    private bool palaceBuildingActive;
    private bool barracksBuildingActive;
    private bool academyBuildingActive;
    private bool wallBuildingActive;
    private bool builderBuildingActive;
    private bool gatheringBuildingActive;

    private bool giveUpButtonActive;
    private bool endTurnButtonActive;
    private bool playerTurnTextActive;
    private bool moneyTextActive;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        Debug.Log("Entering Govern Phase");
        townScreenActive = true;
        townScreen.SetActive(true);
        endTurnButtonActive = true;
        EndTurnButton.SetActive(true);
        giveUpButtonActive = true;
        giveUpButton.SetActive(true);
        playerTurnTextActive = true;
        playerTurnText.SetActive(true);
        moneyTextActive = true;
        moneyText.SetActive(true);
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
        else if (gatheringBuildingActive == true)
        {
            gatheringBuildingActive = false;
        }
        SwitchTownScreen();
        stateMachine.SetState(StateID.Govern);

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
        stateMachine.SetState(StateID.Initialization);
    }

    public void GiveUp()
    {
        if (gameController.playerTurn == 1)
        {
            gameController.playerWin = 2;
        }
        else if (gameController.playerTurn == 2)
        {
            gameController.playerWin = 1;
        }
        GameOver();
    }

    public void GameOver()
    {
        SwitchTownScreen();
        gameOverScreen.SetActive(true);
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

    /*
    

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