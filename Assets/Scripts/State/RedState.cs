using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class RedState : IState
{
  
    public void BlueState(StateController controller)
    {
        //set blue bool true
        controller.ChangeState(controller.blueState);
    }

    public void OnEnter(StateController controller)
    {
        
    }

    public void OnExit(StateController controller)
    {
        //sets blue bool false
    }

    public void UpdateState(StateController controller)
    {
      //Button pressed. Calls BlueState
    }

    void IState.RedState(StateController controller)
    {
        
    }

 
}
