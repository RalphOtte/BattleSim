using UnityEngine;
using System.Collections;

public class Initialization : State
{
    private StateMachine stateMachine;
    private GameController gameController;
    private TextController textController;
    private Govern govern;
    public Player p1;
    public Player p2;

    public GameObject palace;
    public GameObject incomeAnimation;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        textController = GetComponent<TextController>();
        govern = GetComponent<Govern>();
        UpdatePlayerIncome();
        CheckGameOver();
        Debug.Log("Entering Turn Initialization Phase");
        
        stateMachine.SetState(StateID.Govern);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    void UpdatePlayerIncome()
    {
        p1.UpdatePalaceIncome();
        p2.UpdatePalaceIncome();
    }

    void CheckGameOver()
    {
        if (govern.gameOver == true)
        {
            stateMachine.SetState(StateID.Govern);
        }
        else { AddIncome(); }
    }

    void AddIncome()
    {
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
        else if (gameController.playerTurn == 2)
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
    }
}