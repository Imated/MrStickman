using UnityEngine;

public class FixState : State
{
    protected override void OnEnter()
    {
        Sc.CanBreak = false;
    }

    protected override void OnUpdate()
    {
        if (Sc.Input.GetMovementInput() != Vector2.zero)
            Sc.ChangeState(Sc.MovementState);
    }

    protected override void OnInteract()
    {

    }

    protected override void OnExit()
    {

    }
}
