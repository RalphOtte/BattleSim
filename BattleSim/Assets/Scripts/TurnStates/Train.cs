using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Train : State {

    private StateMachine stateMachine;
    private GameController gameController;
    private TextController textController;

    public GameObject barracks;

    public int peasantTrainCost;
    public int footmanTrainCost;
    public int bowmanTrainCost;
    public int knightTrainCost;
    public int lancerTrainCost;

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        textController = GetComponent<TextController>();
        Debug.Log("Entering Train Phase");
        barracks.SetActive(true);
        UpdateBarracksInfo();
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    void UpdateBarracksInfo()
    {
        if (gameController.playerTurn == 1)
        {
            textController.barracksPeasantCount.text = gameController.p1.peasantCount.ToString();
            textController.barracksFootmanCount.text = gameController.p1.footmanCount.ToString();
            textController.barracksBowmanCount.text = gameController.p1.bowmanCount.ToString();
            textController.barracksKnightCount.text = gameController.p1.knightCount.ToString();
            textController.barracksLancerCount.text = gameController.p1.lancerCount.ToString();
        }

        if (gameController.playerTurn == 2)
        {
            textController.barracksPeasantCount.text = gameController.p2.peasantCount.ToString();
            textController.barracksFootmanCount.text = gameController.p2.footmanCount.ToString();
            textController.barracksBowmanCount.text = gameController.p2.bowmanCount.ToString();
            textController.barracksKnightCount.text = gameController.p2.knightCount.ToString();
            textController.barracksLancerCount.text = gameController.p2.lancerCount.ToString();
        }
    }

    //All Training Options
    public void TrainPeasant()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= peasantTrainCost)
            {
                gameController.p1.money -= peasantTrainCost;
                gameController.p1.peasantCount = gameController.p1.peasantCount + (1 * gameController.p1.barracksLevel);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= peasantTrainCost)
            {
                gameController.p2.money -= peasantTrainCost;
                gameController.p2.peasantCount = gameController.p2.peasantCount + (1 * gameController.p2.barracksLevel);
            }
        }
        //UpdateMoneyTexts();
        //battle.UpdateBoard();
    }

    public void TrainFootman()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= footmanTrainCost && gameController.p1.footmanUnlocked)
            {
                gameController.p1.money -= footmanTrainCost;
                gameController.p1.footmanCount = gameController.p1.footmanCount + (1 * gameController.p1.barracksLevel);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= footmanTrainCost && gameController.p2.footmanUnlocked)
            {
                gameController.p2.money -= footmanTrainCost;
                gameController.p2.footmanCount = gameController.p2.footmanCount + (1 * gameController.p2.barracksLevel);
            }
        }
        //UpdateMoneyTexts();
        //battle.UpdateBoard();
    }

    public void TrainBowman()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= bowmanTrainCost && gameController.p1.bowmanUnlocked)
            {
                gameController.p1.money -= bowmanTrainCost;
                gameController.p1.bowmanCount = gameController.p1.bowmanCount + (1 * gameController.p1.barracksLevel);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= bowmanTrainCost && gameController.p2.bowmanUnlocked)
            {
                gameController.p2.money -= bowmanTrainCost;
                gameController.p2.bowmanCount = gameController.p2.bowmanCount + (1 * gameController.p2.barracksLevel);
            }
        }
        //UpdateMoneyTexts();
        //battle.UpdateBoard();
    }

    public void TrainKnight()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= knightTrainCost && gameController.p1.knightUnlocked)
            {
                gameController.p1.money -= knightTrainCost;
                gameController.p1.knightCount = gameController.p1.knightCount + (1 * gameController.p1.barracksLevel);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= knightTrainCost && gameController.p2.knightUnlocked)
            {
                gameController.p2.money -= knightTrainCost;
                gameController.p2.knightCount = gameController.p2.knightCount + (1 * gameController.p2.barracksLevel);
            }
        }
        //UpdateMoneyTexts();
        //battle.UpdateBoard();
    }

    public void TrainLancer()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= lancerTrainCost && gameController.p1.lancerUnlocked)
            {
                gameController.p1.money -= lancerTrainCost;
                gameController.p1.lancerCount = gameController.p1.lancerCount + (1 * gameController.p1.barracksLevel);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= lancerTrainCost && gameController.p2.lancerUnlocked)
            {
                gameController.p2.money -= lancerTrainCost;
                gameController.p2.lancerCount = gameController.p2.lancerCount + (1 * gameController.p2.barracksLevel);
            }
        }
        //UpdateMoneyTexts();
        //battle.UpdateBoard();
    }

    public override void Leave()
    {
        barracks.SetActive(false);
    }

}
