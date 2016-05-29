using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

    public Player p1;
    public Player p2;

    //All bools used to flag whether player has higher than 0 of a kind of unit
    bool p1HasPeasant;
    bool p1HasFootman;
    bool p1HasBowman;
    bool p1HasKnight;
    bool p1HasLancer;
    bool p1HasWall;

    bool p2HasPeasant;
    bool p2HasFootman;
    bool p2HasBowman;
    bool p2HasKnight;
    bool p2HasLancer;
    bool p2HasWall;

    //ALL UNIT STATS COME HERE

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

        Debug.Log("Board Updated");
    }
}
