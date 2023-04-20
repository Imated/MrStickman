using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateController : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private Button _playButton, _achievementsButton, _quitButton;

    [SerializeField] private float movementSpeed;
    [SerializeField] private Weapon currentWeapon;

    public Button PlayButton
    {
        get => _playButton.GetComponent<Button>();
    }
    public Button AchievementsButton
    {
        get => _achievementsButton.GetComponent<Button>();
    }
    public Button QuitButton
    {
        get => _quitButton.GetComponent<Button>();
    }
    public Rigidbody2D Rb { get; set; }
    public Animator Anim { get; set; }
    public PlayerState PlayerState { get; set; }
    public PlayerDirection PlayerDirection { get; set; }
    public Camera Camera { get; set; }
    public float InteractableTimer { get; set; }
    public bool IsInteracting { get; set; }
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

    public State BreakState;
    public State FixState;
    public State MovementState;
    public State InteractionState;
    public State MainMenuState;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += (scene, mode) => AssignReferences();
        BreakState = new BreakState();
        FixState = new FixState();
        MovementState = new MovementState();
        InteractionState = new InteractionState();
        MainMenuState = new MainMenuState();
        AssignReferences();
        ChangeState(MainMenuState);
    }

    private void AssignReferences()
    {
        if (this == null) // you need this bc unity is weird and gives errors without it
            return;
        player = GameObject.Find("Player");
        Input = GetComponent<InputManager>();
        Camera = Camera.main;
        if (player != null)
        {
            Rb = player.GetComponent<Rigidbody2D>();
            Anim = player.GetComponent<Animator>();
        }
    }
    
    private void Update()
    {
        if (_currentState != null)
            _currentState.OnStateUpdate();
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
