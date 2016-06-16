using UnityEngine;
using System.Collections;

public class Initialization : State
{
    private StateMachine stateMachine;
    private GameController gameController;
    private TextController textController;

    public GameObject palace;
    public GameObject incomeAnimation;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        textController = GetComponent<TextController>();
        Debug.Log("Entering Turn Initialization Phase");
        if (gameController.playerTurn == 1)
        {
            gameController.p1.money += gameController.p1.palaceCurrentIncome;
            gameController.p1.convertInfoIntToString();
            if (gameController.p1.safePhaseTurns >= 0)
            {
                gameController.p1.safePhaseTurns--;
            }
            textController.playerTurn.text = "Player 1's turn";
            textController.UpdateP1Money();
            textController.UpdateBannerP1();
        }
        else if(gameController.playerTurn == 2)
        {
            gameController.p2.money += gameController.p2.palaceCurrentIncome;
            gameController.p2.convertInfoIntToString();
            if (gameController.p2.safePhaseTurns >= 0)
            {
                gameController.p2.safePhaseTurns--;
            }
            textController.playerTurn.text = "Player 2's turn";
            textController.UpdateP2Money();
            textController.UpdateBannerP2();
        }
        Instantiate(incomeAnimation, palace.transform.position, Quaternion.identity);
        stateMachine.SetState(StateID.Govern);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

}