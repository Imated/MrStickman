using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    Idle,
    Walk
}

public enum PlayerDirection
{
    Left,
    Right
}

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Tool currentTool;

    private Rigidbody2D _rb;
    private InputManager _inputManager;
    private Animator _anim;

    private PlayerState _state;
    private PlayerDirection _direction;
    
    private Camera _camera;
    private float _interactableTimer;

    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputManager = GetComponent<InputManager>();
        _anim = GetComponent<Animator>();
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        UpdatePlayerMovement();
    }

    private void UpdatePlayerMovement()
    {
        var input = _inputManager.GetMovementInput();
        var h = input.x * movementSpeed * Time.deltaTime;
        switch (h)
        {
            case > 0:
                _state = PlayerState.Walk;
                _direction = PlayerDirection.Right;
                break;
            case < 0:
                _state = PlayerState.Walk;
                _direction = PlayerDirection.Left;
                break;
            case 0:
                _state = PlayerState.Idle;
                break;
        }
        UpdatePlayerAnimation();
        _rb.velocity = new Vector2(h * 100, _rb.velocity.y);
    }

    private void UpdatePlayerAnimation()
    {
        switch (_direction)
        {
            case PlayerDirection.Left:
                transform.localScale = new Vector3(-1, 1, 1);
                break;
            case PlayerDirection.Right:
                transform.localScale = Vector3.one;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        switch (_state)
        {
            case PlayerState.Idle:
                _anim.Play("PlayerIdle");
                break;
            case PlayerState.Walk:
                _anim.Play("PlayerWalk");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private void Update()
    {
        Interact();
        _interactableTimer -= Time.deltaTime;
    }

    void Interact()
    {
        if (_interactableTimer <= 0 && Mouse.current.leftButton.wasPressedThisFrame)
        {
            _interactableTimer = currentTool.cooldown;
            var mouseWorldPos = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            var hitCollider = Physics2D.OverlapPoint(mouseWorldPos, LayerMask.GetMask("Interactable"));
            if (hitCollider != null)
            {
                if (hitCollider.gameObject.TryGetComponent(out Breakable breakable))
                    breakable.Damage(currentTool.damage);
            }
        }
    }

}
