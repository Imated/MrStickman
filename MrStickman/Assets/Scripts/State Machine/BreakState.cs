public class BreakState : State
{
    protected override void OnEnter()
    {
        Sc.CanBreak = true;
        AddSubState(Sc.MovementState);
        AddSubState(Sc.InteractionState);
    }

    protected override void OnExit()
    {

    }
}
