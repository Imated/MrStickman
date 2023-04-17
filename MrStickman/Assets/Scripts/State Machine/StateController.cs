using UnityEngine;

public class StateController : MonoBehaviour
{
    public StateController Instance;

    public State BreakState, FixState, MovementState;
    public GameObject Player;
    

    [SerializeField] private float movementSpeed;
    [SerializeField] private Weapon currentWeapon;

    private Rigidbody2D _rb;
    private InputManager _inputManager;
    private Animator _anim;

    private PlayerState _pState;
    private PlayerDirection _pDirection;

    private Camera _camera;
    private float _interactableTimer;



    private bool _canBreak = false;
    private InputManager _input;
    
    public Rigidbody2D RB
    {
        get
        {
            return _rb;
        }
        set
        {
            _rb = value;
        }
    }
    public Animator Anim
    {
        get
        {
            return _anim;
        }
        set
        {
            _anim = value;
        }
    }
    public PlayerState PState
    {
        get
        {
            return _pState;
        }
        set
        {
            _pState = value;
        }
    }
    public PlayerDirection PDirec
    {
        get
        {
            return _pDirection;
        }
        set
        {
            _pDirection = value;
        }
    }
    public Camera Camera
    {
        get
        {
            return _camera;
        }
        set
        {
            _camera = value;
        }
    }
    public float InteractableTimer
    {
        get
        {
            return _interactableTimer;
        }
        set
        {
            _interactableTimer = value;
        }
    }
    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
        set
        {
            movementSpeed = value;
        }
    }
    public Weapon CurrentWeapon
    {
        get
        {
            return currentWeapon;
        }
        set
        {
            currentWeapon = value;
        }
    }
    public bool CanBreak
    {
        get
        {
           return _canBreak;
        }
        set
        {
            _canBreak = value;
        }
    }

    public InputManager Input
    {
        get
        {
            return _inputManager;
        }
    }

    private State _currentState;
    
    private void Awake()
    {
        BreakState = new BreakState(this);
        FixState = new FixState(this);
        ChangeState(BreakState);

        _currentState = BreakState;  
    }
    
    private void Update()
    {
        if (_currentState != null)
            _currentState.OnStateUpdate();
        Instance = this;
    }
    
    public void ChangeState(State newState)
    {
        if (_currentState != null)
            _currentState.OnStateExit();
        _currentState = newState;
        _currentState.OnStateEnter(Instance);
    }
}
