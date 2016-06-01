using UnityEngine;
using System.Collections;

public class BattleSimTest : MonoBehaviour {
    //Attacking Side
    private float peasantCountP1 = 18;
    private float footmanCountP1 = 20;
    private float bowmanCountP1 = 30;
    private float knightCountP1 = 12;
    private float lancerCountP1 = 5;

    //DefendingSide
    private float peasantCountP2 = 10;
    private float footmanCountP2 = 33;
    private float bowmanCountP2 = 27;
    private float knightCountP2 = 7;
    private float lancerCountP2 = 4;
    private float wallBonus = 15; // in %

    private float peasantFavor;
    private float footmanFavor;
    private float bowmanFavor;
    private float knightFavor;
    private float lancerFavor;


	void Start () {
        CalculateFavor();
        Debug.Log("Start Favor Calculation");
	}

    void CalculateFavor()
    {
        peasantFavor = peasantCountP1 / peasantCountP2;
        footmanFavor = footmanCountP1 / footmanCountP2;
        bowmanFavor = bowmanCountP1 / bowmanCountP2;
        knightFavor = knightCountP1 / knightCountP2;
        lancerFavor = lancerCountP1 / lancerCountP2;

        Debug.Log(peasantFavor + " peasant ratio");
        Debug.Log(footmanFavor + " footman ratio");
        Debug.Log(bowmanFavor + " bowman ratio");
        Debug.Log(knightFavor + " knight ratio");
        Debug.Log(lancerFavor + " lancer ratio");

    }
}
