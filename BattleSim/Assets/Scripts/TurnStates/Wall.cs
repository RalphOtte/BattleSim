using UnityEngine;
using System.Collections;
using System;

public class Wall : State {

    private StateMachine stateMachine;
    private GameController gameController;

    public GameObject wall;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        wall.SetActive(true);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public override void Leave()
    {
        wall.SetActive(false);
    }
}
