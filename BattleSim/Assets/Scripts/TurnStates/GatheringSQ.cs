using UnityEngine;
using System.Collections;

public class GatheringSQ : State {

    private StateMachine stateMachine;
    private GameController gameController;
    private TextController textController;

    public GameObject gatheringSQ;
    public GameObject menu;
    public GameObject confirmScreen;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        textController = GetComponent<TextController>();
        Debug.Log("Entering GatheringSQ Phase");
        gatheringSQ.SetActive(true);
        confirmScreen.SetActive(false);
        UpdateTroopInfo();
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public void UpdateTroopInfo()
    {
        if (gameController.playerTurn == 1)
        {
            textController.gatheringPeasantCount.text = gameController.p1.peasantCount.ToString();
            textController.gatheringFootmanCount.text = gameController.p1.footmanCount.ToString();
            textController.gatheringBowmanCount.text = gameController.p1.bowmanCount.ToString();
            textController.gatheringKnightCount.text = gameController.p1.knightCount.ToString();
            textController.gatheringLancerCount.text = gameController.p1.lancerCount.ToString();
        }
        else if (gameController.playerTurn == 2)
        {
            textController.gatheringPeasantCount.text = gameController.p2.peasantCount.ToString();
            textController.gatheringFootmanCount.text = gameController.p2.footmanCount.ToString();
            textController.gatheringBowmanCount.text = gameController.p2.bowmanCount.ToString();
            textController.gatheringKnightCount.text = gameController.p2.knightCount.ToString();
            textController.gatheringLancerCount.text = gameController.p2.lancerCount.ToString();
        }
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
