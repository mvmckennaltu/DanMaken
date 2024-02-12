using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    IState currentState;
    public RedState redState = new RedState();
    public BlueState blueState = new BlueState();
    private void Update()
    {
        if (currentState == null)
        {
            currentState.UpdateState(this);
        }
        
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
            
        }
        currentState = newState;
        currentState.OnEnter(this);
    }
    
}
public interface IState
{
    public void OnEnter(StateController controller);
    public void UpdateState(StateController controller);
    public void RedState(StateController controller);
    public void BlueState(StateController controller);
    public void OnExit(StateController controller);
}