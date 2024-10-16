using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateMachine 
{
    public playerState currentState;

    public void init(playerState state)
    {
        currentState = state;
        state.enter();
    }
    public void changeState(playerState _Newstate) {
        currentState.exit();
        currentState = _Newstate;
        currentState.enter();
    }
}
