using UnityEngine;
using System.Collections;
using System;

public class Wall : State {

    private StateMachine stateMachine;
    private GameController gameController;
    private TextController textController;

    public GameObject wall;
    [SerializeField]private GameObject unitData;

    private int totalTroopCount;
    private int subTotalTroopDefense;
    private int totalTroopDefense;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        textController = GetComponent<TextController>();
        Debug.Log("Entering Wall Phase");
        wall.SetActive(true);
        UpdateWallInfo();
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

    void UpdateWallInfo()
    {
        if (gameController.playerTurn == 1)
        {
            textController.wallCurrentBonus.text = "Current Bonus: " + gameController.p1.wallCurrentBonus + "%";
            textController.wallNextBonus.text = "Next Bonus: " + gameController.p1.wallNextBonus + "%";
        }

        if (gameController.playerTurn == 2)
        {
            textController.wallCurrentBonus.text = "Current Bonus: " + gameController.p2.wallCurrentBonus + "%";
            textController.wallNextBonus.text = "Next Bonus: " + gameController.p2.wallNextBonus + "%";
        }
    }
}
