using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Govern : State
{
    private StateMachine stateMachine;
    private GameController gameController;
    private TextController textController;

    public int winningPlayer;
    public bool gameOver;

    public GameObject townScreen;
    public GameObject banner;
    public GameObject palaceBuilding;
    public GameObject barracksBuilding;
    public GameObject academyBuilding;
    public GameObject wallBuilding;
    public GameObject builderBuilding;
    public GameObject gatheringBuilding;

    public GameObject giveUpButton;
    public GameObject EndTurnButton;
    public GameObject gameOverScreen;

    private bool townScreenActive;
    private bool bannerActive;
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
        textController = GetComponent<TextController>();
        Debug.Log("Entering Govern Phase");
        Act();
    }

    public override void Act()
    {
        if (gameOver == true)
        {
            GameOver();
        }
        else {
            townScreenActive = true;
            townScreen.SetActive(true);
            endTurnButtonActive = true;
            EndTurnButton.SetActive(true);
            giveUpButtonActive = true;
            giveUpButton.SetActive(true);
        }
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
        textController.totalTurns++;
        textController.UpdateTotalTurns();

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
}