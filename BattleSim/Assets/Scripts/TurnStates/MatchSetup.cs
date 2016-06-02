using UnityEngine;
using System.Collections;
using System;

public class MatchSetup : State {

    private StateMachine stateMachine;
    private GameController gameController;

    public GameObject matchSetup;

    public override void Enter ()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        Debug.Log("Entering MatchSetup Phase");
        matchSetup.SetActive(true);
    }
	
	public override void Act ()
    {
	}

    public override void Reason()
    {
    }

    public void EnableSafePhase()
    {
        gameController.p1.safePhaseTurns = 10;
        gameController.p2.safePhaseTurns = 10;
        ContinueToDetermineFirstTurn();
    }

    public void DisableSafePhase()
    {
        gameController.p1.safePhaseTurns = 0;
        gameController.p2.safePhaseTurns = 0;
        ContinueToDetermineFirstTurn();
    }

    void ContinueToDetermineFirstTurn()
    {
        matchSetup.SetActive(false);
        stateMachine.SetState(StateID.DetermineFirstTurn);
    }
}
