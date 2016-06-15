using UnityEngine;
using System.Collections;

public class GatheringSQ : State {

    private StateMachine stateMachine;
    private GameController gameController;
    private TextController textController;
    private Battle battle;

    public GameObject gatheringSQ;
    public GameObject menu;
    public GameObject confirmScreen;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        textController = GetComponent<TextController>();
        battle = GetComponent<Battle>();
        Debug.Log("Entering GatheringSquare Phase");
        gatheringSQ.SetActive(true);
        menu.SetActive(true);
        confirmScreen.SetActive(false);
        UpdateTroopInfo();
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public void UpdateTroopInfo()
    {
        if (gameController.playerTurn == 1)
        {
            textController.gatheringPeasantCount.text = gameController.p1.peasantCount.ToString();
            textController.gatheringFootmanCount.text = gameController.p1.footmanCount.ToString();
            textController.gatheringBowmanCount.text = gameController.p1.bowmanCount.ToString();
            textController.gatheringKnightCount.text = gameController.p1.knightCount.ToString();
            textController.gatheringLancerCount.text = gameController.p1.lancerCount.ToString();
        }
        else if (gameController.playerTurn == 2)
        {
            textController.gatheringPeasantCount.text = gameController.p2.peasantCount.ToString();
            textController.gatheringFootmanCount.text = gameController.p2.footmanCount.ToString();
            textController.gatheringBowmanCount.text = gameController.p2.bowmanCount.ToString();
            textController.gatheringKnightCount.text = gameController.p2.knightCount.ToString();
            textController.gatheringLancerCount.text = gameController.p2.lancerCount.ToString();
        }
    }

    public void ConfirmScreen()
    {
        if (gameController.p1.safePhaseTurns >= 0 || gameController.p2.safePhaseTurns >= 0)
        {

        }
        else
        {
            menu.SetActive(false);
            confirmScreen.SetActive(true);
        }
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
        Debug.Log("Initiating Battle!");
        gameController.p1.FillArmyList();
        gameController.p2.FillArmyList();
        stateMachine.SetState(StateID.Battle);
    }

    public void CancelBattle()
    {
        menu.SetActive(true);
        confirmScreen.SetActive(false);
    }

    public override void Leave()
    {
        gatheringSQ.SetActive(false);
    }

}
