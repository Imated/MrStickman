using UnityEngine;

public class BreakState : State
{
    protected override void OnEnter()
    {
        Sc.CanBreak = true;
        AddSubState(Sc.MovementState);
    }

    protected override void OnUpdate()
    {
        var inpValue = Sc.Input.GetMovementInput();
        if (inpValue != new Vector2(0, 0))
            Sc.ChangeState(Sc.MovementState);
    }

    protected override void OnInteract()
    {

    }

    protected override void OnExit()
    {

    }
}
