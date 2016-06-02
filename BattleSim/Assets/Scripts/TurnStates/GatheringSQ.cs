using UnityEngine;
using System.Collections;

public class GatheringSQ : State {

    private StateMachine stateMachine;
    private GameController gameController;

    public GameObject gatheringSQ;
    public GameObject menu;
    public GameObject confirmScreen;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        Debug.Log("Entering GatheringSQ Phase");
        gatheringSQ.SetActive(true);
        confirmScreen.SetActive(false);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public void ConfirmScreen()
    {
        menu.SetActive(false);
        confirmScreen.SetActive(true);
    }

    public void ConfirmBattle()
    {

    }

    public void CancelBattle()
    {
        menu.SetActive(true);
        confirmScreen.SetActive(false);
    }

    public override void Leave()
    {
        gatheringSQ.SetActive(false);
    }

}
