using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    //How To Play

    //General
    private GameController gameController;

    //Govern
    public Text playerTurn;
    public Text money;

    //Palace
    public Text palaceIncomeCurrent;
    public Text palaceIncomeNext;
    public Text UnitsTrainedPerOrder;
    public Text footmanUnlockedText;
    public Text bowmanUnlockedText;
    public Text knightUnlockedText;
    public Text lancerUnlockedText;
    public Text wallUnlockedText;

    //Barracks
    public Text barracksCurrentProduction;
    public Text barracksNextProduction;
    public Text barracksPeasantCount;
    public Text barracksFootmanCount;
    public Text barracksBowmanCount;
    public Text barracksKnightCount;
    public Text barracksLancerCount;

    //Builders Hut
    public Text palaceUpgradeCost;
    public Text barracksUpgradeCost;
    public Text wallUpgradeCost;

    //Wall
    public Text wallCurrentBonus;
    public Text wallNextBonus;

    //GatheringSquare
    public Text gatheringPeasantCount;
    public Text gatheringFootmanCount;
    public Text gatheringBowmanCount;
    public Text gatheringKnightCount;
    public Text gatheringLancerCount;

    void Start()
    {
        gameController = GetComponent<GameController>();
    }


    public void UpdateP1Money()
    {
        gameController.p1.convertInfoIntToString();
        money.text = "Money: " + gameController.p1.moneyString;
    }

    public void UpdateP2Money()
    {
        gameController.p2.convertInfoIntToString();
        money.text = "Money: " + gameController.p2.moneyString;
    }
}
