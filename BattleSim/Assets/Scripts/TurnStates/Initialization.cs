using UnityEngine;
using System.Collections;

public class Initialization : State
{
    private StateMachine stateMachine;
    private GameController gameController;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        Debug.Log("Entering turn initialization");
        if (gameController.playerTurn == 1)
        {
            gameController.p1.money += gameController.p1.palaceCurrentIncome;
        }
        else if(gameController.playerTurn == 2)
        {
            gameController.p2.money += gameController.p2.palaceCurrentIncome;
        }
        stateMachine.SetState(StateID.Govern);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

}