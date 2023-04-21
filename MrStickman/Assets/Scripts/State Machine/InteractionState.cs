using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionState : State
{
    protected override void OnEnter()
    {

    }

    protected override void OnUpdate()
    {
        HandleInteraction();
        Sc.InteractableTimer -= Time.deltaTime;
    }
    
    private void HandleInteraction()
    {
        if (Sc.InteractableTimer <= 0 && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Sc.InteractableTimer = Sc.CurrentWeapon.cooldown;
            var mouseWorldPos = Sc.Camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            var hitCollider = Physics2D.OverlapPoint(mouseWorldPos, LayerMask.GetMask("Interactable"));
            if (hitCollider != null && !Sc.IsInteracting)
            {
                Sc.IsInteracting = true;
                if (hitCollider.gameObject.TryGetComponent(out Breakable breakable))
                {
                    if (breakable.IsBroken)
                    {
                        Sc.IsInteracting = false;
                        return;
                    }
                    breakable.Damage(Sc.CurrentWeapon.damage);
                }

                Super.OnStateInteract();
                Sc.IsInteracting = false;
            }
        }
    }

    protected override void OnExit()
    {

    }
}
