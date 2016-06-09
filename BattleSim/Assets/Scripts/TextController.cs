using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    //How To Play

    //General
    private GameController gameController;

    //Banner
    public Image playerColor;
    public Text playerTurn;
    public Text turnText;
    public Text money;
    public Text wallText;
    public Text troopText;
    public Text PCount;
    public Text FCount;
    public Text BCount;
    public Text KCount;
    public Text LCount;

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
    public Text palaceCurrentLevel;
    public Text barracksCurrentLevel;
    public Text wallCurrentLevel;
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

    //BattleResults
    public Text attackerPlayer;
    public Text defenderPlayer;
    public Text battleAtkPeasantCountOld;
    public Text battleAtkFootmanCountOld;
    public Text battleAtkBowmanCountOld;
    public Text battleAtkKnightCountOld;
    public Text battleAtkLancerCountOld;
    public Text battleAtkPeasantCountNew;
    public Text battleAtkFootmanCountNew;
    public Text battleAtkBowmanCountNew;
    public Text battleAtkKnightCountNew;
    public Text battleAtkLancerCountNew;

    public Text battleDefPeasantCountOld;
    public Text battleDefFootmanCountOld;
    public Text battleDefBowmanCountOld;
    public Text battleDefKnightCountOld;
    public Text battleDefLancerCountOld;
    public Text battleDefPeasantCountNew;
    public Text battleDefFootmanCountNew;
    public Text battleDefBowmanCountNew;
    public Text battleDefKnightCountNew;
    public Text battleDefLancerCountNew;

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

    public void UpdateBannerP1()
    {
        PCount.text = gameController.p1.peasantCount.ToString();
        FCount.text = gameController.p1.footmanCount.ToString();
        BCount.text = gameController.p1.bowmanCount.ToString();
        KCount.text = gameController.p1.knightCount.ToString();
        LCount.text = gameController.p1.lancerCount.ToString();
        wallText.text = "Wall Bonus: " + gameController.p1.wallCurrentBonus.ToString() + "%";
        playerColor.color = Color.red;
        troopText.text = "Troops per order: " + gameController.p1.barracksLevel.ToString();
    }

    public void UpdateBannerP2()
    {
        PCount.text = gameController.p2.peasantCount.ToString();
        FCount.text = gameController.p2.footmanCount.ToString();
        BCount.text = gameController.p2.bowmanCount.ToString();
        KCount.text = gameController.p2.knightCount.ToString();
        LCount.text = gameController.p2.lancerCount.ToString();
        wallText.text = "Wall Bonus: " + gameController.p2.wallCurrentBonus.ToString() + "%";
        playerColor.color = Color.blue;
        troopText.text = "Troops per order: " + gameController.p2.barracksLevel.ToString();
    }

    public void UpdateBarracksProductionP1()
    {
        barracksCurrentProduction.text = gameController.p1.barracksLevelText;
    }

    public void UpdateBarracksProductionP2()
    {
        barracksCurrentProduction.text = gameController.p2.barracksLevelText;
    }

    public void UpdateBuildersHutP1()
    {
        palaceCurrentLevel.text = gameController.p1.palaceLevel + "/" + gameController.p1.palaceMaxLevel;
        barracksCurrentLevel.text = gameController.p1.barracksLevel + "/" + gameController.p1.barracksMaxLevel;
        wallCurrentLevel.text = gameController.p1.wallLevel + "/" + gameController.p1.wallMaxLevel;

        palaceUpgradeCost.text = gameController.p1.palaceUpgradeCostText;
        barracksUpgradeCost.text = gameController.p1.barracksUpgradeCostText;
        wallUpgradeCost.text = gameController.p1.wallUpgradeCostText;
    }

    public void UpdateBuildersHutP2()
    {
        palaceCurrentLevel.text = gameController.p2.palaceLevel + "/" + gameController.p2.palaceMaxLevel;
        barracksCurrentLevel.text = gameController.p2.barracksLevel + "/" + gameController.p2.barracksMaxLevel;
        wallCurrentLevel.text = gameController.p2.wallLevel + "/" + gameController.p2.wallMaxLevel;

        palaceUpgradeCost.text = gameController.p2.palaceUpgradeCostText;
        barracksUpgradeCost.text = gameController.p2.barracksUpgradeCostText;
        wallUpgradeCost.text = gameController.p2.wallUpgradeCostText;
    }
}