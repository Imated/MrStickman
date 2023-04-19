using System.Collections.Generic;

public abstract class State
{
    protected StateController Sc;
    public State Super;
    public List<State> SubStates = new List<State>();

    public bool IsSuper() => Super == null;

    public void OnStateEnter(StateController stateController)
    {
        Sc = stateController;
        OnEnter();
    }

    public void OnStateUpdate()
    {
        OnUpdate();
        foreach (var state in SubStates)
            state.OnStateUpdate();
    }

    public void OnStateFixedUpdate()
    {
        OnFixedUpdate();
        foreach (var state in SubStates)
            state.OnFixedUpdate();
    }

    public void OnStateInteract()
    {
        OnInteract();
        foreach (var state in SubStates)
            state.OnStateInteract();
    }

    public void OnStateExit()
    {
        OnExit();
        foreach (var state in SubStates)
            state.OnStateExit();
    }

    public void SetSuperState(State state)
    {
        Super = state;
    }

    public void AddSubState(State state)
    {
        state.SetSuperState(this);
        SubStates.Add(state);
        state.OnStateEnter(Sc);
    }

    protected virtual void OnEnter() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnFixedUpdate() { }
    protected virtual void OnInteract() { }
    protected virtual void OnExit() { }
}