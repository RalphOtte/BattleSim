using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Battle : State
{
    private StateMachine stateMachine;
    private GameController gameController;
    private TextController textController;
    private Govern govern;
    public Player p1;
    public Player p2;

    public GameObject battleScreen;

    private bool battleSequence;
    private bool atkSequenceDone;
    private bool defSequenceDone;

    public int attackingPlayer; //Each number corresponds to player number, 1 = P1 etc.
    public int defendingPlayer; //Each number corresponds to player number, 2 = P2 etc.

    //Attacking Troops
    private float atkTroopCount; //How many troops the attacking player has
    private float atkTroopPower; //How many power the troops of the attacking player has
    private float atkTroopDifferential; //How many times more/less troops the attacking player has over the defending player
    private float atkTotalPower; //Total power of the attacking player after all calculations
    //Old troop count
    private float atkPeasantCountOld;
    private float atkFootmanCountOld;
    private float atkBowmanCountOld;
    private float atkKnightCountOld;
    private float atkLancerCountOld;
    //These integers will subtract the losses from the player after the battle is done
    public float atkPeasantLost;
    public float atkFootmanLost;
    public float atkBowmanLost;
    public float atkKnightLost;
    public float atkLancerLost;
    //Defending Troops
    private float defTroopCount; //How many troops the defending player has
    private float defTroopPower; //How many power the troops of the defending player has
    private float defDefenseBonus; //WallBonus
    private float defTotalPower; //Total power of the defending player after all calculations
    //Old troop count
    private float defPeasantCountOld;
    private float defFootmanCountOld;
    private float defBowmanCountOld;
    private float defKnightCountOld;
    private float defLancerCountOld;
    //These integers will subtract the losses from the player after the battle is done
    public float defPeasantLost;
    public float defFootmanLost;
    public float defBowmanLost;
    public float defKnightLost;
    public float defLancerLost;

    private List<int> atkList;
    private List<int> defList;

    //Player 1 unit texts
    public GUIText p1PeasantText;
    public GUIText p1FootmanText;
    public GUIText p1BowmanText;
    public GUIText p1KnightText;
    public GUIText p1LancerText;

    //Player 2 unit texts
    public GUIText p2PeasantText;
    public GUIText p2FootmanText;
    public GUIText p2BowmanText;
    public GUIText p2KnightText;
    public GUIText p2LancerText;

    public override void Enter()
    {
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"
        //MIGRATE UPDATEBOARD TO "GOVERN.CS"

        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        textController = GetComponent<TextController>();
        govern = GetComponent<Govern>();
        Debug.Log("Entering Battle Phase");
        battleScreen.SetActive(true);
        FillArmyLists();
        ImportArmies();
    }

    public override void Act()
    {
        if (battleSequence == true)
        {
            BattleSequence();
        }
        else { }

        //Debug.Log(defTotalPower + "DefTotalPower ACT");
    }

    public override void Reason()
    {
    }

    public void UpdateBoard()
    {
        p1PeasantText.text = "" + p1.peasantCount;
        p1FootmanText.text = "" + p1.footmanCount;
        p1BowmanText.text = "" + p1.bowmanCount;
        p1KnightText.text = "" + p1.knightCount;
        p1LancerText.text = "" + p1.lancerCount;

        p2PeasantText.text = "" + p2.peasantCount;
        p2FootmanText.text = "" + p2.footmanCount;
        p2BowmanText.text = "" + p2.bowmanCount;
        p2KnightText.text = "" + p2.knightCount;
        p2LancerText.text = "" + p2.lancerCount;

        Debug.Log("Troop Board Updated");
    }

    void FillArmyLists()
    {
        //Copy army lists directly from player
        if (attackingPlayer == 1)
        {
            atkList = new List<int>(gameController.p1.armyList);
            defList = new List<int>(gameController.p2.armyList);
        }
        else if (attackingPlayer == 2)
        {
            atkList = new List<int>(gameController.p2.armyList);
            defList = new List<int>(gameController.p1.armyList);
        }
        Debug.Log("Entering Battle Sequence");
    }

    void ImportArmies()
    {
        if (attackingPlayer == 1)
        {
            textController.attackerPlayer.text = "Player 1";
            textController.defenderPlayer.text = "Player 2";
            //Update all previous Troop texts before all calculations
            atkPeasantCountOld = gameController.p1.peasantCount;
            atkFootmanCountOld = gameController.p1.footmanCount;
            atkBowmanCountOld = gameController.p1.bowmanCount;
            atkKnightCountOld = gameController.p1.knightCount;
            atkLancerCountOld = gameController.p1.lancerCount;

            defPeasantCountOld = gameController.p2.peasantCount;
            defFootmanCountOld = gameController.p2.footmanCount;
            defBowmanCountOld = gameController.p2.bowmanCount;
            defKnightCountOld = gameController.p2.knightCount;
            defLancerCountOld = gameController.p2.lancerCount;

            atkTroopCount = gameController.p1.armySize;
            atkTroopPower = gameController.p1.armyPower;

            defTroopCount = gameController.p2.armySize;
            defTroopPower = gameController.p2.armyPower;
            defDefenseBonus = gameController.p2.wallCurrentBonus;
        }
        else if (attackingPlayer == 2)
        {
            textController.attackerPlayer.text = "Player 2";
            textController.defenderPlayer.text = "Player 1";
            atkPeasantCountOld = gameController.p2.peasantCount;
            atkFootmanCountOld = gameController.p2.footmanCount;
            atkBowmanCountOld = gameController.p2.bowmanCount;
            atkKnightCountOld = gameController.p2.knightCount;
            atkLancerCountOld = gameController.p2.lancerCount;

            defPeasantCountOld = gameController.p1.peasantCount;
            defFootmanCountOld = gameController.p1.footmanCount;
            defBowmanCountOld = gameController.p1.bowmanCount;
            defKnightCountOld = gameController.p1.knightCount;
            defLancerCountOld = gameController.p1.lancerCount;

            atkTroopCount = gameController.p2.armySize;
            atkTroopPower = gameController.p2.armyPower;

            defTroopCount = gameController.p1.armySize;
            defTroopPower = gameController.p1.armyPower;
            defDefenseBonus = gameController.p1.wallCurrentBonus;
        }
        //When this method is done:
        CalculateArmyPowers();
    }

    void CalculateArmyPowers()
    {
        //Determine Attacking troops power
        Debug.Log(atkTroopCount + "atk" + defTroopCount + "def");
        atkTroopDifferential = atkTroopCount / defTroopCount;
        atkTotalPower = atkTroopPower * atkTroopDifferential;
        Debug.Log("atkTotPow" + atkTotalPower);
        Debug.Log("atk troop diff" + atkTroopDifferential);


        defTotalPower = Mathf.RoundToInt(defTroopPower/* +( defTroopPower * (defDefenseBonus / 100))*/);
        Debug.Log("defTotPow" + defTotalPower);

        battleSequence = true;
    }

    void BattleSequence()
    {
        //Debug.Log(defTotalPower + "DefTot" + atkList[0] + "atklist");
        if (defTotalPower > atkList[0] && atkList.Count >= 0)
        {
            Debug.Log("Attack Battle Sequence");
            int randomIndex = Random.Range(0, atkList.Count);
            int randomIndexRealValue = atkList[randomIndex];
            CheckKillAtk(randomIndex);
            defTotalPower -= randomIndexRealValue;
            //Remove from list
            if (attackingPlayer == 1)
            {
                if (randomIndexRealValue == gameController.p1.peasantHealth)
                {
                    atkPeasantLost++;
                }
                else if (randomIndexRealValue == gameController.p1.footmanHealth) { atkFootmanLost++; }
                else if (randomIndexRealValue == gameController.p1.bowmanHealth) { atkBowmanLost++; }
                else if (randomIndexRealValue == gameController.p1.knightHealth) { atkKnightLost++; }
                else if (randomIndexRealValue == gameController.p1.lancerHealth) { atkLancerLost++; }
            }
            else if (attackingPlayer == 2)
            {
                if (randomIndexRealValue == gameController.p2.peasantHealth)
                {
                    atkPeasantLost++;
                }
                else if (randomIndexRealValue == gameController.p2.footmanHealth) { atkFootmanLost++; }
                else if (randomIndexRealValue == gameController.p2.bowmanHealth) { atkBowmanLost++; }
                else if (randomIndexRealValue == gameController.p2.knightHealth) { atkKnightLost++; }
                else if (randomIndexRealValue == gameController.p2.lancerHealth) { atkLancerLost++; }
            }
                
        }
        else { defSequenceDone = true; }
        if (defList.Count > 0 && atkTotalPower > defList[0])
        {
            Debug.Log("Defense Battle Sequence");
            int randomIndex = Random.Range(0, defList.Count);
            int randomIndexRealValue = defList[randomIndex];
            CheckKillDef(randomIndex);
            atkTotalPower -= randomIndexRealValue;
            if (attackingPlayer == 1)
            {
                if (randomIndexRealValue == gameController.p2.peasantHealth)
                {
                    defPeasantLost++;
                }
                else if (randomIndexRealValue == gameController.p2.footmanHealth) { defFootmanLost++; }
                else if (randomIndexRealValue == gameController.p2.bowmanHealth) { defBowmanLost++; }
                else if (randomIndexRealValue == gameController.p2.knightHealth) { defKnightLost++; }
                else if (randomIndexRealValue == gameController.p2.lancerHealth) { defLancerLost++; }
            }
            else if (attackingPlayer == 2)
            {
                if (randomIndexRealValue == gameController.p1.peasantHealth)
                {
                    defPeasantLost++;
                }
                else if (randomIndexRealValue == gameController.p1.footmanHealth) { defFootmanLost++; }
                else if (randomIndexRealValue == gameController.p1.bowmanHealth) { defBowmanLost++; }
                else if (randomIndexRealValue == gameController.p1.knightHealth) { defKnightLost++; }
                else if (randomIndexRealValue == gameController.p1.lancerHealth) { defLancerLost++; }
            }
                
        }
        else { atkSequenceDone = true; }

        if (atkSequenceDone == true && defSequenceDone == true)
        {
            //End the battle sequence if both lists/armies are depleted
            battleSequence = false;
            ShowBattleResults();
        }
    }

    void CheckKillAtk(int randomIndex)
    {
        //All killed attacking troops will come here
        atkList.RemoveAt(randomIndex);
        //Killcounter van geselecteerde troop omhoog
    }

    void CheckKillDef(int randomIndex)
    {
        //All killed defending troops will come here
        defList.RemoveAt(randomIndex);
    }

    void ShowBattleResults()
    {
        Debug.Log("ShowBattleResults");
        if (attackingPlayer == 1)
        {
            //Player 1
            gameController.p1.peasantCount -= Mathf.RoundToInt(atkPeasantLost);
            gameController.p1.footmanCount -= Mathf.RoundToInt(atkFootmanLost);
            gameController.p1.bowmanCount -= Mathf.RoundToInt(atkBowmanLost);
            gameController.p1.knightCount -= Mathf.RoundToInt(atkKnightLost);
            gameController.p1.lancerCount -= Mathf.RoundToInt(atkLancerLost);
            //Player 2
            gameController.p2.peasantCount -= Mathf.RoundToInt(defPeasantLost);
            gameController.p2.footmanCount -= Mathf.RoundToInt(defFootmanLost);
            gameController.p2.bowmanCount -= Mathf.RoundToInt(defBowmanLost);
            gameController.p2.knightCount -= Mathf.RoundToInt(defKnightLost);
            gameController.p2.lancerCount -= Mathf.RoundToInt(defLancerLost);
        }
        else if (attackingPlayer == 2)
        {
            //Player 2
            gameController.p2.peasantCount -= Mathf.RoundToInt(atkPeasantLost);
            gameController.p2.footmanCount -= Mathf.RoundToInt(atkFootmanLost);
            gameController.p2.bowmanCount -= Mathf.RoundToInt(atkBowmanLost);
            gameController.p2.knightCount -= Mathf.RoundToInt(atkKnightLost);
            gameController.p2.lancerCount -= Mathf.RoundToInt(atkLancerLost);
            //Player 1
            gameController.p1.peasantCount -= Mathf.RoundToInt(defPeasantLost);
            gameController.p1.footmanCount -= Mathf.RoundToInt(defFootmanLost);
            gameController.p1.bowmanCount -= Mathf.RoundToInt(defBowmanLost);
            gameController.p1.knightCount -= Mathf.RoundToInt(defKnightLost);
            gameController.p1.lancerCount -= Mathf.RoundToInt(defLancerLost);
        }

        //Show old Atk***Count & Def***Count at the top row (Previous number of troops)
        textController.battleAtkPeasantCountOld.text = atkPeasantCountOld.ToString();
        textController.battleAtkFootmanCountOld.text = atkFootmanCountOld.ToString();
        textController.battleAtkBowmanCountOld.text = atkBowmanCountOld.ToString();
        textController.battleAtkKnightCountOld.text = atkKnightCountOld.ToString();
        textController.battleAtkLancerCountOld.text = atkLancerCountOld.ToString();

        textController.battleDefPeasantCountOld.text = defPeasantCountOld.ToString();
        textController.battleDefFootmanCountOld.text = defFootmanCountOld.ToString();
        textController.battleDefBowmanCountOld.text = defBowmanCountOld.ToString();
        textController.battleDefKnightCountOld.text = defKnightCountOld.ToString();
        textController.battleDefLancerCountOld.text = defLancerCountOld.ToString();


        //Show new Atk***Count & Def***Count at the bottom row (New number of troops)
        textController.battleAtkPeasantCountNew.text = (atkPeasantCountOld - atkPeasantLost).ToString();
        textController.battleAtkFootmanCountNew.text = (atkFootmanCountOld - atkFootmanLost).ToString();
        textController.battleAtkBowmanCountNew.text = (atkBowmanCountOld - atkBowmanLost).ToString();
        textController.battleAtkKnightCountNew.text = (atkKnightCountOld - atkKnightLost).ToString();
        textController.battleAtkLancerCountNew.text = (atkLancerCountOld - atkLancerLost).ToString();

        textController.battleDefPeasantCountNew.text = (defPeasantCountOld - defPeasantLost).ToString();
        textController.battleDefFootmanCountNew.text = (defFootmanCountOld - defFootmanLost).ToString();
        textController.battleDefBowmanCountNew.text = (defBowmanCountOld - defBowmanLost).ToString();
        textController.battleDefKnightCountNew.text = (defKnightCountOld - defKnightLost).ToString();
        textController.battleDefLancerCountNew.text = (defLancerCountOld - defLancerLost).ToString();

        //Shows battle results with a projected "winner" of the battle.
        //Shows lost troops of both sides
    }

    void CleanTroopCounts()
    {
        //Set all troops that are below 0 to 0
        if (gameController.p1.peasantCount <= 0)
        {
            gameController.p1.peasantCount = 0;
        }
        if (gameController.p1.footmanCount <= 0)
        {
            gameController.p1.footmanCount = 0;
        }
        if (gameController.p1.bowmanCount <= 0)
        {
            gameController.p1.bowmanCount = 0;
        }
        if (gameController.p1.knightCount <= 0)
        {
            gameController.p1.knightCount = 0;
        }
        if (gameController.p1.lancerCount <= 0)
        {
            gameController.p1.lancerCount = 0;
        }

        if (gameController.p2.peasantCount <= 0)
        {
            gameController.p2.peasantCount = 0;
        }
        if (gameController.p2.footmanCount <= 0)
        {
            gameController.p2.footmanCount = 0;
        }
        if (gameController.p2.bowmanCount <= 0)
        {
            gameController.p2.bowmanCount = 0;
        }
        if (gameController.p2.knightCount <= 0)
        {
            gameController.p2.knightCount = 0;
        }
        if (gameController.p2.lancerCount <= 0)
        {
            gameController.p2.lancerCount = 0;
        }
    }

    public void EndBattle()
    {
        CleanTroopCounts();
        if (attackingPlayer == 1)
        {
            if (gameController.p1.peasantCount >= 0 &&
                gameController.p1.footmanCount >= 0 &&
                gameController.p1.bowmanCount >= 0 &&
                gameController.p1.knightCount >= 0 &&
                gameController.p1.lancerCount >= 0)
            {
                govern.EndTurn();
            }
            else if (gameController.p2.peasantCount >= 0 &&
                    gameController.p2.footmanCount >= 0 &&
                    gameController.p2.bowmanCount >= 0 &&
                    gameController.p2.knightCount >= 0 &&
                    gameController.p2.lancerCount >= 0)
            {
                govern.winningPlayer = 1;
                govern.GameOver();
            }

        }
        else if (attackingPlayer == 2)
        {
            if (gameController.p2.peasantCount >= 0 &&
                gameController.p2.footmanCount >= 0 &&
                gameController.p2.bowmanCount >= 0 &&
                gameController.p2.knightCount >= 0 &&
                gameController.p2.lancerCount >= 0)
            {
                govern.EndTurn();
            }
            else if (gameController.p1.peasantCount >= 0 &&
                    gameController.p1.footmanCount >= 0 &&
                    gameController.p1.bowmanCount >= 0 &&
                    gameController.p1.knightCount >= 0 &&
                    gameController.p1.lancerCount >= 0)
            {
                govern.winningPlayer = 2;
                govern.GameOver();
            }
        }
    }

    public override void Leave()
    {
        gameController.p1.EmptyArmyList();
        gameController.p1.UpdateArmy();
        gameController.p1.UpdateArmyPower();
        gameController.p1.UpdateArmySize();
        gameController.p2.EmptyArmyList();
        gameController.p2.UpdateArmy();
        gameController.p2.UpdateArmyPower();
        gameController.p2.UpdateArmySize();
        battleScreen.SetActive(false);
    }
}