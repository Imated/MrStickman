using UnityEngine;

public class FixState : State
{
    protected override void OnEnter()
    {
        sc.CanBreak = false;
    }

    protected override void OnUpdate()
    {
        if (sc.Input.GetMovementInput() != Vector2.zero)
            sc.ChangeState(sc.MovementState);
    }

    protected override void OnInteract()
    {

    }

    protected override void OnExit()
    {

    }
}
