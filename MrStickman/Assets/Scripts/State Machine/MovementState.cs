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
        var input = Sc.Input.GetMovementInput();
        var h = input.x * Sc.MovementSpeed * Time.deltaTime;
        switch (h)
        {
            case > 0:
                Sc.PlayerState = PlayerState.Walk;
                Sc.PlayerDirection = PlayerDirection.Right;
                break;
            case < 0:
                Sc.PlayerState = PlayerState.Walk;
                Sc.PlayerDirection = PlayerDirection.Left;
                break;
            case 0:
                Sc.PlayerState = PlayerState.Idle;
                break;
        }
        UpdatePlayerAnimation();
        Sc.Rb.velocity = new Vector2(h * 100, Sc.Rb.velocity.y);
    }

    void UpdatePlayerAnimation()
    {
        switch (Sc.PlayerDirection)
        {
            case PlayerDirection.Left:
                Sc.player.transform.localScale = new Vector3(-1, 1, 1);
                break;
            case PlayerDirection.Right:
                Sc.player.transform.localScale = Vector3.one;
                break;
            default:
                throw new System.ArgumentOutOfRangeException();
        }
        switch (Sc.PlayerState)
        {
            case PlayerState.Idle:
                Sc.Anim.Play("PlayerIdle");
                break;
            case PlayerState.Walk:
                Sc.Anim.Play("PlayerWalk");
                break;
            default:
                throw new System.ArgumentOutOfRangeException();
        }
    }

    protected override void OnInteract()
    {
        if (Sc.InteractableTimer <= 0)
        {
            Sc.InteractableTimer = Sc.CurrentWeapon.cooldown;
            var mouseWorldPos = Sc.Camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            var hitCollider = Physics2D.OverlapPoint(mouseWorldPos, LayerMask.GetMask("Interactable"));
            if (hitCollider != null)
            {
                if (hitCollider.gameObject.TryGetComponent(out Breakable breakable))
                    breakable.Damage(Sc.CurrentWeapon.damage);
            }
        }
    }

    protected override void OnExit()
    {

    }
}
