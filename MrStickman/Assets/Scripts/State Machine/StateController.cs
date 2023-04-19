using UnityEngine;
using UnityEngine.InputSystem;

public class StateController : MonoBehaviour
{
    public State BreakState, FixState, MovementState;
    public GameObject player;
    
    [SerializeField] private float movementSpeed;
    [SerializeField] private Weapon currentWeapon;

    public Rigidbody2D Rb { get; set; }
    public Animator Anim { get; set; }
    public PlayerState PlayerState { get; set; }
    public PlayerDirection PlayerDirection { get; set; }
    public Camera Camera { get; set; }
    public float InteractableTimer { get; set; }
    public float MovementSpeed 
    {
        get => movementSpeed;
        set => movementSpeed = value;
    }
    public Weapon CurrentWeapon 
    {
        get => currentWeapon;
        set => currentWeapon = value;
    }
    public bool CanBreak { get; set; }
    public InputManager Input { get; set; }
    
    private State _currentState;
    
    private void Awake()
    {
        BreakState = new BreakState();
        FixState = new FixState();
        MovementState = new MovementState();
        AssignReferences();
        ChangeState(BreakState);
    }

    private void AssignReferences()
    {
        Rb = player.GetComponent<Rigidbody2D>();
        Input = player.GetComponent<InputManager>();
        Anim = player.GetComponent<Animator>();
        Camera = Camera.main;
    }
    
    private void Update()
    {
        if (_currentState != null)
            _currentState.OnStateUpdate();
        if(_currentState != null && Mouse.current.leftButton.wasPressedThisFrame)
            _currentState.OnStateInteract();
        InteractableTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (_currentState != null)
            _currentState.OnStateFixedUpdate();
    }

    public void ChangeState(State newState)
    {
        if (!newState.IsSuper())
            newState = newState.Super;
        if (_currentState != null)
            _currentState.OnStateExit();
        _currentState = newState;
        _currentState.OnStateEnter(this);
    }
}
