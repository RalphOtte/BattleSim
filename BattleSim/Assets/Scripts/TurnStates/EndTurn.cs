using UnityEngine;
using System.Collections;

public class EndTurn : State {

    private StateMachine stateMachine;
    private GameController gameController;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        Debug.Log("Ending Turn");
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public override void Leave()
    {
        if (gameController.p1.safePhaseTurns >= 0)
        { gameController.p1.safePhaseTurns--; }
        else if (gameController.p2.safePhaseTurns >= 0)
        { gameController.p2.safePhaseTurns--; }
    }
}
