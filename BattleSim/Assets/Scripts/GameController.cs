using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StateID
{
    NullStateID = 0,
    MatchSetup = 1,
    DetermineFirstTurn = 2,
    Initialization = 3,
    Govern = 4,
    Train = 5,
    Upgrade = 6,
    Research = 7,
    Battle = 8,
    BattleResult = 9,
    EndTurn = 10,
    Palace = 11,
    GatheringSQ = 12,
    Wall = 13
}

public class GameController : MonoBehaviour
{
    private StateMachine stateMachine;
    public int playerTurn;
    public int playerWin;
    public Player p1;
    public Player p2;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        /** Add all states to the state machine */
        MakeStates();

        /** First state in the scene is "MatchSetup" */
        stateMachine.SetState(StateID.Govern);
    }

    void MakeStates()
    {
        stateMachine.AddState(StateID.MatchSetup, GetComponent<MatchSetup>());
        stateMachine.AddState(StateID.DetermineFirstTurn, GetComponent<DetermineFirstTurn>());
        stateMachine.AddState(StateID.Initialization, GetComponent<Initialization>());
        stateMachine.AddState(StateID.Govern, GetComponent<Govern>());
        stateMachine.AddState(StateID.Train, GetComponent<Train>());
        stateMachine.AddState(StateID.Upgrade, GetComponent<Upgrade>());
        stateMachine.AddState(StateID.Research, GetComponent<Research>());
        stateMachine.AddState(StateID.Battle, GetComponent<Battle>());
        stateMachine.AddState(StateID.BattleResult, GetComponent<BattleResult>());
        stateMachine.AddState(StateID.EndTurn, GetComponent<EndTurn>());
        stateMachine.AddState(StateID.Palace, GetComponent<Palace>());
        stateMachine.AddState(StateID.GatheringSQ, GetComponent<GatheringSQ>());
        stateMachine.AddState(StateID.Wall, GetComponent<Wall>());

        Debug.Log("Made States and Got Components");
    }
}