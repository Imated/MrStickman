using UnityEngine;
using UnityEngine.InputSystem;

public class MovementState : State
{
    protected override void OnEnter()
    {
        
    }

    protected override void OnFixedUpdate()
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
                sc.PlayerState = PlayerState.Walk;
                sc.PlayerDirection = PlayerDirection.Right;
                break;
            case < 0:
                sc.PlayerState = PlayerState.Walk;
                sc.PlayerDirection = PlayerDirection.Left;
                break;
            case 0:
                sc.PlayerState = PlayerState.Idle;
                break;
        }
        UpdatePlayerAnimation();
        sc.Rb.velocity = new Vector2(h * 100, sc.Rb.velocity.y);
    }

    void UpdatePlayerAnimation()
    {
        switch (sc.PlayerDirection)
        {
            case PlayerDirection.Left:
                sc.player.transform.localScale = new Vector3(-1, 1, 1);
                break;
            case PlayerDirection.Right:
                sc.player.transform.localScale = Vector3.one;
                break;
            default:
                throw new System.ArgumentOutOfRangeException();
        }
        switch (sc.PlayerState)
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
        if (sc.InteractableTimer <= 0)
        {
            sc.InteractableTimer = sc.CurrentWeapon.cooldown;
            var mouseWorldPos = sc.Camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
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
