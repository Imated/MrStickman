    public abstract class State
    {
        protected StateController sc;

        public void OnStateEnter(StateController stateController)
        {
            sc = stateController;
            OnEnter();
        }
        protected virtual void OnEnter() { }
        
        public void OnStateUpdate()
        {
            OnUpdate();
        }
        protected virtual void OnUpdate() { }
        
        public void OnStateFixedUpdate()
        {
            OnFixedUpdate();
        }
        protected virtual void OnFixedUpdate() { }
        
        public void OnStateInteract()
        {
            OnInteract();
        }
        protected virtual void OnInteract() { }
        
        public void OnStateExit()
        {
            OnExit();
        }
        protected virtual void OnExit() { }
    }

