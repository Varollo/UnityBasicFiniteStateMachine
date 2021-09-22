using UnityEngine;

namespace Varollo.BasicFiniteStateMachine
{
    public class StateMachine
    {
        public readonly StateMachineController Controller;

        private State currentState;
        private bool isInitialized;

        public bool IsInitialized
        {
            get
            {
                if (!isInitialized)
                {
                    ThrowNotInitializedError();
                }

                return isInitialized;
            }
            set
            {
                if (IsInitialized) return;
                isInitialized = value;
            }
        }

        public State CurrentState
        {
            get => currentState;
            set
            {
                if (!IsInitialized) return;

                currentState.Exit();

                currentState = value;

                currentState.Enter();
            }
        }

        public StateMachine(StateMachineController controller)
        {
            Controller = controller;
        }

        public void Initialize(State initialState)
        {
            IsInitialized = true;

            CurrentState = initialState;
            CurrentState.Enter();
        }

        public void ThrowNotInitializedError() => Debug.LogError("State Machine not initialized.");
    }
}