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
        var inpValue = sc.Input.GetMovementInput();
        if (inpValue != new UnityEngine.Vector2(0, 0))
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
