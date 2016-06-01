using UnityEngine;
using System.Collections;

public class GatheringSQ : State {

    private StateMachine stateMachine;
    private GameController gameController;

    public GameObject gatheringSQ;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        gatheringSQ.SetActive(true);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public override void Leave()
    {
        gatheringSQ.SetActive(false);
    }
}
