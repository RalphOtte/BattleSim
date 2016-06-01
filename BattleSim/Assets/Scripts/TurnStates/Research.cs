using UnityEngine;
using System.Collections;

public class Research : State {

    private StateMachine stateMachine;
    private GameController gameController;

    public GameObject academy;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        academy.SetActive(true);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public override void Leave()
    {
        academy.SetActive(false);
    }
}
