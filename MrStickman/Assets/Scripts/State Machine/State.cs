    public abstract class State
    {
        protected StateController sc;

    protected State(StateController sc)
    {
        this.sc = sc;
    }

    public void OnStateEnter(StateController stateController)
        {
            // Code placed here will always run
            sc = stateController;
            OnEnter();
        }
        protected virtual void OnEnter()
        {
            // Code placed here can be overridden
        }
        public void OnStateUpdate()
        {
            // Code placed here will always run
            OnUpdate();
        }
        protected virtual void OnUpdate()
        {
            // Code placed here can be overridden
        }
        public void OnStateInteract()
        {
            // Code placed here will always run
            OnInteract();
        }
        protected virtual void OnInteract()
        {
            // Code placed here can be overridden
        }
        public void OnStateExit()
        {
            // Code placed here will always run
            OnExit();
        }
        protected virtual void OnExit()
        {
            // Code placed here can be overridden
        }
    }

