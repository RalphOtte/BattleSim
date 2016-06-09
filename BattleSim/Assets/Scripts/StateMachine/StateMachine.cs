using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour {

	/** Dictionary to keep all states in */
	private Dictionary<StateID, State> states = new Dictionary<StateID, State> ();
	private State currentState;
	
	void Update () {
		// if there is a current state, use the Methods within
		if(currentState != null){
			currentState.Act();
		}
	}

	/// <summary>
	/// Change state
	/// </summary>
	public void SetState(StateID stateID) {

		/** If we don't know the state, stop this function */
		if(!states.ContainsKey(stateID))
			return;

		/** If we already have a state, give the state a chance to clear itself */
		if(currentState != null)
			currentState.Leave();

		/** set new 'CurrentState' */
		currentState = states[stateID];

		/** Give the new state a chance to set up */
		currentState.Enter();
	}

	/// <summary>
	/// Voeg een state toe aan de state machine
	/// LET OP! Alle components die de Class State.cs extenden (inheritance) die mogen in de Dictionary
	/// Daarom mogen AlertState.cs, AlertState.cs en FleeState.cs in de dictionary, aangezien zij State.CS extenden
	/// </summary>
	/// <param name="stateID">Een integer die komt uit de ENUM StateID (zie StateID in Guard.cs)</param>
	/// <param name="state">Een component die State.cs extend (inheritance)</param>
	public void AddState(StateID stateID, State state) {
		states.Add( stateID, state );
	}

}
