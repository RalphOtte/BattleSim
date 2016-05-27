using UnityEngine;
using System.Collections;

public class Battle : State
{
    private StateMachine stateMachine;
    private GameController gameController;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        Debug.Log("Enter");
    }

    public override void Act()
    {
        Debug.Log("Act");
    }

    public override void Reason()
    {
        Debug.Log("Reason");

    }

}