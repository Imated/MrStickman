public class BreakState : State
{
    public BreakState(StateController sc) : base(sc)
    {
        
    }

    protected override void OnEnter()
    {
        sc.CanBreak = true;
    }

    protected override void OnUpdate()
    {
        if (sc.Input.GetMovementInput() != UnityEngine.Vector2.zero)
        {
            sc.ChangeState(sc.MovementState);
        }
    }

    protected override void OnInteract()
    {

    }

    protected override void OnExit()
    {

    }
}
