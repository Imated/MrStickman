using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;
    
    private Vector2 _movementInput;

    private void OnEnable()
    {
        if (_playerControls == null)
            _playerControls = new PlayerControls();
        _playerControls.Enable();
        _playerControls.Player.Movement.performed += ctx => _movementInput = ctx.ReadValue<Vector2>();
        _playerControls.Player.Movement.canceled += ctx => _movementInput = ctx.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        _playerControls.Player.Movement.performed -= ctx => _movementInput = ctx.ReadValue<Vector2>();
        _playerControls.Player.Movement.canceled -= ctx => _movementInput = ctx.ReadValue<Vector2>();
        _playerControls.Disable();
    }

    public Vector2 GetMovementInput()
    {
        return _movementInput;
    }
}
