using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : State
{
    public MovementState(StateController sc) : base(sc) { 
    
    }
    protected override void OnEnter()
    {

    }

    protected override void OnUpdate()
    {
        UpdatePlayerMovement();
    }

    void UpdatePlayerMovement()
    {
        var input = sc.Input.GetMovementInput();
        var h = input.x * sc.MovementSpeed * Time.deltaTime;
        switch (h)
        {
            case > 0:
                sc.PState = PlayerState.Walk;
                sc.PDirec = PlayerDirection.Right;
                break;
            case < 0:
                sc.PState = PlayerState.Walk;
                sc.PDirec = PlayerDirection.Left;
                break;
            case 0:
                sc.PState = PlayerState.Idle;
                break;
        }
        UpdatePlayerAnimation();
        sc.RB.velocity = new Vector2(h * 100, sc.RB.velocity.y);
    }

    void UpdatePlayerAnimation()
    {
        switch (sc.PDirec)
        {
            case PlayerDirection.Left:
                sc.Player.transform.localScale = new Vector3(-1, 1, 1);
                break;
            case PlayerDirection.Right:
                sc.Player.transform.localScale = Vector3.one;
                break;
            default:
                throw new System.ArgumentOutOfRangeException();
        }
        switch (sc.PState)
        {
            case PlayerState.Idle:
                sc.Anim.Play("PlayerIdle");
                break;
            case PlayerState.Walk:
                sc.Anim.Play("PlayerWalk");
                break;
            default:
                throw new System.ArgumentOutOfRangeException();
        }
    }

    protected override void OnInteract()
    {
        if (sc.InteractableTimer <= 0 && UnityEngine.InputSystem.Mouse.current.leftButton.wasPressedThisFrame)
        {
            sc.InteractableTimer = sc.CurrentWeapon.cooldown;
            var mouseWorldPos = sc.Camera.ScreenToWorldPoint(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
            var hitCollider = Physics2D.OverlapPoint(mouseWorldPos, LayerMask.GetMask("Interactable"));
            if (hitCollider != null)
            {
                if (hitCollider.gameObject.TryGetComponent(out Breakable breakable))
                    breakable.Damage(sc.CurrentWeapon.damage);
            }
        }
    }

    protected override void OnExit()
    {

    }
}
