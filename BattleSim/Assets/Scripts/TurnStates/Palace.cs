using UnityEngine;
using System.Collections;
using System;

public class Palace : State
{

    private StateMachine stateMachine;
    private GameController gameController;
    private TextController textController;

    public GameObject palace;
    

    public override void Enter()
    {
        stateMachine = GetComponent<StateMachine>();
        gameController = GetComponent<GameController>();
        textController = GetComponent<TextController>();
        Debug.Log("Entering Palace Phase");
        palace.SetActive(true);
        UpdatePalaceInfo();
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
    }

    public override void Leave()
    {
        palace.SetActive(false);
    }

    void UpdatePalaceInfo()
    {
        if (gameController.playerTurn == 1)
        {
            textController.palaceIncomeCurrent.text = "Income: "+ gameController.p1.palaceCurrentIncome.ToString();
            textController.palaceIncomeNext.text = "Income next level: " + gameController.p1.palaceNextIncome.ToString();
            textController.UnitsTrainedPerOrder.text = "Units trained per order: " + gameController.p1.barracksLevel.ToString();

            //Check which troops are unlocked
            if (gameController.p1.footmanUnlocked == true)
            {
                textController.footmanUnlockedText.text = "Footman: Yes";
            }else if (gameController.p1.footmanUnlocked == false) { textController.footmanUnlockedText.text = "Footman: No"; }
            if (gameController.p1.bowmanUnlocked == true)
            {
                textController.bowmanUnlockedText.text = "Bowman: Yes";
            }else if (gameController.p1.footmanUnlocked == false) { textController.bowmanUnlockedText.text = "Bowman: No"; }
            if (gameController.p1.knightUnlocked == true)
            {
                textController.knightUnlockedText.text = "Knight: Yes";
            }else if (gameController.p1.footmanUnlocked == false) { textController.knightUnlockedText.text = "Knight: No"; }
            if (gameController.p1.lancerUnlocked == true)
            {
                textController.lancerUnlockedText.text = "Lancer: Yes";
            }else if (gameController.p1.footmanUnlocked == false) { textController.lancerUnlockedText.text = "Lancer: No"; }
            if (gameController.p1.wallUnlocked == true)
            {
                textController.wallUnlockedText.text = "Wall: Yes";
            }else if (gameController.p1.footmanUnlocked == false) { textController.wallUnlockedText.text = "Wall: No"; }
        }

        //Player 2
        if (gameController.playerTurn == 2)
        {
            textController.palaceIncomeCurrent.text = "Income: " + gameController.p2.palaceCurrentIncome.ToString();
            textController.palaceIncomeNext.text = "Income next level: " + gameController.p2.palaceNextIncome.ToString();
            textController.UnitsTrainedPerOrder.text = "Units trained per order: " + gameController.p2.barracksLevel.ToString();

            //Check which troops are unlocked
            if (gameController.p2.footmanUnlocked == true)
            {
                textController.footmanUnlockedText.text = "Footman: Yes";
            }
            else if (gameController.p2.footmanUnlocked == false) { textController.footmanUnlockedText.text = "Footman: No"; }
            if (gameController.p2.bowmanUnlocked == true)
            {
                textController.bowmanUnlockedText.text = "Bowman: Yes";
            }
            else if (gameController.p2.footmanUnlocked == false) { textController.bowmanUnlockedText.text = "Bowman: No"; }
            if (gameController.p2.knightUnlocked == true)
            {
                textController.knightUnlockedText.text = "Knight: Yes";
            }
            else if (gameController.p2.footmanUnlocked == false) { textController.knightUnlockedText.text = "Knight: No"; }
            if (gameController.p2.lancerUnlocked == true)
            {
                textController.lancerUnlockedText.text = "Lancer: Yes";
            }
            else if (gameController.p2.footmanUnlocked == false) { textController.lancerUnlockedText.text = "Lancer: No"; }
            if (gameController.p2.wallUnlocked == true)
            {
                textController.wallUnlockedText.text = "Wall: Yes";
            }
            else if (gameController.p2.footmanUnlocked == false) { textController.wallUnlockedText.text = "Wall: No"; }
        }
    }
}
