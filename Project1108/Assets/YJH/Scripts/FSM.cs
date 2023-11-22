using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YJH;

public class Fsm
{
    private BaseState curState;
    public Fsm(BaseState initState)
    {
        curState = initState;
        ChangeState(initState);
    }

    public void ChangeState(BaseState nextState)
    {
        if(curState == nextState)
        {
            return;
        }
        
        if(curState != null)
        {
            curState.OnStateExit();
        }

        curState = nextState;
        nextState.OnStateEnter();
    }

    public void UpdateState()
    {
        if(curState != null)
        {
            curState.OnStateUpdate();
        }
    }
}
