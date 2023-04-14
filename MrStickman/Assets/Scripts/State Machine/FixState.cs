public class FixState : State
{
    public FixState(StateController sc) : base(sc)
    {
        
    }

    protected override void OnEnter()
    {
        sc.CanBreak = false;
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
