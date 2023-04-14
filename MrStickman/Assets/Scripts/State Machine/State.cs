public abstract class State
{
    private StateController _stateController;
    protected StateController StateController => _stateController;

    public State(StateController sc)
    {
        _stateController = sc;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
