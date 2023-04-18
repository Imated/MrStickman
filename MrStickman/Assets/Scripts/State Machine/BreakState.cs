using UnityEngine;

public class BreakState : State
{
    protected override void OnEnter()
    {
        sc.CanBreak = true;
    }

    protected override void OnUpdate()
    {
        var inpValue = sc.Input.GetMovementInput();
        if (inpValue != new Vector2(0, 0))
            sc.ChangeState(sc.MovementState);
    }

    protected override void OnInteract()
    {

    }

    protected override void OnExit()
    {

    }
}
