using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Train : State {

    private StateMachine stateMachine;
    private GameController gameController;
    private TextController textController;

    public GameObject barracks;
    public GameObject moneyAnimation;

    public GameObject peasantMoneyAnimation;
    public GameObject footmanMoneyAnimation;
    public GameObject bowmanMoneyAnimation;
    public GameObject knightMoneyAnimation;
    public GameObject lancerMoneyAnimation;

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
            textController.barracksCurrentProduction.text = "Current Production: " + gameController.p1.barracksLevel.ToString();
            textController.barracksNextProduction.text = "Next Level Production: " + (gameController.p1.barracksLevel + 1).ToString();
        }

        if (gameController.playerTurn == 2)
        {
            textController.barracksPeasantCount.text = gameController.p2.peasantCount.ToString();
            textController.barracksFootmanCount.text = gameController.p2.footmanCount.ToString();
            textController.barracksBowmanCount.text = gameController.p2.bowmanCount.ToString();
            textController.barracksKnightCount.text = gameController.p2.knightCount.ToString();
            textController.barracksLancerCount.text = gameController.p2.lancerCount.ToString();
            textController.barracksCurrentProduction.text = "Current Production: " + gameController.p2.barracksLevel.ToString();
            textController.barracksNextProduction.text = "Next Level Production: " + (gameController.p2.barracksLevel + 1).ToString();
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
                textController.UpdateP1Money();
                textController.UpdateBannerP1();
                gameController.p1.UpdateArmy();
                Instantiate(moneyAnimation, peasantMoneyAnimation.transform.position, Quaternion.identity);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= peasantTrainCost)
            {
                gameController.p2.money -= peasantTrainCost;
                gameController.p2.peasantCount = gameController.p2.peasantCount + (1 * gameController.p2.barracksLevel);
                textController.UpdateP2Money();
                textController.UpdateBannerP2();
                gameController.p2.UpdateArmy();
                Instantiate(moneyAnimation, peasantMoneyAnimation.transform.position, Quaternion.identity);
            }
        }
        UpdateBarracksInfo();
    }

    public void TrainFootman()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= footmanTrainCost && gameController.p1.footmanUnlocked)
            {
                gameController.p1.money -= footmanTrainCost;
                gameController.p1.footmanCount = gameController.p1.footmanCount + (1 * gameController.p1.barracksLevel);
                textController.UpdateP1Money();
                textController.UpdateBannerP1();
                gameController.p1.UpdateArmy();
                Instantiate(moneyAnimation, footmanMoneyAnimation.transform.position, Quaternion.identity);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= footmanTrainCost && gameController.p2.footmanUnlocked)
            {
                gameController.p2.money -= footmanTrainCost;
                gameController.p2.footmanCount = gameController.p2.footmanCount + (1 * gameController.p2.barracksLevel);
                textController.UpdateP2Money();
                textController.UpdateBannerP2();
                gameController.p2.UpdateArmy();
                Instantiate(moneyAnimation, footmanMoneyAnimation.transform.position, Quaternion.identity);
            }
        }
        UpdateBarracksInfo();
    }

    public void TrainBowman()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= bowmanTrainCost && gameController.p1.bowmanUnlocked)
            {
                gameController.p1.money -= bowmanTrainCost;
                gameController.p1.bowmanCount = gameController.p1.bowmanCount + (1 * gameController.p1.barracksLevel);
                textController.UpdateP1Money();
                textController.UpdateBannerP1();
                gameController.p1.UpdateArmy();
                Instantiate(moneyAnimation, bowmanMoneyAnimation.transform.position, Quaternion.identity);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= bowmanTrainCost && gameController.p2.bowmanUnlocked)
            {
                gameController.p2.money -= bowmanTrainCost;
                gameController.p2.bowmanCount = gameController.p2.bowmanCount + (1 * gameController.p2.barracksLevel);
                textController.UpdateP2Money();
                textController.UpdateBannerP2();
                gameController.p2.UpdateArmy();
                Instantiate(moneyAnimation, bowmanMoneyAnimation.transform.position, Quaternion.identity);
            }
        }
        UpdateBarracksInfo();
    }

    public void TrainKnight()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= knightTrainCost && gameController.p1.knightUnlocked)
            {
                gameController.p1.money -= knightTrainCost;
                gameController.p1.knightCount = gameController.p1.knightCount + (1 * gameController.p1.barracksLevel);
                textController.UpdateP1Money();
                textController.UpdateBannerP1();
                gameController.p1.UpdateArmy();
                Instantiate(moneyAnimation, knightMoneyAnimation.transform.position, Quaternion.identity);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= knightTrainCost && gameController.p2.knightUnlocked)
            {
                gameController.p2.money -= knightTrainCost;
                gameController.p2.knightCount = gameController.p2.knightCount + (1 * gameController.p2.barracksLevel);
                textController.UpdateP2Money();
                textController.UpdateBannerP2();
                gameController.p2.UpdateArmy();
                Instantiate(moneyAnimation, knightMoneyAnimation.transform.position, Quaternion.identity);
            }
        }
        UpdateBarracksInfo();
    }

    public void TrainLancer()
    {
        if (gameController.playerTurn == 1)
        {
            if (gameController.p1.money >= lancerTrainCost && gameController.p1.lancerUnlocked)
            {
                gameController.p1.money -= lancerTrainCost;
                gameController.p1.lancerCount = gameController.p1.lancerCount + (1 * gameController.p1.barracksLevel);
                textController.UpdateP1Money();
                textController.UpdateBannerP1();
                gameController.p1.UpdateArmy();
                Instantiate(moneyAnimation, lancerMoneyAnimation.transform.position, Quaternion.identity);
            }
        }
        else if (gameController.playerTurn == 2)
        {
            if (gameController.p2.money >= lancerTrainCost && gameController.p2.lancerUnlocked)
            {
                gameController.p2.money -= lancerTrainCost;
                gameController.p2.lancerCount = gameController.p2.lancerCount + (1 * gameController.p2.barracksLevel);
                textController.UpdateP2Money();
                textController.UpdateBannerP2();
                gameController.p2.UpdateArmy();
                Instantiate(moneyAnimation, lancerMoneyAnimation.transform.position, Quaternion.identity);
            }
        }
        UpdateBarracksInfo();
    }

    public override void Leave()
    {
        barracks.SetActive(false);
    }

}
