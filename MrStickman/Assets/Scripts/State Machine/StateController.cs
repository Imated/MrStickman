using UnityEngine;

public class StateController : MonoBehaviour
{
    public State BreakState;
    public State FixState;

    private State _currentState;
    
    private void Awake()
    {
        BreakState = new BreakState(this);
        FixState = new FixState(this);
        ChangeState(BreakState);
    }
    
    private void Update()
    {
        if (_currentState != null)
            _currentState.UpdateState();
    }
    
    public void ChangeState(State newState)
    {
        if (_currentState != null)
            _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }
}
