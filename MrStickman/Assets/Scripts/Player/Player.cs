using System;
using UnityEngine;

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

    private Rigidbody2D _rb;
    private InputManager _inputManager;
    private Animator _anim;

    private PlayerState _state;
    private PlayerDirection _direction;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputManager = GetComponent<InputManager>();
        _anim = GetComponent<Animator>();
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
}
