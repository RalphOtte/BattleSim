using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StateID
{
    NullStateID = 0,
    DetermineFirstTurn =1,
    Initialization = 2,
    Govern = 3,
    Battle = 4,
}

public class GameController : MonoBehaviour
{
    private StateMachine stateMachine;
    public int playerTurn;
    public Player p1;
    public Player p2;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        /** Add all states to the state machine */
        MakeStates();

        /** First state in the scene is "DetermineFirstTurn" */
        stateMachine.SetState(StateID.DetermineFirstTurn);
    }

    void MakeStates()
    {
        stateMachine.AddState(StateID.DetermineFirstTurn, GetComponent<DetermineFirstTurn>());
        stateMachine.AddState(StateID.Initialization, GetComponent<Initialization>());
        stateMachine.AddState(StateID.Govern, GetComponent<Govern>());
        stateMachine.AddState(StateID.Battle, GetComponent<Battle>());

        Debug.Log("Made States and Got Components");
    }
}