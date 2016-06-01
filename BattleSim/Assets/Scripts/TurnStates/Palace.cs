using UnityEngine;
using System.Collections;
using System;

public class Palace : State
{

    private StateMachine stateMachine;
    private GameController gameController;

    public GameObject palace;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        palace.SetActive(true);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public override void Leave()
    {
        palace.SetActive(false);
    }
}
