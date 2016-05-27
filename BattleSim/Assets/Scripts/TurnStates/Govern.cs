using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Govern : State
{
    private StateMachine stateMachine;
    private GameController gameController;
    private BattleController battleController;

    public GameObject mainMenu;
    public GameObject trainMenu;
    public GameObject upgradeMenu;
    public GameObject researchMenu;
    public GameObject ConfirmBattleMenu;
    public GameObject backButton;
    public Text turnText;
    public Text player1Money;
    public Text player2Money;

    private bool mainMenuActive;
    private bool trainMenuActive;
    private bool upgradeMenuActive;
    private bool researchMenuActive;
    private bool ConfirmBattleActive;
    private bool backActive;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        battleController = GetComponent<BattleController>();

        battleController.UpdateBoard();
        Debug.Log("Enter Govern");
        mainMenu.SetActive(true);
        mainMenuActive = true;
        backButton.SetActive(false);
        backActive = false;
        UpdateTurnText();
        UpdateMoneyTexts();
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

    //All Menu Items
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
        else { gameController.playerTurn = 1; }
        UpdateTurnText();
        stateMachine.SetState(StateID.Initialization);
    }

    public void GiveUp()
    {

    }

    void UpdateTurnText()
    {
        if (gameController.playerTurn == 1)
        {
            turnText.text = "Player 1's turn";
        }
        else { turnText.text = "Player 2's turn"; }
        
    }

    //All Training Options
    public void TrainPeasant()
    {

    }

    public void TrainFootman()
    {

    }

    public void TrainBowman()
    {

    }

    public void TrainKnight()
    {

    }

    public void TrainLancer()
    {

    }

    //All Upgrade Options
    public void UpgradePalace()
    {

    }

    public void UpgradeBarrack()
    {

    }

    public void UpgradeAcademy()
    {

    }

    public void UpgradeWall()
    {

    }

    //All Research Options
    public void ResearchFootman()
    {

    }

    public void ResearchBowman()
    {

    }

    public void ResearchKnight()
    {

    }

    public void ResearchLancer()
    {

    }



}