using UnityEngine;
using System.Collections;

public class Upgrade : State {

    private StateMachine stateMachine;
    private GameController gameController;

    public GameObject buildersHut;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        buildersHut.SetActive(true);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public override void Leave()
    {
        buildersHut.SetActive(false);
    }
}
