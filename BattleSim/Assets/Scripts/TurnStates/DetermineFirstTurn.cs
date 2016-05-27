using UnityEngine;
using System.Collections;

public class DetermineFirstTurn : State
{
    private StateMachine stateMachine;
    private GameController gameController;
    private int playerTurn;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        Debug.Log("Enter DetermineFirst");
        
        playerTurn = Random.Range(0, 1);
        if (playerTurn < 0.5)
        {
            gameController.playerTurn = 1;
            Debug.Log("Player 1 starts first!");
        }
        else if(playerTurn > 0.5)
        {
            gameController.playerTurn = 2; Debug.Log("Player 2 starts first!");
        }
        stateMachine.SetState(StateID.Initialization);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

}